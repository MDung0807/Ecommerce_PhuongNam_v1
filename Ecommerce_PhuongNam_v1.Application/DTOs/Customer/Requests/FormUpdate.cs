﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Requests
{
    [ValidateNever]
    public class FormUpdate
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public long WardId { get; set; }
    }
}
