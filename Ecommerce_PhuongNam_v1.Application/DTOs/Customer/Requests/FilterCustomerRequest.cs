using Ecommerce_PhuongNam_v1.Application.Paging.Customer;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests;

public class FilterCustomerRequest : CustomerPaging
{
    public string Param { get; set; }
}