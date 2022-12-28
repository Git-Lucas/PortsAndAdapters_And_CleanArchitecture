//A transferência é uma ação que envolve 2 casos: 1 - Entidade: Aplicação das regras de negócio, que manipulam
//os objetos (Domain Service); 2 - Caso de uso: vai orquestrar e ligar as regras de negócio às tecnologias (neste
//caso, vai ligar a regra de transferência entre contas, aos registros no bancos de dados)
namespace Teste
{
    [TestClass]
    public class TransferenciaServiceTeste
    {
        [TestMethod]
        public void TransfereEntreContas()
        {
            var transferenciaService = new TransferenciaService();
            var origem = new Conta("584325");
            origem.Credita(200);
            var destino = new Conta("851886");
            var valor = 100;
            transferenciaService.Transfere(origem, destino, valor);
            Assert.AreEqual(100, origem.Saldo);
            Assert.AreEqual(100, destino.Saldo);
        }
    }
}
