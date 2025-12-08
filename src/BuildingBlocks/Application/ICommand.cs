using MediatR;

namespace Hababk.BuildingBlocks.Application;

public interface ICommand<out TResult> : IRequest<TResult>
{
    
}

