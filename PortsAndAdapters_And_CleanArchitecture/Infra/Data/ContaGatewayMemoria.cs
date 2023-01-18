//Interface Adapter, que implementa os métodos exigidos na interface para manipulação dos arquivos (neste caso,
//implementando os dados em memória)
using PortsAndAdapters_And_CleanArchitecture.Domain.Data;
using PortsAndAdapters_And_CleanArchitecture.Domain.Models;

namespace PortsAndAdapters_And_CleanArchitecture.Infra.Data
{
    public class ContaGatewayMemoria : IContaGateway
    {
        private List<Conta> Contas { get; set; } = new List<Conta>();

        public async Task CreateAsync(Conta conta)
        {
            Contas.Add(conta);
        }

        public async Task<Conta> GetAsync(string id)
        {
            var conta = Contas.SingleOrDefault(x => x.Id == id);

            if (conta is not null)
                return conta;
            else
                throw new Exception("Não encontrado.");
        }

        public async Task<List<Conta>> GetAllAsync()
        {
            if (Contas.Count > 0)
                return Contas.ToList();
            else
                throw new Exception("A pesquisa não retornou nenhum resultado.");
        }

        public async Task<Conta> UpdateAsync(Conta conta)
        {
            var contaExistente = await GetAsync(conta.Id);

            if (conta is not null)
            {
                contaExistente.Saldo = conta.Saldo;
                return contaExistente;
            }
            else
                throw new Exception("Não foi possível atualizar.");
        }

        public async Task DeleteAsync(string id)
        {
            var conta = await GetAsync(id);
            if (conta is not null)
                Contas.Remove(conta);
            else
                throw new Exception("Não foi possível excluir.");
        }
    }
}
