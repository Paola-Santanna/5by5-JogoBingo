//Jogo de Bingo
//link da descrição: https://github.com/Felipe-Pestana/JogoBingo

int qtdJogadores;
int qtdCartelas;
int qtdLinhas = 5, qtdColunas = 5;
bool numNaoCopiado = false;

int[,] matrizCriarCartela = new int[qtdLinhas, qtdColunas];
int[,] matrizCartelaCriada;

//Funções

void Pular2Linhas()
{
    Console.WriteLine();
    Console.WriteLine();
}
int[,] CriarCartela()
{
    for (int linha = 0; linha < qtdLinhas; linha++)
    {
        int linhaComparacao = linha - 1;

        Console.WriteLine();

        for (int coluna = 0; coluna < qtdColunas; coluna++)
        {
            matrizCriarCartela[linha, coluna] = new Random().Next(1, 26);

            if (coluna != 0)
            {
                int colunaComparacao = coluna - 1;

                do
                {
                    if (matrizCriarCartela[linha, coluna] == matrizCriarCartela[linha, colunaComparacao])
                    {
                        matrizCriarCartela[linha, coluna] = new Random().Next(1, 26);
                    }
                    else
                    {
                        if (linha != 0)
                        {
                            if (matrizCriarCartela[linha, coluna] == matrizCriarCartela[linhaComparacao, coluna])
                            {
                                matrizCriarCartela[linha, coluna] = new Random().Next(1, 26);
                            }
                        }
                    }

                    numNaoCopiado = true;
                    Console.Write(matrizCriarCartela[linha, coluna] + " ");

                } while (numNaoCopiado != true);
            }
        }
    }

    return matrizCriarCartela;
}

void MostrarCartela(int[,] matriz)
{
    for (int linha = 0; linha < qtdLinhas; linha++)
    {
        for (int coluna = 0; coluna < qtdColunas; coluna++)
        {
            Console.WriteLine(matriz[linha,coluna] + " ");
        }
    }
}

/* Tópicos do jogo
 * 
 * Definir a quantidade de jogadores
 * Definir a quantidade de cartelas para cada jogador
 * 
 * Criar as cartelas, de acordo com a quantidade de cartelas escolhidas
 * 
 * Criar um algorítmo para sortear os 25 números, para formar a tabela
 * A rodada se refere a cada vez que um número é sorteado
 * Em cada rodada, fazer a verificação dos números de cada cartela, de cada um dos jogadores
 * Armazenar em um vetor, os números já sorteados
 * 
 */

//Execução do Programa
Console.WriteLine("Insira a quantidade de jogadores: ");
qtdJogadores = int.Parse(Console.ReadLine());
Console.WriteLine("Insira a quantidade de cartelas: ");
qtdCartelas = int.Parse(Console.ReadLine());

CriarCartela();

//PreencherCartelas(qnt_jogadores, qnt_cartelas);
//Console.WriteLine(qnt_cartelas);

Pular2Linhas();
Console.WriteLine("Pressione Enter para encerrar...");
Console.ReadKey();