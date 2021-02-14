using Servico_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servico_Domain.Interfaces
{
    public interface IMoedaService
    {
        //IEnumerable<Moeda> GetAll();
        //Moeda Get(int id);
        //IEnumerable<Moeda> GetAllConversao();
        //IEnumerable<Produto_Moeda> CalcularOutrasMoedas(Moeda item);
        List<ProdutoMoedaETT> CalcularOutrasMoedas(ProdutoETT item_Produto);


    }
}
