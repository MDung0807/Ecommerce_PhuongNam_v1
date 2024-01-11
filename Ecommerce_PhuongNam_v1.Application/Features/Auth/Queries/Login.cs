using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;
using Ecommerce_PhuongNam_v1.Application.Interfaces;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Auth.Queries;

public class Login :AuthRequest, IRequest<AuthResponse>
{
    
}   

public class LoginRequest : IRequestHandler<Login, AuthResponse>
{
    private readonly IAccountService _service;
    public LoginRequest(IAccountService service) => _service = service;
    public async Task<AuthResponse> Handle(Login request, CancellationToken cancellationToken)
    {
        return await _service.Login(request);
    }
}
