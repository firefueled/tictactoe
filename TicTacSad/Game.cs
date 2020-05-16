using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicTacSad
{
    public class Game
    {
        public int BoardX { get; private set; }
        public int BoardY { get; private set; }

        public MatchStrategy Strategy { get; private set; }
        
        public WinCondition WinCondition { get; private set; }

        private List<List<int>> board;

        public void Init()
        {
            // Inicia programa
            Console.WriteLine("");
            Console.WriteLine("Jogo da Velha SAD");
            Console.WriteLine("");

            WinCondition = WinCondition.NotStarted;
        }
        
        private void ReportWinner(WinCondition winCondition)
        {
            throw new NotImplementedException();
        }

        public void PlayMatch()
        {
            // Enquanto condição de vitória não for atendida, loopa

            // Escolhe jogada

            // Aguarda jogada

            // Verifica condição de vitória foi atingida

            // Se sim, saí do loop

            throw new NotImplementedException();
        }

        public bool DefineMatchStrategy()
        {
            Strategy = null;
            return true;
        }

        public bool ReadPlayerDefinition(string playerDefRead)
        {
            return true;
        }

        public bool BuildBoard()
        {
            return true;
        }

        public void SetBoardDimensions(string input)
        {
            if (input == null)
            {
                throw new ArgumentException("Definição de tabuleiro vazia.");
            }
            
            string boardSizeDescription = input
                .Replace(" ", "")
                .Replace("X", "x");

            if (!Regex.IsMatch(boardSizeDescription, "\\dx\\d"))
            {
                throw new ArgumentException("Definição de tabuleiro não legível.");
            }

            var boardDefSplit = boardSizeDescription.Split('x');
            
            BoardX = int.Parse(boardDefSplit[0]);
            BoardY = int.Parse(boardDefSplit[1]);
        }

        private int CheckWinCondition()
        {
            return 0;
        }
    }
}