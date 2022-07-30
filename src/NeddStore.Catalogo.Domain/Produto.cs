using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeddStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public String Nome { get; private set; }
        public String Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public Guid CategoriaId { get; private set; }

        public DateTime  DataCadastro { get; private set; }
        public string   Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public Categoria Categoria { get; private set; }

        public Dimensoes Dimensoes { get; private set; }


        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;
            Dimensoes = dimensoes;
            Validar();
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id; 
        }
        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            QuantidadeEstoque -= quantidade; 
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome do produto não pode esta vazio.");
            Validacoes.ValidarSeVazio(Descricao, "O campo descrição do produto não pode esta vazio.");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode esta vazio.");

            Validacoes.ValidaSeDiferente(CategoriaId, Guid.Empty, "O campo categoria do produto não pode esta vazio.");
            Validacoes.ValidarSeMenorQueMinimo(Valor, 1, "O campo valor do produto não deve ser 0");


        }
    }
}
