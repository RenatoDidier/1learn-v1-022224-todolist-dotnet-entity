﻿using Project.Core.Commands;
using Project.Core.Handlers.Contracts;
using Project.Shared.Context.AtividadeContext.Entities;
using Project.Shared.Context.AtividadeContext.UseCases.Todo.Contracts;

namespace Project.Core.Handlers
{
    public class AtividadeHandler
        : IHandler<CriarAtividadeCommand>,
            IHandler<EditarAtividadeCommand>
    {
        public readonly IRepository _repository;
        public AtividadeHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<CommandResult> Handle(CriarAtividadeCommand command)
        {

            command.ValidarRecebimentoDados();

            if (!command.IsValid)
                return new CommandResult(400, command.Notifications);

            try
            {
                var retorno = await _repository.CriarAtividadeAsync(command.Titulo, new CancellationToken());

                if (!retorno)
                    return new CommandResult(400, "Não foi possível cadastrar a sua atividade");

                return new CommandResult("Atividade criada com sucesso");

            } catch
            {
                return new CommandResult(500, "Problema interno para acessar o banco");
            }
        }

        public async Task<CommandResult> Handle(EditarAtividadeCommand command)
        {
            command.ValidarRecebimentoDados();

            if (!command.IsValid)
                return new CommandResult(400, command.Notifications);

            try
            {
                var validarExistenciaAtividade = await _repository.ValidarAtividadePorIdAsync(command.GuidId, new CancellationToken());

                if (!validarExistenciaAtividade)
                    return new CommandResult(400, "Problema ao editar atividade");
            } catch
            {
                return new CommandResult(500, "Problema ao acessar o banco");
            }

            try
            {
                Atividade parametros = new Atividade();
                parametros.Id = command.GuidId;
                parametros.Titulo = command.Titulo;
                parametros.Conclusao = command.Conclusao;
                parametros.DataUltimaModificacao = DateTime.Now;

                var resultado = await _repository.EditarAtividadeAsync(parametros, new CancellationToken());

                if (!resultado)
                    return new CommandResult(400, "Problema ao editar atividade");

                return new CommandResult(parametros);
            } catch
            {
                return new CommandResult(500, "Problema ao consultar o banco");
            }

        }


    }
}
