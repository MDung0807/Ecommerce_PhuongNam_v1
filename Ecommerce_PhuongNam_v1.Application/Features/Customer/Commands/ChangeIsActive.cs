using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class ChangeIsActive : IRequest<bool>
{
    
}

public class ChangeIsActiveHandle : IRequestHandler<ChangeIsActive, bool>
{
    public Task<bool> Handle(ChangeIsActive request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}