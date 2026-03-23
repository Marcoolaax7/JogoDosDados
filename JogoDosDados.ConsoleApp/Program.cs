using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;
/*
1. Pista:
    ○ A pista é representada por uma linha numérica (ex.: de 0 a 30).
    ○ O jogador e o computador começam na posição 0.
2. Turnos:
    ○ O jogador e o computador alternam turnos para rolar um dado (gerar um número aleatório
    entre 1 e 6).
    ○ O número gerado é somado à posição atual do competidor.
    ○ O jogo exibe a posição atual do jogador e do computador após cada rodada.
3. Eventos Especiais:
    ○ Para tornar o jogo mais interessante, algumas posições na pista podem ter eventos especiais:
    ■ Avanço extra: Se o competidor parar em uma posição específica (ex.: 5, 10, 15), ele
    avança +3 casas.
    ■ Recuo: Se o competidor parar em outra posição específica (ex.: 7, 13, 20), ele recua -2
    casas.
    ■ Rodada extra: Se o competidor tirar 6 no dado, ele ganha uma rodada extra.

4. Condição de Vitória:
    ○ O primeiro competidor a alcançar ou ultrapassar a posição final (ex.: 30) vence o jogo.

v2
    1. Refatoração estruturada com extração de métodos
*/

{
    static void ExibirCabecalho()
    {

        Console.Clear();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("----------------------------------");

    }

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


}

class Program
{


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
                posicaoJogador = Jogador.ExecutarTurnoJogador(
                    posicaoJogador,
                    limiteLinhaChegada,
                    bonusAvancoExtra,
                    penalidadeRecuo
                );

                if (posicaoJogador >= limiteLinhaChegada)
                    break;

                posicaoComputador = Computador.ExecutarTurnoComputador(
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
