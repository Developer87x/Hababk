using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hababk.Modules.Identities.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Identities.Infrastructure.Configurations.EntityTypedConfigurations;

public class UserRoleEntityTypedConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("userroles",IdentitiesDbContext.Schema);
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.HasOne<Role>()
               .WithMany()
               .HasForeignKey(ur => ur.RoleId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(ur => ur.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
