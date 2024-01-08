using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class ProductConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(x => x.Brand)
            .WithMany(x => x.Products)
            .HasForeignKey("BrandId");

        builder.HasOne(x => x.Shop)
            .WithMany(x => x.Products)
            .HasForeignKey("ShopId");

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey("CategoryId");
    }
}