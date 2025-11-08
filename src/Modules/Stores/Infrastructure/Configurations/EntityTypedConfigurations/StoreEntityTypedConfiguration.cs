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
        
    }
}