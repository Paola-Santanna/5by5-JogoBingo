//Jogo de Bingo
//link da descrição: https://github.com/Felipe-Pestana/JogoBingo

int qnt_jogadores = 0, qnt_cartelas = 0, qnt_linhas = 5, qnt_colunas = 5, cont_identifica_cartela = 0;
int[,] cartela_criada;


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
            cartela[linha, coluna] = new Random().Next(1, 99);
        }
    }
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

void CartelasParaCadaJogador()
{
    for (int indice_jogador = 0; indice_jogador < qnt_jogadores; indice_jogador++)
    {
        Console.WriteLine($"{indice_jogador+1}º jogador");

        for (int indice_cartela = 0; indice_cartela < qnt_cartelas; indice_cartela++)
        {
            Console.WriteLine($"Cartela {indice_cartela+1}: ");
            cartela_criada = CriarCartela();
            MostrarCartela(cartela_criada);
        }
        Pular2Linhas();
    }
}


//Identificar a cartela
//int PreencherCartelas(int qnt_jogadores, int qnt_cartelas)
//{
//    if (qnt_jogadores > qnt_cartelas)
//    {

//        for (int indice_jogador = 0; indice_jogador < qnt_jogadores; indice_jogador++)
//        {
//            for (int indice_cartela = 0; indice_cartela < qnt_cartelas; indice_cartela++)
//            {
//                identificador_cartela[indice_jogador, indice_cartela] = cont_identifica_cartela;
//                cont_identifica_cartela += 1;
//            }
//        }
//    }
//    else
//    {
//        int indice_jogador = 0;
//        for (int indice_cartela = 0; indice_cartela < qnt_cartelas; indice_cartela++)
//        {
//            for (indice_jogador = 0; indice_jogador < qnt_jogadores; indice_jogador++)
//            {
//                identificador_cartela[indice_jogador, indice_cartela] = cont_identifica_cartela;
//                cont_identifica_cartela += 1;
//            }
//        }
//    }
//    return cont_identifica_cartela;
//}


/* Tópicos do jogo
 * 
 * Definir a quantidade de jogadores
 * Definir a quantidade de cartelas que cada jogador quer
 * 
 * Criar as cartelas, de acordo com cada jogador e a quantidade de cartelas escolhidas
 * 
 * Criar um algorítmo para sortear os 25 números
 * A rodada se refe a cada vez que um número é sorteado
 * Em cada rodada, fazer a verificação dos números de cada cartela, de cada um dos jogadores
 * 
 */

//Execução do Programa
QntJogadores();
QntCartelas();
CartelasParaCadaJogador();

//PreencherCartelas(qnt_jogadores, qnt_cartelas);
//Console.WriteLine(qnt_cartelas);

Console.WriteLine("Pressione Enter para encerrar...");
Console.ReadKey();