using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hababk.Modules.Identities.Domain.Entities;
using Hababk.Modules.Identities.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations.EntityTypedConfigurations
{
    public class UserEntityTypedConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", IdentitiesDbContext.Schema);
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(500);
            
        }
    }
}