using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class CustomerConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

        builder.HasOne(x => x.Rank)
            .WithMany(x => x.Customers)
            .HasForeignKey("RankId");
        builder.HasOne(x => x.Account)
            .WithOne(x => x.Customer)
            .HasForeignKey<Customer>("AccountId");
    }
}