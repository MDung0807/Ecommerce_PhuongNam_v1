using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class ReviewConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Reviews)
            .HasForeignKey("CustomerId");

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Reviews)
            .HasForeignKey("ProductId");
    }
}