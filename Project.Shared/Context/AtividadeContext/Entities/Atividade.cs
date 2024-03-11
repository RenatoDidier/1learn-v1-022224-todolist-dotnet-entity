using Project.Shared.Context.SharedContext.Entities;

namespace Project.Shared.Context.AtividadeContext.Entities
{
    public class Atividade : Entity
    {
        public Atividade()
        {
            
        }
        public string Titulo { get; set; } = string.Empty;
        public bool Conclusao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataUltimaModificacao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
