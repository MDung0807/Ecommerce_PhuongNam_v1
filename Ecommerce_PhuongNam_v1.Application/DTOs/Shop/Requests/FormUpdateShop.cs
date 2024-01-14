namespace Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;

public class FormUpdateShop
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
}