using Ecommerce_PhuongNam_v1.Application.DTOs.Shop.Requests;
using FluentValidation;

namespace Ecommerce_PhuongNam_v1.Application.Validators.Shop;

public class FormCreateShopValidator : AbstractValidator<FormCreateShop>
{
    public FormCreateShopValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("is required")
            .Length(3, 50).WithMessage("must be between 3 and 50 characters");

        // RuleFor(x => x.DateOfBirth)
        //     .Empty();


        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("is required");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("is required")
            .Matches("^0[0-9]{9}$").WithMessage("Invalid format phoneNumber");
    }   
}