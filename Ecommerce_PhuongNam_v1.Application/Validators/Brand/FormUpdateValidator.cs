using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using FluentValidation;

namespace Ecommerce_PhuongNam_v1.Application.Validators.Brand;

public class FormUpdateValidator : AbstractValidator<FormUpdate>
{
    public FormUpdateValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("is required");

    }
}