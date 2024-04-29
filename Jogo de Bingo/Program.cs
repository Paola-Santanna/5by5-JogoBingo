//Declaração de variáveis
using System.ComponentModel;
using System.Net.NetworkInformation;

int qtdJogadores = 0, qtdCartelas = 0;
int totalLinhas = 5, totalColunas = 5;
int contNumSorteadosCartela = 1;
int numSorteado;
int numSorteadoBingo;
int indice = -1;
int indice2 = -1;
int contNumSorteadosBingo;
int sortearNumero;
int rodadas = 0;
int numSorteadoTemporario;
int pontos = 0;

bool numRepetido = true;

/*
 * Vetor para armazenar os números que já foram sorteados na cartela.
 * VetorNumSorteadosParaCartela = Vetor de Números Sorteados para a Cartela
*/
int[] vetorNumSorteadosParaCartela;

//Vetor de números quejá foram sorteados para o bingo
int[] vetorNumSorteadosBingo;

/*
 * Essa variável irá armazenar os números da cartela para o sorteio.
 * Recebe como valores máximos de dimensão, a quantidade total de linhas e o total de colunas
*/
int[,] cartelaCriada = new int[totalLinhas, totalColunas];
int[,] cartelaCriada_aux;

/*
 * Fora criados os vetores:
 * "jogadores": para identificar os jogadores
 * "cartela": para identificar de qual jogador é
 * "cartela_final": para armaenar a matriz dos números sorteados
 */

int[] jogadores = new int[qtdJogadores];
int[] cartela = new int[qtdCartelas];
int[,] cartela_final = new int[totalLinhas, totalColunas];

//Função para pular linha e visualizar melhor as informações impressas
void PularLinha()
{
    Console.WriteLine();
    Console.WriteLine();
}

int RetornarRodadas()
{
    rodadas += 1;
    return rodadas;
}

int SortearNumBingo()
{
    contNumSorteadosBingo = RetornarRodadas();
    vetorNumSorteadosBingo = new int[contNumSorteadosCartela];
    numSorteadoBingo = new Random().Next(1, 99);
    indice2 += 1;
    vetorNumSorteadosBingo[indice] = numSorteadoBingo;

    /*
    * Trecho para evitar a repetição de números iguais
    */

    for (int indice_aux = 0; indice_aux < contNumSorteadosCartela; indice_aux++)
    {
        numRepetido = true;
        for (int indice_aux_comparacao = indice_aux + 1; indice_aux_comparacao < contNumSorteadosCartela; indice_aux_comparacao++)
        {
            do
            {
                if (vetorNumSorteadosBingo[indice_aux] != vetorNumSorteadosBingo[indice_aux_comparacao])
                {
                    numRepetido = false;
                }
                else
                {
                    vetorNumSorteadosBingo[indice] = vetorNumSorteadosBingo[indice_aux_comparacao];
                    vetorNumSorteadosBingo[indice_aux_comparacao] = numSorteadoBingo;
                    numSorteadoBingo = new Random().Next(1, 99);
                }
            } while (numRepetido);
        }
    }

    return numSorteadoBingo;
}

int SortearNumCartela()
{
    contNumSorteadosCartela += 1;
    vetorNumSorteadosParaCartela = new int[contNumSorteadosCartela];
    numSorteado = new Random().Next(1, 99);
    indice += 1;
    vetorNumSorteadosParaCartela[indice] = numSorteado;

    /*
    * Trecho para evitar a repetição de números iguais
    */

    for (int indice_aux = 0; indice_aux < contNumSorteadosCartela; indice_aux++)
    {
        numRepetido = true;
        for (int indice_aux_comparacao = indice_aux + 1; indice_aux_comparacao < contNumSorteadosCartela; indice_aux_comparacao++)
        {
            do
            {
                if (vetorNumSorteadosParaCartela[indice_aux] != vetorNumSorteadosParaCartela[indice_aux_comparacao])
                {
                    numRepetido = false;
                }
                else
                {
                    vetorNumSorteadosParaCartela[indice] = vetorNumSorteadosParaCartela[indice_aux_comparacao];
                    vetorNumSorteadosParaCartela[indice_aux_comparacao] = numSorteado;
                    numSorteado = new Random().Next(1, 99);
                }
            } while (numRepetido);
        }
    }

    return numSorteado;
}

