using Hababk.Modules.Identities.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hababk.Modules.Identities.Infrastructure.Configurations.EntityTypedConfigurations;
    public class UserEntityTypedConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", IdentitiesDbContext.Schema);
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(100).HasColumnName("userName");
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100).HasColumnName("email");
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100).HasColumnName("password");
            
        }
    }
