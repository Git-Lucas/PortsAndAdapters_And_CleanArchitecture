//Driven Port, que facilita a troca de frameworks, ORMs, bancos de dados, e implementação de testes (mockando os
//dados)
//Qualquer classe que implementar esta interface, estará implementando os métodos CRUD (independente do
//repositório)
using PortsAndAdapters_And_CleanArchitecture.Domain.Models;

namespace PortsAndAdapters_And_CleanArchitecture.Domain.Data
{
    public interface IContaGateway
    {
        Task CreateAsync(Conta conta);
        Task<Conta> GetAsync(string id);
        Task<List<Conta>> GetAllAsync();
        Task UpdateAsync(Conta conta);
        Task DeleteAsync(string id);
    }
}
