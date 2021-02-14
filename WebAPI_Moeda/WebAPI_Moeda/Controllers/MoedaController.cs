using Servico_Domain.Entities;
using Servico_Domain.Interfaces;
using Servico_Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_Servicos.Controllers
{
    
    public class MoedaController : ApiController
    {
        static readonly IMoedaService repositorio = new MoedaService();
        /// <summary>
        /// Método que converte o valor nas demais moedas cadastradas na base.
        /// </summary>  
        /// /// <remarks>
        /// Retorna uma lista de produtos com informações de ID Produto, Nome da moeda convertida e preço na moeda convertida.
        /// 
        /// Exemplo de requisição:
        ///
        ///     POST /Todo
        ///     {
        ///     "Id": 1,
        ///     "Nome": "Raquete",
        ///     "Categoria": "Tenis",
        ///     "Preco": 50.43,
        ///     "Nome_Moeda": "BRL"   
        ///     }
        ///
        /// </remarks>

    public HttpResponseMessage PostOutrasMoedas(ProdutoETT item_Produto)
        {           
            List<ProdutoMoedaETT> lstProdutoMoeda = new List<ProdutoMoedaETT>();
            lstProdutoMoeda = repositorio.CalcularOutrasMoedas(item_Produto);

            if (lstProdutoMoeda.Count == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não foi possivel converter em outras moedas.");
            }
            else
            {
                return Request.CreateResponse<List<ProdutoMoedaETT>>(HttpStatusCode.OK, lstProdutoMoeda);
            }
        }
       
    }
}
