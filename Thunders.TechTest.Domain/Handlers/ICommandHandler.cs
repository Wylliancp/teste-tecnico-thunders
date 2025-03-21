using Thunders.TechTest.Domain.Commands;

namespace Thunders.TechTest.Domain.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
