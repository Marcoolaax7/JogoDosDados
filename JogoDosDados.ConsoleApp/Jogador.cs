
using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

static class Jogador
{


    public static int ExecutarTurnoJogador(int posicaoJogador, int limiteLinhaChegada, int bonusAvancoExtra, int penalidadeRecuo)
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

            posicaoJogador += resultadoJogador;

            Console.WriteLine($"Voce esta na posicao: {posicaoJogador} de {limiteLinhaChegada}");

            if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15 || posicaoJogador == 25)

            {
                Console.WriteLine($"\nEVENTO: Avanço de {bonusAvancoExtra} de {limiteLinhaChegada}");
                posicaoJogador += bonusAvancoExtra;

                Console.WriteLine($"\nVoce esta na posicao: {posicaoJogador} de {limiteLinhaChegada}");
            }

            else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
            {
                Console.WriteLine($"\nEVENTO: Recuo de {penalidadeRecuo} de {limiteLinhaChegada}");
                posicaoJogador -= penalidadeRecuo;

                Console.WriteLine($"\nVoce esta na posicao: {posicaoJogador} de {limiteLinhaChegada}");
            }

            if (posicaoJogador >= limiteLinhaChegada)
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

        return posicaoJogador;
    }

    private static void ExibirCabecalho()
    {

        Console.Clear();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("----------------------------------");

    }


}
