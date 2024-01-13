using Ecommerce_PhuongNam_v1.Application.DTOs.Category.Requests;
using FluentValidation;

namespace Ecommerce_PhuongNam_v1.Application.Validators.Category;

public class FormCreateCateValidator : AbstractValidator<FormCreateCategory>
{
    public FormCreateCateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("is required");
    }
}