using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class WardConfigs :BaseEntityConfig<long>, IEntityTypeConfiguration<Ward>
{
    public void Configure(EntityTypeBuilder<Ward> builder)
    {
        #region -- Properties --

        #endregion -- Properties --

        #region -- Relationship --

        builder.HasOne(x => x.AdministrativeUnit)
            .WithMany(x => x.Wards)
            .HasForeignKey("AdministrativeUnitId")
            .IsRequired();

        builder.HasOne(x => x.District)
            .WithMany(x => x.Wards)
            .HasForeignKey("DistrictId")    
            .IsRequired();

        #endregion -- Relationship --
    }
}