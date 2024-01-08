using Ecommerce_PhuongNam_v1.Domain.Common;
using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam_v1.Domain.Entities;

public class Ward : BaseEntity<long>
{
    #region -- Properties --

    public string FullName { get; set; }
    public string FullNameEnglish { get; set; }
    public string CodeName { get; set; }
    public string Name { get; set; }
    public string NameEnglish { get; set; }

    #endregion -- Properties --

    #region -- Relationship --
    public District District { get; set; }
    public AdministrativeUnit AdministrativeUnit { get; set; }
    #endregion -- Relationship --
}