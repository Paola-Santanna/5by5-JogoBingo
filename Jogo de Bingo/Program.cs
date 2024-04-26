//Jogo de Bingo
//link da descrição: https://github.com/Felipe-Pestana/JogoBingo

int qnt_jogadores = 0, qnt_jogadores2 = 0, qnt_cartelas, indice_linha_cartela = 0, indice_coluna_cartela = 0, total_linhas = 5, total_colunas = 5;
int num_sorteado;

int[] qnt_cartelas_cada_jogador = new int[qnt_jogadores];

int[,] cartela = new int[indice_linha_cartela, indice_coluna_cartela];

//Funções
void CriarCartela()
{
    for (int linha = 0; linha < total_linhas; linha++)
    {
        cartela[indice_coluna_cartela, indice_linha_cartela] = new Random().Next();
    }
}

void MostrarCartela(int[,] cartelaImpressa)
{
    for (int linha = 0; linha < total_linhas; linha++)
    {
        Console.WriteLine();
        for (int coluna = 0; coluna < total_colunas; coluna++)
        {
            Console.Write(cartelaImpressa[linha, coluna] + " ");
        }
    }
}

void Sorteio()
{
    num_sorteado = new Random().Next(1, 99);
}

int ReceberQuantidadeJogadores()
{
    do
    {
        Console.WriteLine("Insira a quantidade de Jogadores:");
        qnt_jogadores = int.Parse(Console.ReadLine());
    } while (qnt_jogadores < 1);
    return qnt_jogadores;
} //ok

qnt_jogadores2 = ReceberQuantidadeJogadores();
int ReceberQuantidadeCartelasCadaJogador(int qnt_jogadores)
{
    qnt_cartelas = 0;
    for (int jogador = 0; jogador < qnt_jogadores; jogador++)
    {
        Console.WriteLine($"{jogador + 1}º jogador, insira a quantidade de cartelas que você quer: ");
        qnt_cartelas = int.Parse(Console.ReadLine());
        qnt_cartelas_cada_jogador[qnt_jogadores] = qnt_cartelas; //Entender como resolve esse erro
    }
    return qnt_cartelas;
}

void SortearNumerosCadaCartela()
{
    for (int jogador = 0; jogador < qnt_jogadores; jogador++)
    {
        for (int cartela_do_jogador = 0; cartela_do_jogador < qnt_cartelas_cada_jogador[cartela_do_jogador]; cartela_do_jogador++)
        {
            CriarCartela();
        }
    }
}


ReceberQuantidadeJogadores();
ReceberQuantidadeCartelasCadaJogador(qnt_jogadores2);
SortearNumerosCadaCartela();
MostrarCartela(cartela);




/* Tópicos do jogo
 * 
 * Definir a quantidade de jogadores
 * Definir a quantidade de cartelas que cada jogador quer
 * Criar as cartelas
 * 
 * Criar um algorítmo para sortear os 25 números
 * A rodada se refe a cada vez que um número é sorteado
 * Em cada rodada, fazer a verificação dos números de cada cartela, de cada um dos jogadores
 * 
 */
Console.WriteLine("Pressione Enter para encerrar...");
Console.ReadKey();