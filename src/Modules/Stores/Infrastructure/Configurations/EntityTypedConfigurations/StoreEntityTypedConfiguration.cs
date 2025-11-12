using Hababk.Modules.Stores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hababk.Modules.Stores.Infrastructure.Configurations.EntityTypedConfigurations;
 

public class StoreEntityTypedConfiguration :IEntityTypeConfiguration<Store> 
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("stores", StoreDbContext.DefaultSchema);
        builder.HasKey(store => store.Id).HasName("id");
        builder.Property(st => st.StoreName).IsRequired().HasMaxLength(200).HasColumnName("storename");
        builder.Property(st => st.Description).HasMaxLength(500).HasColumnName("description");  
        builder.Property(st=>st.UserId).IsRequired().HasColumnName("userId");
        builder.Ignore(s => s.DomainEvents);
        builder.OwnsOne(s=>s.Contact, cb =>
        {
           
            cb.Property(c => c.EmailAddress).HasColumnName("email").HasMaxLength(100);
            cb.Property(c => c.PhoneNumber).HasColumnName("phonenumber").HasMaxLength(15);
            cb.ToTable("contacts", StoreDbContext.DefaultSchema);
        });
        
    }
}