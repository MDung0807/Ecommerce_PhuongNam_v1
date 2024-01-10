using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Auth.Queries;

public class Login :AuthRequest, IRequest<AuthResponse>
{
    
}

public class LoginRequest : IRequestHandler<Login, AuthResponse>
{
    public Task<AuthResponse> Handle(Login request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
