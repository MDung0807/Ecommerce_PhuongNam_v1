using MediatR;
using Microsoft.AspNetCore.Http;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class UpdateAvatar : IRequest<string>
{
    public IFormFile Avatar { get; set; }
    public UpdateAvatar(IFormFile avatar) => Avatar = avatar;
}

public class UpdateAvatarHandle : IRequestHandler<UpdateAvatar, string>
{
    public Task<string> Handle(UpdateAvatar request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
} 