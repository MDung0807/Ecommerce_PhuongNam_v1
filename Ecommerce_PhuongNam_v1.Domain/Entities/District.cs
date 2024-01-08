using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class District : BaseEntity<long>
{
    #region -- Properties --

    public string FullName { get; set; }
    public string FullNameEnglish { get; set; }
    public string CodeName { get; set; }
    public string Name { get; set; }
    public string NameEnglish { get; set; }

    #endregion -- Properties --

    #region -- RelationShip --
    public ICollection<Ward> Wards { get; set; }
    public AdministrativeUnit AdministrativeUnit { get; set; }
    public Province Province { get; set; }
    #endregion -- RelationShip --
}