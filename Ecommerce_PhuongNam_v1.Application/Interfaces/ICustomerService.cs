using Ecommerce_PhuongNam_v1.Application.Common.OTP.Models;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses;
using Ecommerce_PhuongNam_v1.Application.Paging.Customer;

namespace Ecommerce_PhuongNam_v1.Application.Interfaces
{
    public interface ICustomerService : IService<FormRegister,FormUpdate, Guid, ProfileResponse, CustomerPaging, CustomerPagingResult>
    {
        Task<CustomerPagingResult> GetAllCustomer(CustomerPaging paging);
        Task<bool> AuthOtp(OtpRequest request);
        Task<bool> AddLocation(LocationRequest request);
        Task<List<CusLocationResponse>> GetAllLocation(Guid customerId);
        Task<bool> RemoveAddress(Guid addressDetailId);
        Task<CustomerPagingResult> FilterCustomer(FilterCustomerRequest request);
    }
}
