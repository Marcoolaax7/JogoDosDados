
using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

static class Jogador
{
    public static int posicao = 0;
    private const int limiteLinhaChegada = 30;
    private const int bonusAvancoExtra = 3;
    private const int penalidadeRecuo = 2;

    public static void ExecutarTurnoJogador()
    {
        do
        {
            ExibirCabecalho();

            Console.WriteLine("Rodada do Jogador!");
            Console.WriteLine("----------------------------------");


            Console.Write("Pressione ENTER para lancar um dado...");
            Console.ReadLine();

            int resultadoJogador = RandomNumberGenerator.GetInt32(1, 7);

            Console.WriteLine("----------------------------------");
            Console.WriteLine($"O numero sorteado foi: {resultadoJogador}");

            posicao += resultadoJogador;

            Console.WriteLine($"Voce esta na posicao: {posicao} de {limiteLinhaChegada}");

            if (posicao == 5 || posicao == 10 || posicao == 15 || posicao == 25)

            {
                Console.WriteLine($"\nEVENTO: Avanço de {bonusAvancoExtra} de {limiteLinhaChegada}");
                posicao += bonusAvancoExtra;

                Console.WriteLine($"\nVoce esta na posicao: {posicao} de {limiteLinhaChegada}");
            }

            else if (posicao == 7 || posicao == 13 || posicao == 20)
            {
                Console.WriteLine($"\nEVENTO: Recuo de {penalidadeRecuo} de {limiteLinhaChegada}");
                posicao -= penalidadeRecuo;

                Console.WriteLine($"\nVoce esta na posicao: {posicao} de {limiteLinhaChegada}");
            }

            if (posicao >= limiteLinhaChegada)
            {
                Console.WriteLine("\nParabens! Voce alcançou a linha de chegada.");
                Console.Write("\nPressione ENTER para continuar..");
                Console.ReadLine();

                break;
            }

            if (resultadoJogador == 6)
            {
                Console.WriteLine($"\nEVENTO: Rodada extra!");
                Console.Write("\nPressione ENTER para jogar novamente...");
                Console.ReadLine();
                continue;
            }
            else
            {
                Console.Write("\nPressione ENTER para continuar..");
                Console.ReadLine();
                break;
            }

        } while (true);
    }

    public static bool Venceu()
    {
        return posicao >= limiteLinhaChegada;
    }

    private static void ExibirCabecalho()
    {

        Console.Clear();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("----------------------------------");

    }


}
