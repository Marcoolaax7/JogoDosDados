using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;
/*

*/

class Program
{

    static void Main(string[] args)
    {

        while (true)
        {
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



            Console.WriteLine("Deseja continuar? (s/n): ");
            string? opcaoContinuar = Console.ReadLine()?.ToUpper();

            if (opcaoContinuar != "S")
                break;



        }

    }
}
