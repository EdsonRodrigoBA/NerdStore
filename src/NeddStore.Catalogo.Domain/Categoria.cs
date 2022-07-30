using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeddStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public String Nome { get; private set; }
        public int Codigo { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {

        }

        public Categoria(string nome, int codigo, DateTime dataCadastro)
        {
            Nome = nome;
            Codigo = codigo;
            DataCadastro = dataCadastro;
    
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo} ";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome do produto não pode esta vazio.");
            Validacoes.ValidaSeDiferente(Codigo,0, "O campo código da categoria não pode esta vazio.");


        }
    }
}
