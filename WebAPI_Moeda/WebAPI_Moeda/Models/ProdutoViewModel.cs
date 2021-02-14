using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Servicos.Models
{
    public class ProdutoViewModel
    {
        public int Id_Produto { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}