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
            builder.ToTable("users", IdentitiesDbContext.Schema);
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(100).HasColumnName("userName");
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100).HasColumnName("email");
            builder.Property(u => u.Password).IsRequired().HasMaxLength(50).HasColumnName("password");
            
        }
    }
}