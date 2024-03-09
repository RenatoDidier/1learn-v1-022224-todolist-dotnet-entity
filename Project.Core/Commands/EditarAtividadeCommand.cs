using Flunt.Notifications;
using Flunt.Validations;
using Project.Shared.Context.AtividadeContext.Commands.Contracts;

namespace Project.Core.Commands
{
    public class EditarAtividadeCommand : Notifiable<Notification>, ICommand
    {
        public EditarAtividadeCommand(string id, bool conclusao, string titulo = null)
        {
            Id = id;
            Titulo = titulo;
            Conclusao = conclusao;
        }
        public string Id { get; set; }
        public Guid GuidId => Guid.Parse(Id);
        public string? Titulo { get; set; }
        public bool Conclusao { get; set; }

        public void ValidarRecebimentoDados()
        {
            if (!string.IsNullOrEmpty(Titulo))
            {
                AddNotifications(
                        new Contract<EditarAtividadeCommand>()
                            .Requires()
                            .IsGreaterThan(Titulo.Length, 4, "Titulo", "A atividade precisa ter, no mínimo, 4 caracteres")
                            .IsLowerOrEqualsThan(Titulo.Length, 300, "Titulo", "A atividade precisa ter, no máximo, 300 caracteres")
                            .IsNotNull(Conclusao, "Conclusao", "A Conclusão não pode ser nula")
                            .IsNotNull(Id, "Id", "O Id não pode ser nulo")
                    );
            } else
            {
                AddNotifications(
                    new Contract<EditarAtividadeCommand>()
                        .Requires()
                        .IsNotNull(Conclusao, "Conclusao", "A Conclusão não pode ser nula")
                        .IsNotNull(Id, "Id", "O Id não pode ser nulo")
                );
            }
        }
    }
}
