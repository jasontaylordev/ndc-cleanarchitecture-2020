using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Domain.Entities;
using CaWorkshop.Infrastructure.Identity;
using CaWorkshop.Infrastructure.Persistence.Interceptors;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace CaWorkshop.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<TodoList> TodoLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableDetailedErrors()
                .AddInterceptors(new AuditEntitiesSaveChangesInterceptor(_currentUserService));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
