
using Microsoft.EntityFrameworkCore;
using Project.Repository.Context.AtividadeContext.Mapping;
using Project.Shared.Context.AtividadeContext.Entities;

namespace Project.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) { }

        public DbSet<Atividade> Atividades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AtividadeMap());
        }
    }
}
