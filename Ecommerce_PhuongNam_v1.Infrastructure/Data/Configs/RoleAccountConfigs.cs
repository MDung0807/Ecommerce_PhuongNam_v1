using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class RoleAccountConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<RoleAccount>
{
    public void Configure(EntityTypeBuilder<RoleAccount> builder)
    {
        builder.HasOne(x => x.Role)
            .WithMany(x => x.RoleAccounts)
            .HasForeignKey("RoleId");

        builder.HasOne(x => x.Account)
            .WithMany(x => x.RoleAccounts)
            .HasForeignKey("AccountId");
    }
}