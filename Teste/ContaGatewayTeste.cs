namespace Teste
{
    [TestClass]
    public class ContaGatewayTeste
    {
        [TestMethod]
        public async Task AtualizaUmaContaMemoria()
        {
            var contaGateway = new ContaGatewayMemoria();
            var conta = new Conta("543126");
            await contaGateway.CreateAsync(conta);
            conta = await contaGateway.GetAsync(conta.Id);
            conta.Creditar(50);
            await contaGateway.UpdateAsync(conta);
            var contaAtualizada = await contaGateway.GetAsync(conta.Id);
            Assert.AreEqual(50, contaAtualizada.Saldo);
        }

        [TestMethod]
        public async Task AtualizaUmaContaSqlite()
        {
            var contaGateway = new ContaGatewayEfSqlite(new EfSqliteAdapter());
            var conta = new Conta("543126");
            await contaGateway.CreateAsync(conta);
            conta = await contaGateway.GetAsync(conta.Id);
            conta.Creditar(50);
            await contaGateway.UpdateAsync(conta);
            var contaAtualizada = await contaGateway.GetAsync(conta.Id);
            Assert.AreEqual(50, contaAtualizada.Saldo);
        }

        [TestMethod]
        public async Task DeletaUmaContaMemoria()
        {
            var contaGateway = new ContaGatewayMemoria();
            var conta = new Conta("257895");
            await contaGateway.CreateAsync(conta);
            conta = await contaGateway.GetAsync("257895");
            await contaGateway.DeleteAsync(conta.Id);
            try
            {
                conta = await contaGateway.GetAsync("257895");
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Não encontrado.");
                return;
            }

            Assert.Fail("A exceção não foi gerada. O teste falhou.");
        }

        [TestMethod]
        public async Task DeletaUmaContaSqlite()
        {
            var contaGateway = new ContaGatewayEfSqlite(new EfSqliteAdapter());
            var conta = new Conta("257895");
            await contaGateway.CreateAsync(conta);
            conta = await contaGateway.GetAsync("257895");
            await contaGateway.DeleteAsync(conta.Id);
            try
            {
                conta = await contaGateway.GetAsync("257895");
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Não encontrado.");
                return;
            }

            Assert.Fail("A exceção não foi gerada. O teste falhou.");
        }
    }
}
