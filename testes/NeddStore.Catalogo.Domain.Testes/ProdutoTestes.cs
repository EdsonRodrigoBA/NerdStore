using NerdStore.Core.DomainObjects;
using System;
using Xunit;

namespace NeddStore.Catalogo.Domain.Testes
{
    public class ProdutoTestes
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarException()
        {
            var ex = Assert.Throws<DomainException>(() => new Produto(
                String.Empty, "Descrição", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem.png", new Dimensoes(1, 1, 1))
                );
            Assert.Equal("O campo nome do produto não pode esta vazio.", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto(
                "Nome", String.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem.png", new Dimensoes(1, 1, 1))
                );
            Assert.Equal("O campo descrição do produto não pode esta vazio.", ex.Message);


            ex = Assert.Throws<DomainException>(() => new Produto(
                "Nome", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem.png", new Dimensoes(1, 1, 1))
                );
            Assert.Equal("O campo valor do produto não deve ser 0", ex.Message);
        }

    }
}
