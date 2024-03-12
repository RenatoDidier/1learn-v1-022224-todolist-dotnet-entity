using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.UseCases.Todo.Contracts;
using Project.Shared.Context.AtividadeContext.ViewModel;

namespace Project.Tests.Repository
{
    public class FakeAtividadeRepository : IRepository
    {
        public Task<AtividadeViewModel> CriarAtividadeAsync(string titulo, CancellationToken cancellationToken)
        {
            if (titulo == null)
            {
                var atividade = new AtividadeViewModel();
                atividade.Id = Guid.NewGuid();
                atividade.Titulo = "Retorno Atividade";
                atividade.Conclusao = false;
                return Task.FromResult(atividade);

            }

            return Task.FromResult(new AtividadeViewModel());
        }

        public Task<bool> EditarAtividadeAsync(Atividade parametros, CancellationToken cancellationToken)
        {
            Guid idValid = Guid.Parse("f0c2567b-9360-4ef2-8a11-f7c3dd8cab15");
            if (Guid.Equals(idValid, parametros.Id))
                return Task.FromResult(true);

            return Task.FromResult(false);
        }

        public Task<bool> ExcluirAtividadeAsync(Guid Id, CancellationToken cancellationToken)
        {
            Guid idValid = Guid.Parse("f0c2567b-9360-4ef2-8a11-f7c3dd8cab15");
            if (Guid.Equals(idValid, Id))
                return Task.FromResult(true);

            return Task.FromResult(false);
        }

        public Task<AtividadeViewModel?> GetAtividadePorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            AtividadeViewModel? result = null;

            var stringId = id.ToString();
            if (string.Equals(stringId, "IdValido"))
            {
                result = new AtividadeViewModel();
                result.Id = id;
                result.Titulo = "Atividade Fake criada";
                result.Conclusao = false;
                return Task.FromResult(result);
            }

            return Task.FromResult(result);

        }

        public Task<List<AtividadeViewModel>>? ListarAtividadesAsync(string titulo, bool? conclusao, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidarAtividadePorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var stringId = id.ToString();

            if (string.Equals(stringId, "f0c2567b-9360-4ef2-8a11-f7c3dd8cab15"))
                return Task.FromResult(true);

            return Task.FromResult(false);
        }
    }
}
