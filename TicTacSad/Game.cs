using System;
using System.Collections.Generic;

namespace TicTacSad
{
    public class Game
    {
        private int boardX;
        private int boardY;
        private WinCondition winCondition = WinCondition.NoConclusion;
        private List<List<int>> board;

        public WinCondition Start()
        {
            // Inicia programa
            Console.WriteLine("");
            Console.WriteLine("Jogo da Velha SAD");
            Console.WriteLine("");
            
            // Lê tabuleiro
            ReadBoardDimensions();
            
            // Definição de dimensões não funcionou
            if (boardX == null || boardY == null) return winCondition;
            
            // Configura tabuleiro
            BuildBoard();
            
            // Criação de tábua não funcionou
            if (board == null) return winCondition;
            
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
        }

        private void BuildBoard()
        {
        }

        private void ReadBoardDimensions()
        {
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