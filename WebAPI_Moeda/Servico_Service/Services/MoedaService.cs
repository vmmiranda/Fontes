using System;
using System.Collections.Generic;
using System.Text;
using Servico_Domain.Entities;
using Servico_Domain.Interfaces;
using Servico_Infra.Data.Repository;

namespace Servico_Service.Services
{
    public class MoedaService : IMoedaService
    {
        public List<ProdutoMoedaETT> CalcularOutrasMoedas(ProdutoETT item_Produto)
        {
            List<MoedaETT> lstMoedas = new List<MoedaETT>();
            List<ProdutoMoedaETT> lstProdutoMoedas = new List<ProdutoMoedaETT>();
         
            MoedaRepositorio objMoedaRepositorio = new MoedaRepositorio();
            lstMoedas = objMoedaRepositorio.ObterRelacoesMoedas();

            foreach (MoedaETT item in lstMoedas)
            {

                lstProdutoMoedas.Add(new ProdutoMoedaETT
                {
                    Id_Produto = item_Produto.Id,
                    Nome_Moeda = item.Nome,
                    Preco = Math.Round(item_Produto.Preco / decimal.Parse(item.Taxa_Venda.ToString()), 2)
                });
            }

            return lstProdutoMoedas;
        }
    }
}
