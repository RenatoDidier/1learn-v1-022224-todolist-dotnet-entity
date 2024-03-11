using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Core.Commands;
using Project.Core.Handlers;
using Project.Shared.Context.AtividadeContext.UseCases.Todo.Contracts;
using Project.Tests.Repository;

namespace Project.Tests.Handlers
{
    [TestClass]
    public class AtividadeHandlerTests
    {
        private readonly IRepository _repository;
        private readonly AtividadeHandler _handler;
        public AtividadeHandlerTests()
        {
            _repository = new FakeAtividadeRepository();
            _handler = new AtividadeHandler(_repository);
        }

        [TestMethod]
        [TestCategory("Handler-criar")]
        [DataRow("")]
        public void Dado_um_valor_invalido_no_handler_de_criar_atividade_deve_gerar_erro(string titulo)
        {
            var command = new CriarAtividadeCommand(titulo);

            var resultadoTeste = _handler.Handle(command);

            Assert.AreEqual(400, resultadoTeste.Result.Status);
        }

        [TestMethod]
        [TestCategory("Handler-criar")]
        [DataRow("Titulo Válido")]
        public void Dado_um_valor_valido_no_handler_de_criar_atividade_deve_prosseguir(string titulo)
        {
            var command = new CriarAtividadeCommand(titulo);

            var resultadoTeste = _handler.Handle(command);

            Assert.AreEqual(201, resultadoTeste.Result.Status);
        }

        [TestMethod]
        [TestCategory("Handler-editar")]
        [DataRow("f0c2567b-9360-4ef2-8a11-f7c3dd8cab14", "Titulo válido", false)]
        public void Dado_um_valor_invalido_no_handler_de_editar_atividade_deve_gerar_erro(string id, string titulo, bool conclusao)
        {
            var command = new EditarAtividadeCommand(id, conclusao, titulo);

            var resultadoTeste = _handler.Handle(command);

            Assert.AreEqual(400, resultadoTeste.Result.Status);
        }

        [TestMethod]
        [TestCategory("Handler-editar")]
        [DataRow("f0c2567b-9360-4ef2-8a11-f7c3dd8cab15", "Titulo válido", false)]
        public void Dado_um_valor_valido_no_handler_de_editar_atividade_deve_prosseguir(string id, string titulo, bool conclusao)
        {
            var command = new EditarAtividadeCommand(id, conclusao, titulo);

            var resultadoTeste = _handler.Handle(command);

            Assert.AreEqual(201, resultadoTeste.Result.Status);
        }

        [TestMethod]
        [TestCategory("Handler-excluir")]
        [DataRow("f0c2567b-9360-4ef2-8a11-f7c3dd8cab14")]
        public void Dado_um_valor_invalido_no_handler_de_excluir_atividade_deve_gerar_erro(string id)
        {
            var command = new ExcluirAtividadeCommand(id);

            var resultadoTeste = _handler.Handle(command);

            Assert.AreEqual(401, resultadoTeste.Result.Status);
        }

        [TestMethod]
        [TestCategory("Handler-excluir")]
        [DataRow("f0c2567b-9360-4ef2-8a11-f7c3dd8cab15")]
        public void Dado_um_valor_valido_no_handler_de_excluir_atividade_deve_prosseguir(string id)
        {
            var command = new ExcluirAtividadeCommand(id);

            var resultadoTeste = _handler.Handle(command);

            Assert.AreEqual(201, resultadoTeste.Result.Status);
        }
    }
}
