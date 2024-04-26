//Jogo de Bingo
//link da descrição: https://github.com/Felipe-Pestana/JogoBingo

int qnt_jogadores, qnt_cartelas, qnt_linhas = 2, qnt_colunas = 2, num_sorteado;
int[,] cartela_criada;
int[,] cartela_copia1;
int[,] cartela_criada_aux;
int[,] cartela_criada_final = new int[qnt_linhas, qnt_colunas];
bool valor_nao_copiado;

//Funções
void Pular2Linhas()
{
    Console.WriteLine();
    Console.WriteLine();
}

Console.WriteLine("--- Jodo do Bingo ---\n");
Console.WriteLine("Mínimo de jogadores: 2");
Console.WriteLine("Cada jogador tem a mesma quantidade de cartela, a partir de 1");
Pular2Linhas();

int[,] CriarCartela()
{
    int[,] cartela = new int[qnt_linhas, qnt_colunas];
    for (int linha = 0; linha < qnt_linhas; linha++)
    {
        for (int coluna = 0; coluna < qnt_colunas; coluna++)
        {
            cartela[linha, coluna] = new Random().Next(1, 9);
        }
    }
    cartela_copia1 = cartela;

    do
    {
        for (int linha = 0; linha < qnt_linhas; linha++)
        {
            for (int linha_comparacao = linha + 1; linha_comparacao < qnt_linhas; linha_comparacao++)
            {
                for (int coluna = 0; coluna < qnt_colunas; coluna++)
                {
                    for (int coluna_comparacao = coluna + 1; coluna_comparacao < qnt_colunas; coluna_comparacao++)
                    {
                        if (cartela[linha, coluna] == cartela[linha_comparacao, coluna_comparacao] && cartela_copia1[linha, coluna] == cartela_copia1[linha, coluna])
                        {
                            cartela[linha, coluna] = new Random().Next(1, 9);
                        }
                    }
                }
            }
        }
    } while (cartela == cartela_copia1);

    return cartela;
}

void MostrarCartela(int[,] cartela)
{
    for (int linha = 0; linha < qnt_linhas; linha++)
    {
        Console.WriteLine();
        for (int coluna = 0; coluna < qnt_colunas; coluna++)
        {
            Console.Write(cartela[linha, coluna] + " ");
        }
    }
    Pular2Linhas();
}

//Definindo a quantidade de jogadores
int QntJogadores()
{
    do
    {
        Console.Write("Insira a quantidade de jogadores: ");
        qnt_jogadores = int.Parse(Console.ReadLine());
    } while (qnt_jogadores < 2);
    Pular2Linhas();
    return qnt_jogadores;
}

int QntCartelas()
{
    do
    {
        Console.Write("Insira a quantidade de cartelas: ");
        qnt_cartelas = int.Parse(Console.ReadLine());
    } while (qnt_cartelas < 0);
    Pular2Linhas();
    return qnt_cartelas;
}

int[,] CartelasParaCadaJogador()
{
    for (int indice_jogador = 0; indice_jogador < qnt_jogadores; indice_jogador++)
    {
        Console.WriteLine($"{indice_jogador + 1}º jogador");

        for (int indice_cartela = 0; indice_cartela < qnt_cartelas; indice_cartela++)
        {
            cartela_criada = CriarCartela();
            cartela_criada_aux = cartela_criada;
            //cartela_criada = CriarCartela();
            Console.WriteLine($"Cartela {indice_cartela + 1}: ");
            cartela_criada_final = cartela_criada_aux;

            MostrarCartela(cartela_criada_final);
        }
        Pular2Linhas();
    }
    return cartela_criada_final;
}

//Sorteio
void SortearNumero()
{
    num_sorteado = new Random().Next(1, 99);
    Console.Write($"Número Sorteado: {num_sorteado}");
    Pular2Linhas();
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
QntJogadores();
QntCartelas();
CartelasParaCadaJogador();
SortearNumero();

//PreencherCartelas(qnt_jogadores, qnt_cartelas);
//Console.WriteLine(qnt_cartelas);

Console.WriteLine("Pressione Enter para encerrar...");
Console.ReadKey();