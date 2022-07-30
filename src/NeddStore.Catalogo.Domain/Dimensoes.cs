using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeddStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal altura { get; private set; }
        public decimal largura { get; private set; }
        public decimal profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorIgualMinimo(largura, 1, "O campo lagura não pode ser 0");
            Validacoes.ValidarSeMenorIgualMinimo(altura, 1, "O campo altura não pode ser 0");
            Validacoes.ValidarSeMenorIgualMinimo(profundidade, 1, "O campo profundidade não pode ser 0");


            this.altura = altura;
            this.largura = largura;
            this.profundidade = profundidade;
        }

        public string DescricaoFormata()
        {
            return $"LxAxP: { largura} x {altura} x {profundidade}";

        }

        public override string ToString()
        {
           return  DescricaoFormata();
        }
    }
}
