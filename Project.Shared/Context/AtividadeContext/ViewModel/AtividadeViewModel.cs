using Project.Shared.Context.AtividadeContext.Entities;

namespace Project.Shared.Context.AtividadeContext.ViewModel
{
    public class AtividadeViewModel
    {
        public AtividadeViewModel()
        {
            
        }
        public AtividadeViewModel(Atividade atividade)
        {
            Id = atividade.Id;
            Titulo = atividade.Titulo;
            Conclusao = atividade.Conclusao;

        }
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public bool Conclusao { get; set; }
    }
}
