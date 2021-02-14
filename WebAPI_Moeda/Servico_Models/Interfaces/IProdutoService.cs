using Servico_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico_Domain.Interfaces
{
   public interface IProdutoService
    {
            IEnumerable<ProdutoETT> GetAll();
            ProdutoETT Get(int id);
            ProdutoETT Detail(ProdutoETT item);           
      
    }
}
