using Ecommerce_PhuongNam_v1.Application.DTOs.Order.Requests;
using FluentValidation;

namespace Ecommerce_PhuongNam_v1.Application.Validators.Order;

public class OrderItemRequestValidator : AbstractValidator<OrderItemRequest>
{
    public OrderItemRequestValidator()
    {
        
    }
}