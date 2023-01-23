//Para o Clean Architechture, "Conta" é uma entidade (regra de negócio)

namespace PortsAndAdapters_And_CleanArchitecture.Domain.Models
{
    public class Conta
    {
        public string Id { get; set; }
        public double Saldo { get; set; } = 0;

        public Conta()
        {
        }

        public Conta(string identificador)
        {
            Id = identificador;
        }

        public void Creditar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException("Valor inválido.");
            Saldo += valor;
        }

        public void Debitar(double valor)
        {
            if (valor > Saldo || valor < 0)
                throw new ArgumentOutOfRangeException("Valor inválido.");
            Saldo -= valor;
        }
    }
}
