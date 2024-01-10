﻿using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using FluentValidation;

namespace Ecommerce_PhuongNam_v1.Application.Specifications.Auth;

public class AuthRequestValidator : AbstractValidator<AuthRequest>
{
    public AuthRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("is required")
            .Length(4, 50).WithMessage("must be between 4 and 50 characters");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("is required")
            .Matches("[A-Z]").WithMessage("must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("must contain at least one numeric digit")
            .Matches("[!@#$%^&*(),.?\":{}|<>]")
            .WithMessage("must contain at least one special character (!@#$%^&*(),.?\":{}|<>)");
    }
}