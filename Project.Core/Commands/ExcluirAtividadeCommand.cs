using Flunt.Notifications;
using Flunt.Validations;
using Project.Shared.Context.AtividadeContext.Commands.Contracts;
using System.Diagnostics.Contracts;

namespace Project.Core.Commands
{
    public class ExcluirAtividadeCommand : Notifiable<Notification>, ICommand
    {
        public ExcluirAtividadeCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public Guid GuidId => Guid.Parse(Id);

        public void ValidarRecebimentoDados()
        {
            AddNotifications(
                    new Contract<ExcluirAtividadeCommand>()
                        .Requires()
                        .IsNotNullOrEmpty(Id, "Id")
                );
        }
    }
}
