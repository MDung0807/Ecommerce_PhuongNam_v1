﻿namespace BusBookTicket.CustomerManage.DTOs.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }
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
    }
}
