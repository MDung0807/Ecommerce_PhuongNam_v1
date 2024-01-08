using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;
public class Province : BaseEntity<long>
{
    #region -- Properties --

    public string FullName { get; set; }
    public string FullNameEnglish { get; set; }
    public string CodeName { get; set; }
    public string Name { get; set; }
    public string NameEnglish { get; set; }

    #endregion -- Properties --

    #region -- Relationship --
    public AdministrativeRegion AdministrativeRegion { get; set; }
    public AdministrativeUnit AdministrativeUnit { get; set; }
    public ICollection<District> Districts { get; set; }

    #endregion -- Relationship --
}