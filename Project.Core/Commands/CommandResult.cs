using Flunt.Notifications;
using Project.Core.UseCases;
using Project.Shared.Context.AtividadeContext.Commands.Contracts;
using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.ViewModel;

namespace Project.Core.Commands
{
    public class CommandResult : Resposta, ICommandResult
    {
        public CommandResult()
        {
            
        }
        public CommandResult(string mensagem)
        {
            Mensagem = mensagem;
            Status = 201;
            Notificacoes = null;
        }
        public CommandResult(int status, IEnumerable<Notification>? notificacoes = null)
        {
            Status = status;
            Notificacoes = notificacoes;
        }
        public CommandResult(int status, string mensagem)
        {
            Mensagem = mensagem;
            Status = status;
            Notificacoes = null;
        }

        public CommandResult(AtividadeViewModel? atividade)
        {
            ObjetoDado = atividade;
            Status = 201;
            Notificacoes = null;
        }

        public CommandResult(Atividade? atividade)
        {
            ObjetoDado2 = atividade;
            Status = 201;
            Notificacoes = null;
        }

        public CommandResult(List<AtividadeViewModel>? atividades)
        {
            ListaDado = atividades;
            Status = 201;
            Notificacoes = null;
        }
    }
}
