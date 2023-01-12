using MediatR;

namespace iRenta.TestTask.Application.Contracts.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
