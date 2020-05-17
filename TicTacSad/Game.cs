using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacSad
{
    public class Game
    {
        public int BoardX { get; private set; }
        public int BoardY { get; private set; }

        public MatchStrategy Strategy { get; private set; }
        
        public EndStates EndState { get; private set; }

        public List<List<Play>> Board { get; private set; }

        public void Init()
        {
            // Inicia programa
            Console.WriteLine("");
            Console.WriteLine("Jogo da Velha SAD");
            Console.WriteLine("");

            EndState = EndStates.NotStarted;
        }
        
        private void ReportWinner(EndStates endStates)
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

        public void BuildBoard()
        {
            Board = new List<List<Play>>(BoardX);
            
            for (var i = 0; i < BoardX; i++)
            {   
                Board.Add(new List<Play>(BoardY));
                var line = Board[i];
                
                for (var j = 0; j < BoardY; j++)
                {
                    line.Add(Play.Empty);
                }
            }
            
            // Escolhe duas casas para bloquear
            var rand = new Random(42);
            var firstBlocker = new[]
            {
                rand.Next(0, BoardX - 1), 
                rand.Next(0, BoardX - 1)
            };

            int[] secondBlocker = null;
            while (secondBlocker == null || secondBlocker.SequenceEqual(firstBlocker)) {
                secondBlocker = new[]
                {
                    rand.Next(0, BoardY - 1), 
                    rand.Next(0, BoardY - 1)
                };
            }
            
            // Bloqueia duas casas
            Board[firstBlocker[0]][firstBlocker[1]] = Play.Blocked;
            Board[secondBlocker[0]][secondBlocker[1]] = Play.Blocked;
        }

        public void SetBoardDimensions(string input)
        {
            if (input == null)
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de tabuleiro vazia.");
            }
            
            string boardSizeDescription = input
                .Replace(" ", "")
                .Replace("X", "x");

            if (!Regex.IsMatch(boardSizeDescription, "\\dx\\d"))
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de tabuleiro não legível.");
            }

            var boardDefSplit =
                (from dim in boardSizeDescription.Split('x')
                    select int.Parse(dim)
                )
                .ToList();
            
            if (boardDefSplit[0] >= 10 || boardDefSplit[1] >= 10)
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de tabuleiro grande demais.");
            }
            
            BoardX = boardDefSplit[0];
            BoardY = boardDefSplit[1];
        }

        private int CheckWinCondition()
        {
            return 0;
        }
    }
}