/*
 * Função para criar a cartela, com as dimensões de 5x5 e retornar a cartela criada.
*/
int[,] CriarCartela()
{
    int numSorteadoParaCartela;

    for (int linha = 0; linha < totalLinhas; linha++)
    {
        for (int coluna = 0; coluna < totalColunas; coluna++)
        {
            numSorteadoParaCartela = SortearNumCartela();
            cartelaCriada[linha, coluna] = numSorteadoParaCartela;
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

int[,] ArmazenarCartelaJogador(int indiceJogador, int identificacaocartela, int[,] matriz)
{
    int jogadorAtual = indiceJogador;
    int cartelaAtual = identificacaocartela;
    int[,] cartelaJogadorAtual = new int[totalLinhas, totalColunas];

    for (int linha = 0; linha < totalLinhas; linha++)
    {
        for (int coluna = 0; coluna < totalColunas; coluna++)
        {
            cartelaJogadorAtual[linha, coluna] = matriz[linha, coluna];
        }
    }

    //Console.WriteLine($"Jogador{indiceJogador+1}");
    //Console.WriteLine($"{cartelaAtual+1}ª catela:"); 

    return cartelaJogadorAtual;
}

int PontuarColuna(bool completo)
{
    int pontos = 0;
    if (completo == true)
    {
       pontos = 1;
    }

    return pontos;
}

void AtribuirCartela()
{
    int[,] cartelaJogadorAtual_aux = new int[totalLinhas, totalColunas];
    for (int indiceJogador = 0; indiceJogador < qtdJogadores; indiceJogador++)
    {
        Console.WriteLine($"{indiceJogador + 1}º Jogador:");
        Console.WriteLine();
        for (int indiceCartela = 0; indiceCartela < qtdCartelas; indiceCartela++)
        {
            cartelaCriada_aux = CriarCartela();

            Console.WriteLine($"{indiceCartela + 1}ª cartela:");
            Console.WriteLine();

            for (int linha = 0; linha < totalLinhas; linha++)
            {
                for (int coluna = 0; coluna < totalColunas; coluna++)
                {
                    cartela_final[linha, coluna] = cartelaCriada_aux[linha, coluna];
                }
            }
            cartelaJogadorAtual_aux = ArmazenarCartelaJogador(indiceJogador, indiceCartela, cartela_final);
            MostrarCartela(cartelaJogadorAtual_aux);
            Console.WriteLine();

            numSorteadoTemporario = SortearNumBingo();

            VerificarColuna(vetorNumSorteadosBingo, contNumSorteadosBingo, cartelaJogadorAtual_aux, indiceJogador);


        }

        PularLinha();
    }

    do
    {
        Console.WriteLine("============================================");
        Console.WriteLine("Sortear número? ");
        Console.WriteLine("1 - Sim");
        Console.WriteLine("2 - Não");
        sortearNumero = int.Parse(Console.ReadLine());

        switch (sortearNumero)
        {
            case 1:
                Console.WriteLine("Próximo número: ");
                PularLinha();
                MostrarCartela(cartelaJogadorAtual_aux);
                numSorteadoTemporario = SortearNumBingo();
                break;

            case 2:
                Console.WriteLine("Encerrando...");
                break;

            default:
                Console.WriteLine("Opção Inválida!");
                break;
        }
        Console.WriteLine("============================================");
    } while (sortearNumero != 2);
}

bool VerificarColuna(int[] numQueJaForamSorteados, int contadorRodadas, int[,] cartela, int indiceJogador)
{
    bool completo = false;
    int qtd_numMarcados = 0;

    for (int linha = 0; linha < totalLinhas; linha++)
    {
        for (int coluna = 0; coluna < totalColunas; coluna++)
        {
            for (int indiceVetorNumSorteados = 0; indiceVetorNumSorteados < contadorRodadas; indiceVetorNumSorteados++)
            {
                if (cartela[linha, coluna] == numQueJaForamSorteados[indice])
                {
                    qtd_numMarcados += 1;
                    Console.WriteLine("|" + cartela[linha, coluna] + "|");
                }
            }

            if (qtd_numMarcados == 5)
            {
                completo = true;
            }
            else
                completo = false;
        }
    }

    return completo;
}

//bool VerificarLinha()
//{

//}

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



AtribuirCartela();




Console.WriteLine("Pontuação Final:");
Console.WriteLine("Jogador {}: ");
Console.WriteLine("Jogador {}: ");