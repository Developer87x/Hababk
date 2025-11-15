using Hababk.Modules.Identities.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Identities.Infrastructure.Configurations.EntityTypedConfigurations;

public class RoleEntityTypedConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles",IdentitiesDbContext.Schema);
        builder.HasKey(r => r.Id).HasName("id");
        builder.Property(r => r.RoleName).IsRequired().HasMaxLength(100).HasColumnName("roleName");
    }
}