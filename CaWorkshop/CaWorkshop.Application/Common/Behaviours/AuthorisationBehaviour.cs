using CaWorkshop.Application.Common.Exceptions;
using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Application.Common.Security;
using MediatR;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CaWorkshop.Application.Common.Behaviours
{
    public class AuthorisationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public AuthorisationBehaviour(
            ICurrentUserService currentUserService,
            IIdentityService identityService)
        {
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var authoriseAttributes = request.GetType().GetCustomAttributes<AuthoriseAttribute>();

            if (authoriseAttributes.Any())
            {
                // Must be authenticated user
                if (_currentUserService.UserId == null)
                {
                    throw new UnauthorizedAccessException();
                }

                var authoriseAttributesWithRoles = authoriseAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

                if (authoriseAttributesWithRoles.Any())
                {
                    foreach (var roles in authoriseAttributesWithRoles.Select(a => a.Roles.Split(',')))
                    {
                        var authorized = false;
                        foreach (var role in roles)
                        {
                            var isInRole = await _identityService.UserIsInRole(_currentUserService.UserId, role.Trim());
                            if (isInRole)
                            {
                                authorized = true;
                                break;
                            }
                        }

                        // Must be a member of at least one role in roles
                        if (!authorized)
                        {
                            throw new ForbiddenAccessException();
                        }
                    }
                }
            }

            // User is authorized / authorization not required
            return await next();
        }
    }
}