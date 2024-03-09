using Microsoft.AspNetCore.Mvc;
using Project.Core.Commands;
using Project.Core.Handlers.Contracts;
using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.UseCases.Todo.Contracts;
using Project.Shared.Context.AtividadeContext.ViewModel;

namespace Project.Core.Controllers
{
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IHandler<CriarAtividadeCommand> _handlerCriarAtividade;
        private readonly IHandler<EditarAtividadeCommand> _handlerEditarAtividade;
        private readonly IHandler<ExcluirAtividadeCommand> _handlerExcluirAtividade;
        private readonly IHandler<ListarAtividadesCommand> _handlerListarAtvidades;

        public AtividadeController(
                IRepository repository,
                IHandler<CriarAtividadeCommand> handlerCriarAtividade,
                IHandler<EditarAtividadeCommand> handlerEditarAtividade,
                IHandler<ExcluirAtividadeCommand> handlerExcluirAtividade,
                IHandler<ListarAtividadesCommand> handlerListarAtividades
            )
        {
            _repository = repository;
            _handlerCriarAtividade = handlerCriarAtividade;
            _handlerEditarAtividade = handlerEditarAtividade;
            _handlerExcluirAtividade = handlerExcluirAtividade;
            _handlerListarAtvidades = handlerListarAtividades;
        }

        [HttpGet("/")]
        public string ChamarApi()
        {
            return "Está funcionando";
        }

        [HttpGet("v1/atividade/listar")]
        public async Task<CommandResult> ListarAtividadesAsync(
                [FromBody] ListarAtividadesCommand command
            )
        {
            var retorno = await _handlerListarAtvidades.Handle(command);

            return retorno;
        }

        [HttpGet("v1/atividade/listar/{id}")]
        public async Task<CommandResult> ChamarAtividadePorIdAsync(
                [FromRoute] string id
            )
        {
            Guid guidId = Guid.Parse(id);
            AtividadeViewModel? dados  = await _repository.GetAtividadePorIdAsync(guidId, new CancellationToken());

            if (dados == null)
                return new CommandResult(401, "A atividade não existe");

            var retorno = new CommandResult(dados);
            return retorno;
        }

        [HttpPut("v1/atividade/editar")]
        public async Task<CommandResult> ValidarAtividadePorIdAsync(
                [FromBody] EditarAtividadeCommand command
            )
        {

            var retorno = await _handlerEditarAtividade.Handle(command);

            return retorno;
        }

        [HttpDelete("v1/atividade/excluir")]
        public async Task<CommandResult> ExcluirAtividadeAsync(
                [FromBody] ExcluirAtividadeCommand command
            )
        {
            var retorno = await _handlerExcluirAtividade.Handle(command);

            return retorno;
        }

        [HttpPost("v1/atividade/criar")]
        public async Task<CommandResult> CriarAtividadeAsync(
                [FromBody] CriarAtividadeCommand atividade
            )
        {
            var retorno = await _handlerCriarAtividade.Handle(atividade);

            return retorno;

        }
    }
}
