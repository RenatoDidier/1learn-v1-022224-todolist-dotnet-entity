using Project.Shared.Context.AtividadeContext.Commands;
using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.ViewModel;

namespace Project.Shared.Context.AtividadeContext.UseCases.Todo.Contracts
{
    public interface IRepository
    {
        Task<AtividadeViewModel?> GetAtividadePorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ValidarAtividadePorIdAsync(Guid id, CancellationToken cancellationToken);
        Task CriarAtividadeAsync(Atividade atividade, CancellationToken cancellationToken);
    }
}
