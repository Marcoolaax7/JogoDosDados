using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;
/*

*/

class Program
{
    static void ExibirCabecalho()
    {

        Console.Clear();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("----------------------------------");

    }

    static int ExecutarTurnoJogador(int posicaoJogador, int limiteLinhaChegada, int bonusAvancoExtra, int penalidadeRecuo)
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

    static int ExecutarTurnoComputador(int posicaoComputador, int limiteLinhaChegada, int bonusAvancoExtra, int penalidadeRecuo)
    {
        do
        {

            ExibirCabecalho();

            Console.WriteLine("Rodada do Computador!");
            Console.WriteLine("----------------------------------");

            int resultadoComputador = RandomNumberGenerator.GetInt32(1, 7);



            Console.WriteLine($"O numero sorteado foi: {resultadoComputador}");


            posicaoComputador += resultadoComputador;

            Console.WriteLine($"Voce esta na posicao: {posicaoComputador} de {limiteLinhaChegada}");

            if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)

            {
                Console.WriteLine($"\nEVENTO: Avanço de {bonusAvancoExtra} de {limiteLinhaChegada}");
                posicaoComputador += bonusAvancoExtra;

                Console.WriteLine($"\nVoce esta na posicao: {posicaoComputador} de {limiteLinhaChegada}");
            }

            else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
            {
                Console.WriteLine($"\nEVENTO: Recuo de {penalidadeRecuo} de {limiteLinhaChegada}");
                posicaoComputador -= penalidadeRecuo;

                Console.WriteLine($"\nVoce esta na posicao: {posicaoComputador} de {limiteLinhaChegada}");
            }



            if (posicaoComputador >= limiteLinhaChegada)
            {
                Console.WriteLine("\n O computador chegou na linha de chegada.");
                Console.Write("\nPressione ENTER para continuar..");
                Console.ReadLine();

                break;
            }

            if (resultadoComputador == 6)
            {
                Console.WriteLine($"\nEVENTO: Rodada extra!");
                Console.Write("\nPressione ENTER para continuar...");
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

        return posicaoComputador;
    }

    static bool DesejaContinuar()
    {
        Console.WriteLine("Deseja continuar? (s/n): ");
        string? opcaoContinuar = Console.ReadLine()?.ToUpper();

        if (opcaoContinuar != "S")
            return false;

        return true;
    }

    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;
        const int bonusAvancoExtra = 3;
        const int penalidadeRecuo = 2;

        while (true)
        {
            int posicaoJogador = 0;
            int posicaoComputador = 0;

            ExibirCabecalho();

            while (true)
            {
                posicaoJogador = ExecutarTurnoJogador(
                    posicaoJogador,
                    limiteLinhaChegada,
                    bonusAvancoExtra,
                    penalidadeRecuo
                );

                if (posicaoJogador >= limiteLinhaChegada)
                    break;

                posicaoComputador = ExecutarTurnoComputador(
                    posicaoComputador,
                    limiteLinhaChegada,
                    bonusAvancoExtra,
                    penalidadeRecuo
                );

                if (posicaoComputador >= limiteLinhaChegada)
                    break;
            }

            if (!DesejaContinuar())
                break;

        }

    }
}
