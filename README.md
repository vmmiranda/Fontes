# Fontes
Fontes dos códigos elaborados por mim.

Projetos:

WebAPI_Moeda

Lojas_Proximidade:

Descrição Geral:

Aplicação que calcula as lojas mais próximas em relação ao cliente.

Existe um formulário em que o usuário coloca a sua localização com a coordenada X e Y (exemplo [20,35]) , as localizações das lojas com as coordenadas delas e as coordenadas do plano então o sistema calcula as 3 lojas mais próximas em ordem de menor distância.  

Estrutura da Aplicação :

Um formulário(FrmBuscaLojas) para obter e gerar as informações desejadas.

Como funciona:

1 - Usuário coloca as informações de plano , lojas e localização atual e clica no botão Calcular .

2 - Então são verificados se oscampos foram preenchidos corretamente tanto no aspecto das restrições , quanto no aspecto de formato numérico e preenchimento com valor.

3 - Caso exista alguma inconsistência é informado ao usuário que o campo não foi preenchido de maneira correta e o usuário pode corrigir a informação.

4 - Caso esteja tudo conforme é calculado com a formula informada e são guardados cada valor numa sortedList com os valores da distancia e das coordenadas da respectiva loja.

5 - Então após percorrer as lojas são exibidas no resultado as 3 lojas mais próximas ao cliente. 
