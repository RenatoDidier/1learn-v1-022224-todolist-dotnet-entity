using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Core.Commands;

namespace Project.Tests.Commands
{
    [TestClass]
    public class AtividadeCommandTests
    {
        [TestMethod]
        [TestCategory("Command-Criar")]
        [DataRow("")]
        [DataRow("1234")]
        [DataRow("ASDLorem ipsum dolor sit amet, consectetur adipiscing elit. In condimentum erat ac ante facilisis facilisis. Nullam sed dolor ac sapien vulputate dapibus. Suspendisse eget ipsum volutpat, ultricies diam vel, iaculis nisi. Suspendisse vestibulum tristique lacus a tincidunt. Ut ut sodales nibh. Donec ut.")]
        public void Dado_um_valor_invalido_no_command_criar_deve_gerar_erro(string titulo)
        {
            var commandTeste = new CriarAtividadeCommand(titulo);

            commandTeste.ValidarRecebimentoDados();

            Assert.IsFalse(commandTeste.IsValid);
        }
        [TestMethod]
        [TestCategory("Command-Criar")]
        [DataRow("Titulo Correto")]
        public void Dado_um_valor_valido_no_command_criar_deve_prosseguir(string titulo)
        {
            var commandTeste = new CriarAtividadeCommand(titulo);

            commandTeste.ValidarRecebimentoDados();

            Assert.IsTrue(commandTeste.IsValid);
        }

        [TestMethod]
        [TestCategory("Command-Editar")]
        [DataRow(null, null, false)]
        [DataRow(null, "Teste Título", false)]
        [DataRow("Id Teste", "Test", false)]
        [DataRow("Id Teste", "ASDLorem ipsum dolor sit amet, consectetur adipiscing elit. In condimentum erat ac ante facilisis facilisis. Nullam sed dolor ac sapien vulputate dapibus. Suspendisse eget ipsum volutpat, ultricies diam vel, iaculis nisi. Suspendisse vestibulum tristique lacus a tincidunt. Ut ut sodales nibh. Donec ut.", false)]
        public void Dado_um_valor_invalido_no_command_editar_deve_gerar_erro(string? id, string? titulo, bool conclusao)
        {
            var commandTeste = new EditarAtividadeCommand(id, conclusao, titulo);

            commandTeste.ValidarRecebimentoDados();

            Assert.IsFalse(commandTeste.IsValid);
        }

        [TestMethod]
        [TestCategory("Command-Editar")]
        [DataRow("ID Teste", "Titulo Teste", false)]
        public void Dado_um_valor_valido_no_command_editar_deve_prosseguir(string id, string titulo, bool conclusao)
        {
            var commandTeste = new EditarAtividadeCommand(id, conclusao, titulo);

            commandTeste.ValidarRecebimentoDados();

            Assert.IsTrue(commandTeste.IsValid);
        }

        [TestMethod]
        [TestCategory("Command-Excluir")]
        [DataRow("")]
        [DataRow(null)]
        public void Dado_um_valor_invalido_no_command_excluir_deve_gerar_erro(string id)
        {
            var commandTest = new ExcluirAtividadeCommand(id);

            commandTest.ValidarRecebimentoDados();

            Assert.IsFalse(commandTest.IsValid);
        }

    }
}
