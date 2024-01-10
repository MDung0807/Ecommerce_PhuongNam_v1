using Ecommerce_PhuongNam_v1.Application.DTOs.Auth.Requests;
using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Auth.Commands;

public class ResetPassword : FormResetPass, IRequest<bool>
{
    
}

public class ResetPasswordHandle : IRequestHandler<ResetPassword, bool>
{
    public Task<bool> Handle(ResetPassword request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}