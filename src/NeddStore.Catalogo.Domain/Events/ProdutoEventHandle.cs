using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeddStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandle : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private IprodutoRepository _iprodutoRepository;

        public ProdutoEventHandle(IprodutoRepository iprodutoRepository)
        {
            _iprodutoRepository = iprodutoRepository;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent notification, CancellationToken cancellationToken)
        {
             var produto = await _iprodutoRepository.ObterPorId(notification.AggregateId);
            //Faz alguma coisa: enviar email
        }


    }
}
