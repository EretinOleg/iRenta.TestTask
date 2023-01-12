using MediatR;

namespace iRenta.TestTask.Application.Contracts.Messaging;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
{
}
