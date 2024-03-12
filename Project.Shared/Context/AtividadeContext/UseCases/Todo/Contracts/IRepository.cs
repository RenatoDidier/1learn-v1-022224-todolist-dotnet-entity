using Project.Shared.Context.AtividadeContext.Commands;
using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.ViewModel;

namespace Project.Shared.Context.AtividadeContext.UseCases.Todo.Contracts
{
    public interface IRepository
    {
        Task<List<AtividadeViewModel>>? ListarAtividadesAsync(string titulo, bool? conclusao, CancellationToken cancellationToken);
        Task<AtividadeViewModel?> GetAtividadePorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ValidarAtividadePorIdAsync(Guid id, CancellationToken cancellationToken);
        Task<AtividadeViewModel> CriarAtividadeAsync(string titulo, CancellationToken cancellationToken);
        Task<bool> EditarAtividadeAsync(Atividade parametros, CancellationToken cancellationToken);
        Task<bool> ExcluirAtividadeAsync(Guid Id, CancellationToken cancellationToken);
    }
}
