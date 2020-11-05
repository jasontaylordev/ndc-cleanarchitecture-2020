using CaWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaWorkshop.Infrastructure.Persistence.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(e => e.Title)
                .HasMaxLength(280)
                .IsRequired();

            builder.Property(e => e.Note)
                .HasMaxLength(4000);
        }
    }
}
