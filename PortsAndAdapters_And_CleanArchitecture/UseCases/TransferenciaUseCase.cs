//A transferência é uma ação que envolve 2 casos: 1 - Entidade: Aplicação das regras de negócio, que manipulam
//os objetos (Domain Service); 2 - Caso de uso: vai orquestrar e ligar as regras de negócio às tecnologias (neste
//caso, vai ligar a regra de transferência entre contas, aos registros no bancos de dados)
using PortsAndAdapters_And_CleanArchitecture.Data;
using PortsAndAdapters_And_CleanArchitecture.Services;

namespace PortsAndAdapters_And_CleanArchitecture.UseCases
{
    public class TransferenciaUseCase
    {
        private readonly IContaGateway _contaGateway;
        private readonly TransferenciaService _transferenciaService = new TransferenciaService();

        public TransferenciaUseCase(IContaGateway contaGateway)
        {
            _contaGateway = contaGateway;
        }

        //O caso de uso não irá manipular objetos, mas delegar essa responsabilidade para os objetos Domain
        //Service e para a instância de banco de dados.
        //No caso de qualquer alteração na tabela ou na entidade "Conta", este intermediador não sofreria
        //efeitos colaterais, pelo fato de estar apenas interligando os serviços de domínio ao core da aplicação
        public async Task<bool> Executar(string idOrigem, string idDestino, double valor)
        {
            var origem = await _contaGateway.GetAsync(idOrigem);
            var destino = await _contaGateway.GetAsync(idDestino);
            _transferenciaService.Transfere(origem, destino, valor);
            await _contaGateway.UpdateAsync(origem);
            await _contaGateway.UpdateAsync(destino);
            return true;
        }
    }
}
