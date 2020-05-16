using System;

namespace TicTacSad
{
    internal class Program
    {
        private static int boardX = 0;
        private static int boardY = 0;

        public static void Main(string[] args)
        {
            // Inicia programa
            
            Console.WriteLine("");
            Console.WriteLine("Jogo da Velha SAD");
            Console.WriteLine("");
            
            // Lê tabuleiro
            ReadBoardDimensions();

            // Configura tabuleiro
            BuildBoard();

            // Recebe definição de jogador. X ou O
            ReadPlayerDefinition();

            // Define estratégia de jogo
            var strategy = DefineMatchStrategy();

            var winCondition = PlayMatch(strategy);
            
            // Condição de vitória for atendida. Reporta vencedor
            ReportWinner(winCondition);
        }

        private static void ReportWinner(WinCondition winCondition)
        {
            throw new NotImplementedException();
        }

        private static WinCondition PlayMatch(MatchStrategy strategy)
        {
            // Enquanto condição de vitória não for atendida, loopa

            // Escolhe jogada

            // Aguarda jogada

            // Verifica condição de vitória foi atingida

            // Se sim, saí do loop

            throw new NotImplementedException();
        }

        private static MatchStrategy DefineMatchStrategy()
        {
            throw new NotImplementedException();
        }

        private static void ReadPlayerDefinition()
        {
            throw new NotImplementedException();
        }

        private static void BuildBoard()
        {
            throw new NotImplementedException();
        }

        private static void ReadBoardDimensions()
        {
            throw new NotImplementedException();
        }

        private static void GetBoardDimensions()
        {
            Console.WriteLine("Digite o tamano do tabuleiro");

            string boardSizeDescription = Console.ReadLine()?
                .Replace(" ", "");

            boardX = 4;
            boardY = 6;
        }

        private static int CheckWinCondition()
        {
            return 0;
        }
    }

    internal enum WinCondition
    {
    }

    internal class MatchStrategy
    {
    }
}