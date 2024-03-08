using Microsoft.EntityFrameworkCore;
using Project.Repository.Data;
using Project.Shared;

namespace Project.Core.Extensions
{
    public static class BuilderExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.Database.ConnectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(
                        Configuration.Database.ConnectionString,
                        b => b.MigrationsAssembly("Project.Core")
                    );
            }, ServiceLifetime.Scoped);
        }

        public static void AddRepository(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<
                    Shared.Context.AtividadeContext.UseCases.Todo.Contracts.IRepository,
                    Repository.Context.AtividadeContext.UseCases.Todo.Repository
                >();
        }
    }
}
