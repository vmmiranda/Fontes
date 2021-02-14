# Fontes
Fontes dos códigos elaborados por mim.

Projetos:

<b>WebAPI_Moeda</b>

Descrição Geral:

Serviço que realiza a conversão numa determinada lista de moedas baseados no valor de um produto trazendo os valores convertidos nas demais moedas para o respectivo produto. Além disso foi elaborado o serviço complementar de listar os produtos existentes na base .

Contextualizando a solução foram criadas 3 tabelas no Sql Server num servidor hospedado na nuvem e foram consumidas pelo serviço. A tabela de Produto que exibe a lista de produtos existentes onde foi criado a funcionalidade que são obtidos os produtos da base via EntityFramework.

A tabela de Informacoes_Moeda que foram carregadas as informações de paridade e taxas de conversão baseadas nas informações do banco Central  e uma tabela de Moedas_Conversão trazendo uma lista de para quais moedas as conversões serão feitas. Foi feito de maneira convencional a consulta dos dados obtendo-se as informações e para cada valor retornado é calculado a conversão da moeda do valor passado pelo produto.

Existem dois controllers o de Produto que serve para listar os produtos e o de Moeda para realizar a conversão das Moedas.


<b>Lojas_Proximidade:</b>

Descrição Geral:

Aplicação que calcula as lojas mais próximas em relação ao cliente.

Existe um formulário em que o usuário coloca a sua localização com a coordenada X e Y (exemplo [20,35]) , as localizações das lojas com as coordenadas delas e as coordenadas do plano então o sistema calcula as 3 lojas mais próximas em ordem de menor distância.  

Estrutura da Aplicação :

Um formulário(FrmBuscaLojas) para obter e gerar as informações desejadas.

Como funciona:

1 - Usuário coloca as informações de plano , lojas e localização atual e clica no botão Calcular .

2 - Então são verificados se os campos foram preenchidos corretamente tanto no aspecto das restrições , quanto no aspecto de formato numérico e preenchimento com valor.

3 - Caso exista alguma inconsistência é informado ao usuário que o campo não foi preenchido de maneira correta e o usuário pode corrigir a informação.

4 - Caso esteja tudo conforme é calculado com a formula informada e são guardados cada valor numa sortedList com os valores da distancia e das coordenadas da respectiva loja.

5 - Então após percorrer as lojas são exibidas no resultado as 3 lojas mais próximas ao cliente. 
