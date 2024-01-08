using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class OrderItemConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        #region -- Relationship --

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.OrderItems)
            .HasForeignKey("VariantId");

        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .HasForeignKey("OrderId");

        #endregion -- Relationship --
    }
}