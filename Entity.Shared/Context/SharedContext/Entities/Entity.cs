namespace Project.Shared.Context.SharedContext.Entities
{
    public abstract class Entity : IEquatable<Guid>
    {
        protected Entity() => Id= Guid.NewGuid();

        public Guid Id { get; set; }
        public bool Equals(Guid id) => Id == id;
    }
}
