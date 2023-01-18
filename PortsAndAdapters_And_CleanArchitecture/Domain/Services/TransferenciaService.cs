//A transferência é uma ação que envolve 2 casos: 1 - Entidade: Aplicação das regras de negócio, que manipulam
//os objetos (Domain Service); 2 - Caso de uso: vai orquestrar e ligar as regras de negócio às tecnologias (neste
//caso, vai ligar a regra de transferência entre contas, aos registros no bancos de dados)
using PortsAndAdapters_And_CleanArchitecture.Domain.Models;

namespace PortsAndAdapters_And_CleanArchitecture.Domain.Services
{
    public class TransferenciaService
    {
        public void Transfere(Conta origem, Conta destino, double valor)
        {
            origem.Debita(valor);
            destino.Credita(valor);
        }
    }
}
