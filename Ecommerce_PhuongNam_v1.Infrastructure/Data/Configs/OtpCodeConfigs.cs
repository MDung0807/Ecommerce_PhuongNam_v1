using Ecommerce_PhuongNam_v1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusBookTicket.Core.Models.EntityFW.Configurations;

public class OtpCodeConfigs : IEntityTypeConfiguration<OtpCode>
{
    public void Configure(EntityTypeBuilder<OtpCode> builder)
    {
        builder.HasAlternateKey(x => x.Email);
        builder.HasAlternateKey(x => x.PhoneNumber);
    }
}