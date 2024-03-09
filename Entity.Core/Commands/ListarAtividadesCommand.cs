using Project.Shared.Context.AtividadeContext.Commands.Contracts;

namespace Project.Core.Commands
{
    public class ListarAtividadesCommand : ICommand
    {

        private string _titulo;
        public string Titulo {
            get { return _titulo ?? string.Empty; }
            set { _titulo = value; } }
        public bool? Conclusao { get; set; }

        public void ValidarRecebimentoDados()
        {
            
        }
    }
}
