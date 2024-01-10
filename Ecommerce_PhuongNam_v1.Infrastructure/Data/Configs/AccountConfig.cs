using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class AccountConfig : BaseEntityConfig<Guid>, IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(x => x.Username);
        builder.Property(x => x.Password)
            .IsRequired();
        builder.HasAlternateKey(x => x.Username);
    }
}