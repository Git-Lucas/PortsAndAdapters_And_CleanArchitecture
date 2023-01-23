namespace Teste
{
    [TestClass]
    public class TransferenciaUseCaseTest
    {
        [TestMethod]
        public async Task TransfereEntreContasMemoria()
        {
            var contaGateway = new ContaGatewayMemoria();
            var transferenciaUseCase = new TransferenciaUseCase(contaGateway);
            var origem = new Conta("548976");
            var destino = new Conta("987654");
            origem.Creditar(100);
            await contaGateway.CreateAsync(origem);
            await contaGateway.CreateAsync(destino);
            await transferenciaUseCase.Transferir("548976", "987654", 50);
            origem = await contaGateway.GetAsync("548976");
            destino = await contaGateway.GetAsync("987654");
            Assert.AreEqual(50, origem.Saldo);
            Assert.AreEqual(50, destino.Saldo);
        }

        [TestMethod]
        public async Task TransfereEntreContasSqlite()
        {
            var contaGateway = new ContaGatewayEfSqlite(new EfSqliteAdapter());
            var transferenciaUseCase = new TransferenciaUseCase(contaGateway);
            var origem = new Conta("548976");
            var destino = new Conta("987654");
            origem.Creditar(100);
            await contaGateway.CreateAsync(origem);
            await contaGateway.CreateAsync(destino);
            await transferenciaUseCase.Transferir("548976", "987654", 50);
            origem = await contaGateway.GetAsync("548976");
            destino = await contaGateway.GetAsync("987654");
            Assert.AreEqual(50, origem.Saldo);
            Assert.AreEqual(50, destino.Saldo);
        }
    }
}
