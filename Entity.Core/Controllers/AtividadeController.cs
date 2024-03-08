using Microsoft.AspNetCore.Mvc;
using Project.Shared.Context.AtividadeContext.Commands;
using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.UseCases.Todo.Contracts;
using Project.Shared.Context.AtividadeContext.ViewModel;

namespace Project.Core.Controllers
{
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        public readonly IRepository _repository;

        public AtividadeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/")]
        public string ChamarApi()
        {
            return "Está funcionando";
        }

        [HttpGet("v1/atividade/listar/{id}")]
        public async Task<AtividadeViewModel?> ChamarAtividadePorIdAsync(
                [FromRoute] string id
            )
        {
            Guid guidId = Guid.Parse(id);

            var variavelTeste = await _repository.GetAtividadePorIdAsync(guidId, new CancellationToken());
            return variavelTeste;
        }

        [HttpGet("v1/atividade/validar/{id}")]
        public async Task<bool> ValidarAtividadePorIdAsync(
                [FromRoute] string id
            )
        {
            Guid guidId = Guid.Parse(id);

            var variavelTeste = await _repository.ValidarAtividadePorIdAsync(guidId, new CancellationToken());

            return variavelTeste;
        }

        [HttpPost("v1/atividade/criar")]
        public async Task<string> CriarAtividadeAsync(
                [FromBody] CriarAtividadeCommand atividade
            )
        {
            Atividade novaAtividade = new();
            novaAtividade.Titulo = atividade.Titulo;
            novaAtividade.Id = Guid.NewGuid();
            novaAtividade.DataCriacao = DateTime.Now;
            novaAtividade.Conclusao = false;

            await _repository.CriarAtividadeAsync(novaAtividade, new CancellationToken());

            return "Teste para ver";

        }
    }
}
