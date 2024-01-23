﻿namespace Ecommerce_PhuongNam_v1.Application.DTOs.Customer.Responses
{
    public class CustomerResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public int Status { get; set; }
        public string Rank { get; set; }
        public int WardId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
