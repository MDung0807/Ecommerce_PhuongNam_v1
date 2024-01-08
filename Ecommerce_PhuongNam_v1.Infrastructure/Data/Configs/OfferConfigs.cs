using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class OfferConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Offers)
            .HasForeignKey("CustomerId");

        builder.HasOne(x => x.Variant)
            .WithMany(x => x.Offers)
            .HasForeignKey("VariantId");
    }
}