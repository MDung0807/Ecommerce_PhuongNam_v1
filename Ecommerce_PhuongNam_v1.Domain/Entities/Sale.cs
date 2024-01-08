using System.Runtime.InteropServices.JavaScript;
using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Sale : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public double Discount { get; set; }
    public long TotalSold { get; set; }
    public ICollection<Product> Products { get; set; }
}