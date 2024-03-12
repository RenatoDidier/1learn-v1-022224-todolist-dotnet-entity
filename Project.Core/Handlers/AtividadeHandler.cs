using Project.Core.Commands;
using Project.Core.Handlers.Contracts;
using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.UseCases.Todo.Contracts;
using Project.Shared.Context.AtividadeContext.ViewModel;

namespace Project.Core.Handlers
{
    public class AtividadeHandler
        : IHandler<CriarAtividadeCommand>,
            IHandler<EditarAtividadeCommand>,
            IHandler<ExcluirAtividadeCommand>,
            IHandler<ListarAtividadesCommand>
    {
        public readonly IRepository _repository;
        public AtividadeHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<CommandResult> Handle(CriarAtividadeCommand command)
        {

            command.ValidarRecebimentoDados();

            if (!command.IsValid)
                return new CommandResult(400, command.Notifications);

            try
            {
                var retorno = await _repository.CriarAtividadeAsync(command.Titulo, new CancellationToken());

                return new CommandResult(retorno);


            } catch
            {
                return new CommandResult(500, "Problema interno para acessar o banco");
            }
        }

        public async Task<CommandResult> Handle(EditarAtividadeCommand command)
        {
            command.ValidarRecebimentoDados();

            if (!command.IsValid)
                return new CommandResult(400, command.Notifications);

            try
            {
                var validarExistenciaAtividade = await _repository.ValidarAtividadePorIdAsync(command.GuidId, new CancellationToken());

                if (!validarExistenciaAtividade)
                    return new CommandResult(400, "Problema ao editar atividade");

            } catch
            {
                return new CommandResult(500, "Problema ao acessar o banco");
            }

            try
            {
                Atividade parametros = new Atividade();
                parametros.Id = command.GuidId;
                parametros.Titulo = command.Titulo;
                parametros.Conclusao = command.Conclusao;
                parametros.DataUltimaModificacao = DateTime.Now;

                var resultado = await _repository.EditarAtividadeAsync(parametros, new CancellationToken());

                if (!resultado)
                    return new CommandResult(400, "Problema ao editar atividade");

                return new CommandResult("Atividade alterada com sucesso");
            } catch
            {
                return new CommandResult(500, "Problema ao consultar o banco");
            }

        }

        public async Task<CommandResult> Handle(ExcluirAtividadeCommand command)
        {
            command.ValidarRecebimentoDados();

            if (!command.IsValid)
                return new CommandResult(401, "Erro ao consultar atividade");

            try
            {
                var resposta = await _repository.ExcluirAtividadeAsync(command.GuidId, new CancellationToken());

                if (!resposta)
                    return new CommandResult(401, "Ocorreu um problema ao excluir a atividade");

                return new CommandResult("Atividade excluída com sucesso");
            } catch
            {
                return new CommandResult(500, "Erro para acessar ao banco");
            }
        }

        public async Task<CommandResult> Handle(ListarAtividadesCommand command)
        {
            try
            {
                List<AtividadeViewModel>? resultado = await _repository.ListarAtividadesAsync(command.Titulo, command.Conclusao, new CancellationToken());

                 return new CommandResult(resultado);
            } catch
            {
                return new CommandResult(500, "Problema para acessar ao banco");
            }
        }
    }
}
