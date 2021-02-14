using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojas_Proximidade
{
    public partial class FrmBuscaLojas : Form
    {
        public FrmBuscaLojas()
        {
            InitializeComponent();
        }
        //Metodo que calcula as Lojas_Proximidade mais proximas em relação ao cliente.
        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            //Verifica se os campos estão preenchidos
            if (VerificaPreenchimento())
            {
                try
                {
                    //Transformando campo do TextBox para o array
                    int[,] posicaoDoCliente = TransformaArrayPosicoes(txtPosicao.Text.Replace("[", "{").Replace("]", "}").Trim());
                    int[,] lojas = TransformaArrayPosicoes(txtLojas.Text.Replace("[", "{").Replace("]", "}").Trim());
                    int[,] plano = TransformaArrayPosicoes(txtPlano.Text.Replace("[", "{").Replace("]", "}").Trim());

                    SortedList lojasSortedList = new SortedList();
                    //Obtem lojas mais proximas
                    lojasSortedList = LojasProximas(posicaoDoCliente, lojas, plano);

                    //Verifica se os campos de plano , loja e cliente estão de acordo com as restrições
                    if (VerificaRestricoes(posicaoDoCliente, lojas, plano))
                    {
                        lbResultado.Items.Clear();

                        int i = 0;
                        foreach (DictionaryEntry item in lojasSortedList)
                        {
                            if (i < 3)
                            {
                                int[,] arrlojas = (int[,])item.Value;
                                lbResultado.Items.Add($"Loja: [{arrlojas[0, 0]},{arrlojas[0, 1]}] --> Distância: { item.Key}");
                                i++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Restrições dos parâmetros foram violadas");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Parâmetros estão com a formatação errada. Por favor corrija a formatação.");
                    return;
                }

            }
        }
        //Transforma textbox em array 
        int[,] TransformaArrayPosicoes(string parametro_posicoes)
        {
            string[] arrIndices = null;

            arrIndices = parametro_posicoes.Split('}').ToArray();
            int[,] arrRetorno = new int[arrIndices.Count() < 3 ? 1 : arrIndices.Count() - 2, 2];
            string[] arrPosicoes = new string[2];
            bool bpassou_primeira_ocorrencia = false;

            string retorno_indice;

            for (int i = 0; i < arrIndices.Length; i++)
            {
                if (arrIndices[i].Contains(","))
                {
                    if (!bpassou_primeira_ocorrencia)
                    {
                        retorno_indice = arrIndices[i].Replace("{", string.Empty);
                        bpassou_primeira_ocorrencia = true;
                    }
                    else
                    {
                        retorno_indice = arrIndices[i].Substring(1).Replace("{", string.Empty);
                    }

                    arrPosicoes = retorno_indice.Split(',').ToArray();

                    arrRetorno[i, 0] = int.Parse(arrPosicoes[0].Trim());
                    arrRetorno[i, 1] = int.Parse(arrPosicoes[1].Trim());
                }

            }
            return arrRetorno;


        }
        //Verificar preenchimento dos campos 
        bool VerificaPreenchimento()
        {
            if (string.IsNullOrEmpty(txtPosicao.Text) || (string.IsNullOrEmpty(txtPlano.Text)) || (string.IsNullOrEmpty(txtLojas.Text)))
            {
                MessageBox.Show("Campos de Posição do Cliente , Lojas e Plano devem ser informados.");
                return false;
            }
            return true;
        }
        //Verificar restrições dos campos que foram passados
        bool VerificaRestricoes(int[,] posicaoDoCliente, int[,] lojas, int[,] plano)
        {
            if (posicaoDoCliente.Length == 0 || lojas.Length == 0 || plano.Length == 0)
            {
                return false;
            }
            else if (plano[0, 0] < 0 || plano[0, 0] > 1000 || plano[0, 0] < posicaoDoCliente[0, 0] || posicaoDoCliente[0, 0] < 0)
            {
                return false;
            }
            else if (plano[0, 1] < 0 || plano[0, 1] > 1000 || plano[0, 1] < posicaoDoCliente[0, 1] || posicaoDoCliente[0, 1] < 0)
            {
                return false;
            }

            return true;
        }
        //Função que retorna lojas mais proximas
        static SortedList LojasProximas(int[,] posicaoDoCliente, int[,] lojas, int[,] plano)
        {
            int[] retorno = new int[3];
            double distancia = 0;

            SortedList lojasSortedList = new SortedList();

            for (int linha = 0; linha < lojas.GetLength(0); linha++)
            {
                distancia = Math.Sqrt(Math.Pow(posicaoDoCliente[0, 0] - lojas[linha, 0], 2) + Math.Pow(posicaoDoCliente[0, 1] - lojas[linha, 1], 2));

                int[,] item = { { lojas[linha, 0], lojas[linha, 1] } };
                lojasSortedList.Add(distancia, item);
            }

            return lojasSortedList;
        }
    }
}
