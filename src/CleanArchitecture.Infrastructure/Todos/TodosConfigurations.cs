using CleanArchitecture.Domain.Todos;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Users.Persistence;

public class TodosConfigurations : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever();

        builder.Property(u => u.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(u => u.DueDate)
            .HasColumnType("datetime2");

        builder.Property(u => u.IsCompleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(u => u.Priority)
            .IsRequired()
            .HasDefaultValue(0);
    }
}