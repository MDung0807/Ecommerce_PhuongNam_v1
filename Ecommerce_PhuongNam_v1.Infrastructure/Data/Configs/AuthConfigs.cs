using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Ecommerce_PhuongNam.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class AuthConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<Auth>
{
    public void Configure(EntityTypeBuilder<Auth> builder)
    {
        builder.HasAlternateKey(x => x.IdDeceive);

        #region -- Relationship --

        builder.HasOne(x => x.Account)
            .WithMany(x => x.Auths)
            .HasForeignKey("AccountId");
        #endregion -- Relationship --
    }
}