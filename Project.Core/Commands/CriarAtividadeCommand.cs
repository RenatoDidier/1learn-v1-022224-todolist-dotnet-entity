
using Flunt.Notifications;
using Flunt.Validations;
using Project.Shared.Context.AtividadeContext.Commands.Contracts;
using System.Diagnostics.Contracts;

namespace Project.Core.Commands
{
    public class CriarAtividadeCommand : Notifiable<Notification>, ICommand
    {
        public CriarAtividadeCommand(string titulo)
        {
            Titulo = titulo;
        }
        public string Titulo { get; set; }

        public void ValidarRecebimentoDados()
        {
            AddNotifications(
                    new Contract<CriarAtividadeCommand>()
                        .Requires()
                        .IsGreaterThan(Titulo.Length, 4, "Titulo", "A atividade precisa ter, no mínimo, 4 caracteres")
                        .IsLowerOrEqualsThan(Titulo.Length, 300, "Titulo", "A atividade precisa ter, no máximo, 300 caracteres")
                );
        }
    }
}
