using Ecommerce_PhuongNam_v1.Domain.Entities;
using Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam_v1.Infrastructure.Data.Configs;

public class CategoryConfigs : BaseEntityConfig<Guid>, IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasAlternateKey(x => x.Name);
        builder.HasOne(x => x.Parent)
            .WithMany()
            .HasForeignKey("ParentId")
            .IsRequired(false);
    }
}