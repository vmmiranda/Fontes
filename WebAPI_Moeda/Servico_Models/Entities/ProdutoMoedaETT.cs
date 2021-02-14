using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servico_Domain.Entities
{
    public class ProdutoMoedaETT
    {
        public string Nome_Moeda { get; set; }
        public int Id_Produto { get; set; }
        public decimal Preco { get; set; }
    }
}