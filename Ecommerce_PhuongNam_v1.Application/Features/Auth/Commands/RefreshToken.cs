using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Responses;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Auth.Commands;

public class RefreshToken : RefreshTokenRequest , IRequest<AuthResponse>
{
    
}

public class RefreshTokenHandle : IRequestHandler<RefreshToken, AuthResponse>
{
    public Task<AuthResponse> Handle(RefreshToken request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}