﻿using Ecommerce_PhuongNam_v1.Application.DTOs.Brand.Requests;
using FluentValidation;

namespace Ecommerce_PhuongNam_v1.Application.Validators.Brand;

public class FormUpdateValidator : AbstractValidator<FormUpdateBrand>
{
    public FormUpdateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("is required");

    }
}