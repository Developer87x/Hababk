using Hababk.Modules.Stores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hababk.Modules.Stores.Infrastructure.Configurations.EntityTypedConfigurations;
 

public class StoreEntityTypedConfiguration :IEntityTypeConfiguration<Store> 
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("Stores", StoreDbContext.DefaultSchema);
        builder.HasKey(store => store.Id);
        builder.Property(st => st.StoreName).IsRequired().HasMaxLength(200);

        builder.Ignore(s => s.DomainEvents);
        builder.OwnsOne(s=>s.Contact, cb =>
        {
            cb.Property(c => c.EmailAddress).HasColumnName("ContactEmail").HasMaxLength(100);
            cb.Property(c => c.PhoneNumber).HasColumnName("ContactPhoneNumber").HasMaxLength(15);
            cb.ToTable("Contacts", StoreDbContext.DefaultSchema);
        });
        
    }
}