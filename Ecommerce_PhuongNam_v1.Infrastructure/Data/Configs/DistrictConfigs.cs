using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class DistrictConfigs :BaseEntityConfig<long>, IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        #region -- Properties --


        #endregion -- Properties --

        #region -- Relationship --

        builder.HasOne(x => x.AdministrativeUnit)
            .WithMany(x => x.Districts)
            .HasForeignKey("AdministrativeUnitId");

        builder.HasOne(x => x.Province)
            .WithMany(x => x.Districts)
            .HasForeignKey("ProvinceId");

        #endregion -- Relationship --
    }
}