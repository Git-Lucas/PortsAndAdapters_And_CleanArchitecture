//Interface Adapter, que implementa os métodos exigidos na interface para manipulação dos arquivos (neste caso,
//o Interface Adapter está totalmente acoplado ao EF. Isso não é recomendado)
using Microsoft.EntityFrameworkCore;
using PortsAndAdapters_And_CleanArchitecture.Domain.Data;
using PortsAndAdapters_And_CleanArchitecture.Domain.Models;
using PortsAndAdapters_And_CleanArchitecture.Infra.EntityFramework;

namespace PortsAndAdapters_And_CleanArchitecture.Infra.Data
{
    public class ContaGatewayEfSqlite : IContaGateway
    {
        private readonly EfSqliteAdapter _context;

        public ContaGatewayEfSqlite(EfSqliteAdapter context)
        {
            _context = context;
        }

        public async Task CreateAsync(Conta conta)
        {
            var contaExistente = await _context.Contas.SingleOrDefaultAsync(x => x.Id == conta.Id);

            if (contaExistente is not null)
            {
                _context.Contas.Remove(contaExistente);
                await _context.SaveChangesAsync();
            }

            _context.Add(conta);
            await _context.SaveChangesAsync();
        }

        public async Task<Conta> GetAsync(string id)
        {
            var conta = await _context.Contas.SingleOrDefaultAsync(x => x.Id == id);

            if (conta is not null)
                return conta;
            else
                throw new Exception("Não encontrado.");
        }

        public async Task<List<Conta>> GetAllAsync()
        {
            var contas = await _context.Contas.ToListAsync();

            if (contas.Count > 0)
                return contas;
            else
                throw new Exception("A pesquisa não retornou nenhum resultado.");
        }

        public async Task UpdateAsync(Conta conta)
        {
            var contaExistente = await GetAsync(conta.Id);

            if (contaExistente is not null)
            {
                contaExistente.Saldo = conta.Saldo;
                _context.Contas.Update(contaExistente);
                await _context.SaveChangesAsync();
            }
            else
                throw new Exception("Não foi possível atualizar.");
        }

        public async Task DeleteAsync(string id)
        {
            var contaExistente = await GetAsync(id);

            if (contaExistente is not null)
            {
                _context.Contas.Remove(contaExistente);
                await _context.SaveChangesAsync();
            }
            else
                throw new Exception("Não foi possível exluir.");
        }
    }
}
