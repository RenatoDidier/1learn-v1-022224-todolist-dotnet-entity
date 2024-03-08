
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
        
        public async Task<bool> CriarAtividadeAsync(string titulo, CancellationToken cancellationToken)
        {
            try
            {
                Atividade parametros = new Atividade();
                parametros.Titulo = titulo;
                parametros.Conclusao = false;
                parametros.DataCriacao = DateTime.Now;
                parametros.Id = Guid.NewGuid();

                var retorno = await _context.Atividades.AddAsync(parametros, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return retorno.IsKeySet;

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> EditarAtividadeAsync(Atividade atividade, CancellationToken cancellationToken)
        {
            var dadoAlterado = _context.Atividades.First(a => a.Id == atividade.Id);
            dadoAlterado.Titulo = atividade.Titulo;
            dadoAlterado.Conclusao = atividade.Conclusao;
            dadoAlterado.DataUltimaModificacao = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
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
