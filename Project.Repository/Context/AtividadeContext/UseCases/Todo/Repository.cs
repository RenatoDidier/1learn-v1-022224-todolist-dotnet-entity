﻿
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
        
        public async Task<List<AtividadeViewModel>>? ListarAtividadesAsync(string titulo, bool? conclusao, CancellationToken cancellationToken)
        {
            try
            {
                var consulta = await _context.Atividades
                    .Where(a => (string.IsNullOrEmpty(titulo) || a.Titulo.Contains(titulo)) &&
                            (!conclusao.HasValue || a.Conclusao == conclusao) &&
                            (a.DataExclusao == null)
                            )
                    .Select(a => new AtividadeViewModel
                    {
                        Id = a.Id,
                        Titulo = a.Titulo,
                        Conclusao = a.Conclusao
                    })
                    .AsNoTracking()
                    .ToListAsync();

                return consulta;

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<AtividadeViewModel>();
            }
        }
        public async Task<AtividadeViewModel?> CriarAtividadeAsync(string titulo, CancellationToken cancellationToken)
        {
            Atividade parametros = new Atividade();
            parametros.Titulo = titulo;
            parametros.Conclusao = false;
            parametros.DataCriacao = DateTime.Now;
            parametros.Id = Guid.NewGuid();

            await _context.Atividades.AddAsync(parametros, cancellationToken);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                AtividadeViewModel retorno = new AtividadeViewModel(parametros);

                return retorno;

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new AtividadeViewModel();
            }
        }

        public async Task<bool> EditarAtividadeAsync(Atividade atividade, CancellationToken cancellationToken)
        {
            var dadoAlterado = _context.Atividades.First(a => (a.Id == atividade.Id) && (a.DataExclusao == null));
            dadoAlterado.Titulo = atividade.Titulo ?? dadoAlterado.Titulo;
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

        public async Task<bool> ExcluirAtividadeAsync(Guid Id, CancellationToken cancellationToken)
        {
            var dadoAlterado = _context.Atividades.First(a => a.Id == Id);
            dadoAlterado.DataExclusao = DateTime.Now;

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
                            .Where(a => a.DataExclusao == null && a.Id == id)
                            .Select(a => new AtividadeViewModel
                            {
                                Id = a.Id,
                                Titulo = a.Titulo,
                                Conclusao = a.Conclusao
                            })
                            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

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
                            .Where(a => a.DataExclusao == null && a.Id == id)
                            .AnyAsync(cancellationToken: cancellationToken);

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
