using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class AdministrativeRegion : BaseEntity<long>
{
    #region -- Properties --

    public string Name { get; set; }
    public string NameEnglish { get; set; }
    public string CodeName { get; set; }
    public string CodeNameEnglish { get; set; }

    #endregion -- Properties --

    #region -- Relationship --

    public ICollection<Province> Provinces { get; set; }

    #endregion -- Relationship --
}