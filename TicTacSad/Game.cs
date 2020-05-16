using System;

namespace TicTacSad
{
    public class Game
    {
        private int boardX;
        private int boardY;
        private WinCondition winCondition = WinCondition.NoConclusion;

        public WinCondition Start()
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

            winCondition = PlayMatch(strategy);
            
            // Condição de vitória for atendida. Reporta vencedor
            ReportWinner(winCondition);

            return winCondition;
        }
        
        private void ReportWinner(WinCondition winCondition)
        {
            throw new NotImplementedException();
        }

        private WinCondition PlayMatch(MatchStrategy strategy)
        {
            // Enquanto condição de vitória não for atendida, loopa

            // Escolhe jogada

            // Aguarda jogada

            // Verifica condição de vitória foi atingida

            // Se sim, saí do loop

            throw new NotImplementedException();
        }

        private MatchStrategy DefineMatchStrategy()
        {
            throw new NotImplementedException();
        }

        private void ReadPlayerDefinition()
        {
            throw new NotImplementedException();
        }

        private void BuildBoard()
        {
            throw new NotImplementedException();
        }

        private void ReadBoardDimensions()
        {
            throw new NotImplementedException();
        }

        private void GetBoardDimensions()
        {
            Console.WriteLine("Digite o tamano do tabuleiro");

            string boardSizeDescription = Console.ReadLine()?
                .Replace(" ", "");

            boardX = 4;
            boardY = 6;
        }

        private int CheckWinCondition()
        {
            return 0;
        }
    }
}