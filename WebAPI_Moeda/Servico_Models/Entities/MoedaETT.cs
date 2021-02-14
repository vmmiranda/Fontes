using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servico_Domain.Entities
{
    public class MoedaETT
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo_Moeda { get; set; }
        public double Preco { get; set; }
        public double Taxa_Compra { get; set; }
        public double Taxa_Venda { get; set; }
        public double Paridade_Compra { get; set; }
        public double Paridade_Venda { get; set; }
    }
}