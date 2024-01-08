using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class AdministrativeUnitConfigs :BaseEntityConfig<long>, IEntityTypeConfiguration<AdministrativeUnit>
{


    public void Configure(EntityTypeBuilder<AdministrativeUnit> builder)
    {
        #region -- Properties --


        #endregion -- Properties --

        #region -- Relationship --

        

        #endregion -- Relationship --
    }
}