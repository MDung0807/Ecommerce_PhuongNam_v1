using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;

public class BaseEntityConfig<T>: IEntityTypeConfiguration<BaseEntity<T>>
{
    public void Configure(EntityTypeBuilder<BaseEntity<T>> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(x => x.DateCreate).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.DateUpdate).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.CreateBy).HasDefaultValue(0);
        builder.Property(x => x.UpdateBy).HasDefaultValue(0);
    }
}