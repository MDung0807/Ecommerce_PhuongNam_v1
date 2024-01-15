using Ecommerce_PhuongNam_v1.Application.DTOs.Cart.Requests;
using FluentValidation;

namespace Ecommerce_PhuongNam_v1.Application.Validators.Cart;

public class FormAddCartValidator : AbstractValidator<FormAddCart>
{
    public FormAddCartValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("quantity must value greater than 0");
    }
}