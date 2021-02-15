using Servico_Domain.Entities;
using Servico_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servico_Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private List<ProdutoETT> produtos = new List<ProdutoETT>();
        private int _nextId = 1;

        public ProdutoService()
        {
            Add(new ProdutoETT { Nome = "Guaraná Antartica", Categoria = "Refrigerantes", Preco = 4.59M });
            Add(new ProdutoETT { Nome = "Suco de Laranja Prats", Categoria = "Sucos", Preco = 5.75M });
            Add(new ProdutoETT { Nome = "Mostarda Hammer", Categoria = "Condimentos", Preco = 3.90M });
            Add(new ProdutoETT { Nome = "Molho de Tomate Cepera", Categoria = "Condimentos", Preco = 2.99M });
            Add(new ProdutoETT { Nome = "Suco de Uva Aurora", Categoria = "Sucos", Preco = 6.50M });
            Add(new ProdutoETT { Nome = "Pepsi-Cola", Categoria = "Refrigerantes", Preco = 4.25M });
        }

        public ProdutoETT Add(ProdutoETT item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            produtos.Add(item);
            return item;
        }
        public ProdutoETT Detail(ProdutoETT item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            produtos.Add(item);
            return item;
        }
        public ProdutoETT Get(int id)
        {
            return produtos.Find(p => p.Id == id);
        }

        public IEnumerable<ProdutoETT> GetAll()
        {
            return produtos;
        }


    }
}
