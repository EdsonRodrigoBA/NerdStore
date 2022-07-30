using NeddStore.Catalogo.Domain.Events;
using NerdStore.Core.Buss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeddStore.Catalogo.Domain
{
    class EstoqueService : IEstoqueService
    {
        private readonly IprodutoRepository _iprodutoRepository;
        private readonly IMediatrHandle _buss;

        public EstoqueService(IprodutoRepository iprodutoRepository, IMediatrHandle buss)
        {
            _iprodutoRepository = iprodutoRepository;
            _buss = buss;
        }

        public async Task<bool> DebitarEstoque(Guid produtoID, int quantidade)
        {
            var produto = await _iprodutoRepository.ObterPorId(produtoID);
            if(produto is null)
            {
                return false;
            }
            if (!produto.PossuiEstoque(quantidade))
            {
                return false;
            }
            // TODO: Parametrizar a quantidade de estoque minimo

            if(produto.QuantidadeEstoque < 10)
            {
                await _buss.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }
            produto.DebitarEstoque(quantidade);
            _iprodutoRepository.Atualizar(produto);
            return await _iprodutoRepository.unitOfWork.Commit();
        }



        public async Task<bool> ReporEstoque(Guid produtoID, int quantidade)
        {
            var produto = await _iprodutoRepository.ObterPorId(produtoID);
            if (produto is null)
            {
                return false;
            }

            _iprodutoRepository.Atualizar(produto);
            return await _iprodutoRepository.unitOfWork.Commit();
        }

        public void Dispose()
        {
            _iprodutoRepository.Dispose();
        }
    }
}
