

using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;
static class Computador
{
  

    public static int ExecutarTurnoComputador(int posicaoComputador, int limiteLinhaChegada, int bonusAvancoExtra, int penalidadeRecuo)
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

      private static void ExibirCabecalho()
    {

        Console.Clear();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("----------------------------------");

    }

}
