﻿
using Ecommerce_PhuongNam_v1.Application.DTOs.Address.Responses;

namespace Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses
{
    public class ProfileResponse
    {
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreate { get; set; }
        public string RoleName { get; set; }
        public string Username { get; set; }
        public string Rank { get; set; }
        public long WardId { get; set; }
        public AddressResponse AddressResponse { get; set; }
    }
}
