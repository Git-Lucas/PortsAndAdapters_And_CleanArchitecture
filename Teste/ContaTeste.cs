using PortsAndAdapters_And_CleanArchitecture.Domain.Models;

namespace Teste
{
    [TestClass]
    public class ContaTeste
    {
        [TestMethod]
        public void CriaUmaConta()
        {
            Conta conta = new Conta("587952");
            Assert.AreEqual(0, conta.Saldo);
        }

        [TestMethod]
        public void CreditaUmaConta()
        {
            Conta conta = new Conta("587952");
            conta.Credita(100);
            Assert.AreEqual(100, conta.Saldo);
        }

        [TestMethod]
        public void CreditaUmaContaComValorNegativo()
        {
            Conta conta = new Conta("587952");
            try
            {
                conta.Credita(-100);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Valor inválido.");
                return;
            }

            Assert.Fail("A exceção não foi gerada. O teste falhou.");
        }

        [TestMethod]
        public void DebitaUmaContaComValorNegativo()
        {
            Conta conta = new Conta("587952");
            try
            {
                conta.Debita(-100);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Valor inválido.");
                return;
            }

            Assert.Fail("A exceção não foi gerada. O teste falhou.");
        }

        [TestMethod]
        public void DebitaUmaContaComValorMaiorQueOSaldo()
        {
            Conta conta = new Conta("587952");
            try
            {
                conta.Debita(conta.Saldo+1);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Valor inválido.");
                return;
            }

            Assert.Fail("A exceção não foi gerada. O teste falhou.");
        }

        [TestMethod]
        public void DebitaUmaConta()
        {
            Conta conta = new Conta("587952");
            conta.Credita(100);
            conta.Debita(50);
            Assert.AreEqual(50, conta.Saldo);
        }
    }
}