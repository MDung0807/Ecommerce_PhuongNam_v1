using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class AdministrativeUnit : BaseEntity<long>
{
    #region -- Properties --

    public string FullName { get; set; }
    public string FullNameEnglish { get; set; }
    public string CodeName { get; set; }
    public string CodeNameEnglish { get; set; }
    public string ShortName { get; set; }
    public string ShortNameEnglish { get; set; }

    #endregion -- Properties --

    #region -- Relationship --
    public ICollection<Province> Provinces { get; set; }
    public ICollection<District> Districts { get; set; }
    public ICollection<Ward> Wards { get; set; }
    #endregion -- Relationship --
}