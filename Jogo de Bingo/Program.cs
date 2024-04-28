//Declaração de variáveis
int qtdJogadores = 0, qtdCartelas = 0;
int totalLinhas = 5, totalColunas = 5;
int contNumSorteadosCartela = 1;
int numSorteado;
int indice = -1;

bool numRepetido = true;

/*
 * Vetor para armazenar os números que já foram sorteados na cartela.
 * VetorNumSorteadosParaCartela = Vetor de Números Sorteados para a Cartela
*/
int[] vetorNumSorteadosParaCartela = new int[25];

/*
 * Essa variável irá armazenar os números da cartela para o sorteio.
 * Recebe como valores máximos de dimensão, a quantidade total de linhas e o total de colunas
*/
int[,] cartelaCriada = new int[totalLinhas, totalColunas];
int[,] cartelaCriada_aux;

/*
 * Essa vairável vai atribuir na primeira matriz:
 * linha: será referente ao jogador
 * coluna: será referente à cartela
 * 
 * Na segunda matriz, poderá ser armazenada a cartela criada.
 * 
 * Assim, a cartela criada terá a referência do jogador e da cartela atribuída à esse jogador
 */
int[,][,] cartela = new int[qtdJogadores, qtdCartelas][,];

//Função para pular linha e visualizar melhor as informações impressas
void PularLinha()
{
    Console.WriteLine();
    Console.WriteLine();
}

int SortearNumCartela()
{
    contNumSorteadosCartela += 1;
    vetorNumSorteadosParaCartela = new int[contNumSorteadosCartela];
    numSorteado = new Random().Next(1, 99);
    indice += 1;
    vetorNumSorteadosParaCartela[indice] = numSorteado;

    for (int indice_aux = 0; indice_aux < contNumSorteadosCartela; indice_aux++)
    {
        numRepetido = true;
        do
        {
            if (vetorNumSorteadosParaCartela[indice_aux] != numSorteado)
            {
                numRepetido = false;
            }
            else
                numSorteado = new Random().Next(1, 99);
        } while (numRepetido);
    }

    vetorNumSorteadosParaCartela[indice] = numSorteado;

    numRepetido = true;
    return numSorteado;
}

/*
 * Função para criar a cartela, com as dimensões de 5x5 e retornar a cartela criada.
*/
int[,] CriarCartela()
{
    int contInicio = 1;
    int numSorteadoParaCartela;

    for (int linha = 0; linha < totalLinhas; linha++)
    {
        for (int coluna = 0; coluna < totalColunas; coluna++)
        {
            numSorteadoParaCartela = SortearNumCartela();
            cartelaCriada[linha, coluna] = numSorteadoParaCartela;

            /*
             * Trecho para evitar a repetição de números iguais
             * 
             * A partir do vetor de números que já foram sorteados na cartela,
             * haverá a verificação do número repetido na cartelaCriada.
             * Caso esteja repetido, o número será sorteado novamente.
             * Caso não, o sorteio do número para a tabela continuará para as outras posições da matriz.
             */

            if (contInicio != 0)
            {

                for (int indiceVetor = 0; indiceVetor < contNumSorteadosCartela; indiceVetor++)
                {
                    do
                    {
                        if (cartelaCriada[linha, coluna] == vetorNumSorteadosParaCartela[indiceVetor])
                        {
                            numSorteadoParaCartela = SortearNumCartela();
                            cartelaCriada[linha, coluna] = numSorteadoParaCartela;
                        }
                        else
                        {
                            numRepetido = false;
                        }
                    } while (numRepetido != false);
                }
            }
            contInicio--;
        }
    }
    return cartelaCriada;
}

/*
 * Essa função será usada para monitorar os números sorteados, durante a construção do código.
*/
void MostrarCartela(int[,] matriz)
{
    for (int linha = 0; linha < totalLinhas; linha++)
    {
        for (int coluna = 0; coluna < totalColunas; coluna++)
        {
            Console.Write(matriz[linha, coluna] + "\t");
        }
        Console.WriteLine();
    }
};

//Descrição do Jogo para o usuário
Console.WriteLine("--- Jogo de Bingo ---");
Console.WriteLine("\nRegras:");
Console.WriteLine("- Devem haver, pelo menos, 2 jogadores");
Console.WriteLine("- A quantidade de tabelas é a mesma para cada jogador");
Console.WriteLine("- Para uma coluna completa, o jogador recebe 1 ponto");
Console.WriteLine("- Para uma linha completa, o jogador recebe 1 ponto");
Console.WriteLine("- Para a cartela completa, o jogador recebe 5 pontos");
Console.WriteLine("- O jogador com mais pontos vence.");
PularLinha();

//Início do programa
Console.WriteLine("Informe a quantidade de jogadores:");
qtdJogadores = int.Parse(Console.ReadLine());
Console.WriteLine("Informe a quantidade de cartelas: ");
qtdCartelas = int.Parse(Console.ReadLine());
PularLinha();

//Testagem do funcionamento das funções
cartelaCriada_aux = CriarCartela();
MostrarCartela(cartelaCriada_aux);