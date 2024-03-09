using Flunt.Notifications;
using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.ViewModel;

namespace Project.Core.UseCases
{
    public abstract class Resposta
    {
        public string Mensagem { get; set; } = string.Empty;
        public int Status { get; set; } = 400;
        public bool HaErro => Status is < 200 or > 299;
        public IEnumerable<Notification>? Notificacoes { get; set; }
        public AtividadeViewModel? ObjetoDado { get; set; }
        public Atividade? ObjetoDado2 { get; set; }
        public List<AtividadeViewModel>? ListaDado { get; set; }
    }
}
