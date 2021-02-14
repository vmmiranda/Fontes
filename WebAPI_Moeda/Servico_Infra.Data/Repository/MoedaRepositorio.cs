using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;



using Servico_Domain.Entities;

namespace Servico_Infra.Data.Repository
{
   public class MoedaRepositorio
    {
        public List<MoedaETT> ObterRelacoesMoedas()
        {
            string conexao = @"Server=tcp:serv002.database.windows.net,1433;Initial Catalog=dbViagem;Persist Security Info=False;User ID=dbvitu;Password=vV963852;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";
            string selectQuery = @"SELECT   im.Cod_Moeda
			                                ,Tipo
			                                ,im.Moeda
			                                ,Taxa_Compra
			                                ,Taxa_Venda
			                                ,Paridade_Compra
			                                ,Paridade_Venda
	                                  FROM dbo.Informacoes_Moedas as im
                                inner join dbo.Moedas_Conversao as mc on mc.Cod_Moeda = im.Cod_Moeda";

            List<MoedaETT> lst_Moedas = new List<MoedaETT>();

            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    //open connection
                    connection.Open();

                    SqlCommand command = new SqlCommand(selectQuery, connection);

                    command.Connection = connection;
                    command.CommandText = selectQuery;
                    var result = command.ExecuteReader();

                    while (result.Read())
                    {
                        lst_Moedas.Add(new MoedaETT { Id = (int)result["Cod_Moeda"], Tipo_Moeda = (string)result["Tipo"], Nome = (string)result["Moeda"], Taxa_Compra = (double)result["Taxa_Compra"], Taxa_Venda = (double)result["Taxa_Venda"], Paridade_Compra = (double)result["Paridade_Compra"], Paridade_Venda = (double)result["Paridade_Venda"] });
                    }

                    connection.Close();

                    return lst_Moedas;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
