using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servico_Domain.Entities
{
    public class ProdutoETT
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Nome_Moeda { get; set; }
    }
}