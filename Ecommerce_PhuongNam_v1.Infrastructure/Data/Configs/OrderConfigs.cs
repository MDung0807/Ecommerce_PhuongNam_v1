using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class OrderConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(x => x.FromAddress)
            .WithMany(x => x.Sends)
            .HasForeignKey("OrderIdSend");

        builder.HasOne(x => x.ToAddress)
            .WithMany(x => x.Recevices)
            .HasForeignKey("OrderReceiveId");

        builder.HasOne(x => x.PaymentMethod)
            .WithMany(x => x.Orders)
            .HasForeignKey("PaymentId");

        builder.HasOne(x => x.ShippingMethod)
            .WithMany(x => x.Orders)
            .HasForeignKey("ShippingMethodId");
    }
}