using Ecommerce_PhuongNam_v1.Application.Specifications;
using Ecommerce_PhuongNam_v1.Domain.Entities;

namespace Ecommerce_PhuongNam_v1.Application.Common.OTP.Specification;

public class OtpSpecification : BaseSpecification<OtpCode>
{
    public OtpSpecification(string email, DateTime dateTime, int minute, bool checkStatus = true) 
        : base(x => x.Email == email && x.DateUpdate.AddMinutes(minute) >  dateTime,
            checkStatus:checkStatus)
    {
        
    }
    
    public OtpSpecification(string email, bool checkStatus = true) 
        : base(x => x.Email == email,
            checkStatus:checkStatus)
    {
        
    }
}