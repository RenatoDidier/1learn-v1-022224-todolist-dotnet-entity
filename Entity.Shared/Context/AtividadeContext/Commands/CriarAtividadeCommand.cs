namespace Project.Shared.Context.AtividadeContext.Commands
{
    public class CriarAtividadeCommand
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public bool Conclusao { get; set; }
    }
}
