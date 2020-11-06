using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaWorkshop.Infrastructure.Persistence.Interceptors
{
    public class AuditEntitiesSaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;

        public AuditEntitiesSaveChangesInterceptor(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            AuditEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            AuditEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void AuditEntities(DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.CreatedUtc = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Added ||
                    entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
                    entry.Entity.LastModifiedUtc = DateTime.UtcNow;
                }
            }
        }
    }
}
