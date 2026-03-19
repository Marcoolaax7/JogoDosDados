using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;
/*

*/

class Program
{

    static void Main(string[] args)
    {


        const int limiteLinhaChegada = 30;
        const int bonusAvancoExtra = 3;
        const int penalidadeRecuo = 2;

        while (true)
        {

            int posicaoJogador = 0;
            bool jogoEstaEmAndamento = true;

            while (jogoEstaEmAndamento)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Jogo dos Dados");
                Console.WriteLine("----------------------------------");


                // logica do jogo
                Console.Write("Pressione ENTER para lancar um dado...");
                Console.ReadLine();


                int resultado = RandomNumberGenerator.GetInt32(1, 7);


                Console.WriteLine("----------------------------------");
                Console.WriteLine($"O numero sorteado foi: {resultado}");
                Console.WriteLine("----------------------------------");

                posicaoJogador += resultado;

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



              if( posicaoJogador >= limiteLinhaChegada)
                {
                    Console.WriteLine("\nParabens! Voce alcançou a linha de chegada.");

                    jogoEstaEmAndamento = false;
                }

                Console.WriteLine("Pressione ENTER para continuar..");
                Console.ReadLine();


            }

            Console.WriteLine("Deseja continuar? (s/n): ");
            string? opcaoContinuar = Console.ReadLine()?.ToUpper();

            if (opcaoContinuar != "S")
                break;



        }

    }
}
