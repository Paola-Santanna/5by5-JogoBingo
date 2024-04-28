//Jogo de Bingo
//link da descrição: https://github.com/Felipe-Pestana/JogoBingo

// Variáveis
int qtdJogadores;
int qtdCartelas;
int qtdLinhas = 5, qtdColunas = 5;
int pontos;
int rodadas = 0;
int contadorNumSorteadoColuna;
int contadorNumSorteadoLinha;
int numeroSorteado;
int resposta;

bool fimDoJogo;
bool colunaPreenchida;
bool linhaPreenchida;
bool proxFaseBingo;

int[] vetorNumSorteados_aux;
int[] vetorNumSorteados = new int[rodadas];
int[] vetorCartela;

int[,] matrizCriarCartela = new int[qtdLinhas, qtdColunas];
int[,] cartelaCriada;

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
        for (int coluna = 0; coluna < qtdColunas; coluna++)
            matrizCriarCartela[linha, coluna] = new Random().Next(1, 26);
    }
    return matrizCriarCartela;
}
void MostrarCartela(int[,] matriz)
{
    for (int linha = 0; linha < qtdLinhas; linha++)
    {
        for (int coluna = 0; coluna < qtdColunas; coluna++)
        {
            Console.Write(matriz[linha, coluna] + " ");
        }
        Console.WriteLine();
    }
}

void IdentificarCartela(int qtdJogadores, int qtdCartelas)
{
    for (int indiceJogador = 0; indiceJogador < qtdJogadores; indiceJogador++)
    {
        Pular2Linhas();
        Console.WriteLine($"{indiceJogador + 1}º jogador");

        for (int indiceCartela = 0; indiceCartela < qtdCartelas; indiceCartela++)
        {
            int[,] cartelaCriada_final = new int[qtdLinhas, qtdColunas];
            Console.WriteLine();
            Console.WriteLine($"{indiceCartela + 1}ª cartela:\n");
            cartelaCriada = CriarCartela();
            MostrarCartela(cartelaCriada);
        }
    }
}

int SortearNumero()
{
    int numSorteado = new Random().Next(1, 99);
    rodadas += 1;

    for (int indiceRodada = 0; indiceRodada < rodadas; indiceRodada++)
    {
        vetorNumSorteados = new int[rodadas];
        vetorNumSorteados[indiceRodada] = numSorteado;
    }

    bool numNaoRepetido = false;
    do
    {
        for (int indiceNumSorteado = 0; indiceNumSorteado < rodadas; indiceNumSorteado++)
        {
            if (vetorNumSorteados[indiceNumSorteado] == numSorteado)
            {
                numSorteado = new Random().Next(1,99);
            }
        }
        numNaoRepetido = true;
    } while (numNaoRepetido != true);

    return numSorteado;
}

int[] ListarNumSorteados(int numSorteado)
{
    for (int indiceRodada = 0; indiceRodada < rodadas; indiceRodada++)
    {
        vetorNumSorteados = new int[rodadas];
        vetorNumSorteados[indiceRodada] = numSorteado;
    }
    return vetorNumSorteados;
}

bool VerificarColunaPreenchida(int[,] cartela, int[] VetorNumSorteados)
{
    int rodadasExecutadas = SortearNumero();
    while (rodadasExecutadas != 0)
    {
        for (int indiceColuna = 0; indiceColuna < qtdColunas; indiceColuna++)
        {
            for (int indiceLinha = 0; indiceLinha < qtdLinhas; indiceLinha++)
            {
                for (int indiceVetorNumSorteados = 0; indiceVetorNumSorteados < rodadasExecutadas; indiceVetorNumSorteados++)
                {
                    if (cartela[indiceLinha, indiceColuna] == VetorNumSorteados[indiceVetorNumSorteados])
                    {
                        contadorNumSorteadoColuna += 1;

                        if (contadorNumSorteadoColuna == 5)
                        {
                            colunaPreenchida = true;
                        }
                        else
                            colunaPreenchida = false;
                    }
                }
            }
        }
        rodadasExecutadas -= 1;
    }

    return colunaPreenchida;
}

bool VerificarLinhaPreenchida(int[,] cartela, int[] VetorNumSorteados)
{
    int rodadasExecutadas = SortearNumero();
    int rodadasExecutadas_aux = 0;
    while (rodadasExecutadas_aux != rodadasExecutadas)
    {
        for (int indiceLinha = 0; indiceLinha < qtdLinhas; indiceLinha++)
        {
            for (int indiceColuna = 0; indiceColuna < qtdColunas; indiceColuna++)
            {
                for (int indiceVetorNumSorteados = 0; indiceVetorNumSorteados < rodadasExecutadas; indiceVetorNumSorteados++)
                {
                    if (cartela[indiceLinha, indiceColuna] == VetorNumSorteados[indiceVetorNumSorteados])
                    {
                        contadorNumSorteadoLinha += 1;

                        if (contadorNumSorteadoLinha == 5)
                        {
                            linhaPreenchida = true;
                        }
                        else
                            linhaPreenchida = false;
                    }
                }
            }
        }
        rodadasExecutadas_aux += 1;
    }

    return linhaPreenchida;
}


//Execução do Programa
Console.WriteLine("Insira a quantidade de jogadores: ");
qtdJogadores = int.Parse(Console.ReadLine());
Console.WriteLine("Insira a quantidade de cartelas: ");
qtdCartelas = int.Parse(Console.ReadLine());

do
{
    IdentificarCartela(qtdJogadores, qtdCartelas);
    Pular2Linhas();
    Console.WriteLine($"Deseja sortear o {rodadas + 1}° número? ");
    Console.Write("Digite: \n1 -> Sim \n2 -> Não \nSua resposta: ");
    resposta = int.Parse(Console.ReadLine());

    switch (resposta)
    {
        case 1:
            numeroSorteado = SortearNumero();
            vetorNumSorteados_aux = ListarNumSorteados(numeroSorteado);
            break;

        case 2:
            Pular2Linhas();
            Console.WriteLine("Encerrando o jogo...");
            break;

        default:
            Pular2Linhas();
            Console.WriteLine("Resposta Inválida");
            break;
    }

} while (resposta != 2);


Pular2Linhas();
Console.WriteLine(rodadas);


//do
//{
//    // Operações de sorteio e recolhimento da coluna ou da linha completada

//} while (fimDoJogo = false);

Pular2Linhas();
Console.WriteLine("Pressione Enter para encerrar...");
Console.ReadKey();