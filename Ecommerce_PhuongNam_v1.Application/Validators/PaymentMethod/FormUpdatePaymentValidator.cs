﻿using Ecommerce_PhuongNam_v1.Application.DTOs.PaymentMethod.Requests;
using FluentValidation;

namespace Ecommerce_PhuongNam_v1.Application.Validators.PaymentMethod;

public class FormUpdatePaymentValidator : AbstractValidator<FormUpdatePayment>
{
    public FormUpdatePaymentValidator()
    {
        
    }
}