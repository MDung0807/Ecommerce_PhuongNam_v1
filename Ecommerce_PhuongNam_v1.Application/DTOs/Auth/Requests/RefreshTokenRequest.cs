namespace Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;

public class RefreshTokenRequest
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string IdDeceive { get; set; }
}