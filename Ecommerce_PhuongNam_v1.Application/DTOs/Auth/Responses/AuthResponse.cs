namespace Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses
{
    public class AuthResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string RoleName { get; set; }
        public string Type { get; set; }
        public string Avatar { get; set; }
        public string RefreshToken { get; set; }

        public AuthResponse(Guid userID, string username, string token, string role)
        {
            this.Id = userID;
            this.Username = username;
            this.Token = token;
            this.RoleName = role;
            this.Type = "Bearer";
        }

        public AuthResponse() 
        {
            this.Type = "Bearer";
        }
    }
}
