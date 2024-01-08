using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class AddressDetailConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<AddressDetail>
{
    public void Configure(EntityTypeBuilder<AddressDetail> builder)
    {
        #region -- Relationship --

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.AddressDetails)
            .HasForeignKey("CustomerId")
            .IsRequired(false);
        
        builder.HasOne(x => x.Shop)
            .WithMany(x => x.AddressDetails)
            .HasForeignKey("ShopId")
            .IsRequired(false);

        #endregion -- Relationship --
    }
}