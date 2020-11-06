using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaWorkshop.Infrastructure.Persistence.Configurations
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureAuditableEntities(this EntityTypeBuilder builder)
        {
            builder.Property("CreatedBy")
                .HasMaxLength(450);

            builder.Property("LastModifiedBy")
                .HasMaxLength(450);
        }
    }
}
