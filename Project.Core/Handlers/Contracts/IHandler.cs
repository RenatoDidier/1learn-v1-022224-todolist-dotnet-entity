using Project.Core.Commands;
using Project.Shared.Context.AtividadeContext.Commands.Contracts;

namespace Project.Core.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<CommandResult> Handle(T command);
    }
}
