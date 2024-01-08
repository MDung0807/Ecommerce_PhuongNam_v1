using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class CartItemConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        #region -- Relationship --

        builder.HasOne(x => x.Cart)
            .WithMany(x => x.CartItems)
            .HasForeignKey("CartId")
            .IsRequired();

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.CartItems)
            .HasForeignKey("VariantId")
            .IsRequired();

        #endregion -- Relationship --
    }
}