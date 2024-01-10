using MediatR;

namespace Ecommerce_PhuongNam_v1.Application.Features.Customer.Commands;

public class ChangeIsLock : IRequest<bool>
{
    
}

public class ChangeIsLockHandle : IRequestHandler<ChangeIsLock, bool>
{
    public Task<bool> Handle(ChangeIsLock request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}