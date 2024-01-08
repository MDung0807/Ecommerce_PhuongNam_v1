using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class ReviewReplyConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<ReviewReply>
{
    public void Configure(EntityTypeBuilder<ReviewReply> builder)
    {
        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Replies)
            .HasForeignKey("CustomerId")
            .IsRequired(false);
        
        builder.HasOne(x => x.Shop)
            .WithMany(x => x.Replies)
            .HasForeignKey("ShopId")
            .IsRequired(false);

        builder.HasOne(x => x.Review)
            .WithMany(x => x.Replies)
            .HasForeignKey("ReivewId");

    }
}