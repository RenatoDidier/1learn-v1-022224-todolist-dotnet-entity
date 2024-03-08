
using Microsoft.EntityFrameworkCore;
using Project.Repository.Data;
using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.UseCases.Todo.Contracts;
using Project.Shared.Context.AtividadeContext.ViewModel;

namespace Project.Repository.Context.AtividadeContext.UseCases.Todo
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
            => _context = context;
        
        public async Task CriarAtividadeAsync(Atividade atividade, CancellationToken cancellationToken)
        {
            try
            {
                var testeVariavel = await _context.Atividades.AddAsync(atividade, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                Console.WriteLine("Ver debug");

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public async Task<AtividadeViewModel?> GetAtividadePorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var retorno = await _context
                            .Atividades
                            .Select(a => new AtividadeViewModel
                            {
                                Id = a.Id,
                                Titulo = a.Titulo,
                                Conclusao = a.Conclusao
                            })
                            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

                return retorno;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                AtividadeViewModel teste = new();

                return teste;

            }
        }
        public async Task<bool> ValidarAtividadePorIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var retorno = await _context
                            .Atividades
                            .AnyAsync(x => x.Id == id, cancellationToken: cancellationToken);

                return retorno;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;

            }
        }
    }
}
