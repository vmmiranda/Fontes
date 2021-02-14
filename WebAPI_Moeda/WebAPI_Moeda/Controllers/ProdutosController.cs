using Servico_Domain.Entities;
using Servico_Domain.Interfaces;
using Servico_Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Servicos.Models;

namespace WebAPI_Servicos.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : ApiController
    {
        static readonly IProdutoService repositorio = new ProdutoService();

        /// <summary>
        /// Método que obtêm os produtos cadastrados na base.
        /// </summary>               
        /// <remarks>Retorna uma lista de produtos com informações de ID, Nome , Categoria e Preço</remarks>
        public HttpResponseMessage GetAllProdutos()
        {

            List<ProdutoViewModel> lstProduto = new List<ProdutoViewModel>();

            using (var ctx = new dbBaseEntities())
            {
                lstProduto = ctx.Produto
                            .Select(s => new ProdutoViewModel()
                            {
                                Id_Produto = s.Id_Produto,
                                Categoria = s.Categoria,
                                Nome = s.Nome,
                                Descricao = s.Descricao,
                                Preco = s.Preco
                            }).ToList<ProdutoViewModel>();

                if (lstProduto.Count == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não foi possivel obter os produtos.");
                }

                return Request.CreateResponse<List<ProdutoViewModel>>(HttpStatusCode.OK, lstProduto);
            }
           
        }      
             
    }
}
