using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using TicTacSad.Strategies;

namespace TicTacSad
{
    public class Game
    {
        public int BoardX { get; private set; }
        public int BoardY { get; private set; }
        public Play Player { get; private set; }
        public MatchStrategy Strategy { get; private set; }

        public EndStates EndState { get; private set; }

        public List<List<Play>> Board { get; private set; }

        public int[] SecondBlocker { get; private set; }

        public int[] FirstBlocker { get; private set; }

        public void Init()
        {
            // Inicia programa
            Console.WriteLine("");
            Console.WriteLine("Jogo da Velha SAD");
            Console.WriteLine("");

            EndState = EndStates.NotStarted;
        }

        public string PlayOneMove()
        {
            var play = Strategy.DoPlay(Board, Player);
            return GameUtils.TranslateIntPosToBoardPos(play);
        }

        public void PlayOneOtherMove(string input)
        {
            var boardPos = ExtractBoardPos(input);
            PlayOneOtherMove(boardPos);            
        }
        
        public void PlayOneOtherMove(int[] pos)
        {
            var otherPlayer = Play.O;
            if (Player == Play.O)
                otherPlayer = Play.X;

            try
            {
                if (Board[pos[0]][pos[1]] != Play.Empty)
                    throw new ArgumentException("Tentou jogar em posição não-vazia.");
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentException("Tentou jogar em posição não-vazia.");
            }

            Board[pos[0]][pos[1]] = otherPlayer;
        }

        public void PlayMatch()
        {
            while (EndState == EndStates.NotEnded || EndState == EndStates.NotStarted)
            {
                Strategy.DoPlay(Board, Player);
            }
        }

        public string DefineMatchStrategy()
        {
            Strategy = new CentralSpiralStrategy();
            return Strategy.ToString();
        }

        public void ReadPlayerDefinition(string input)
        {
            if (input == null)
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de jogador vazia.");
            }

            var playerDescription = input
                .Replace(" ", "");

            if (Regex.IsMatch(playerDescription, "^[oO0]$"))
            {
                Player = Play.O;
            }
            else if (Regex.IsMatch(playerDescription, "^[xX]$"))
            {
                Player = Play.X;
            }
            else
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de jogador ilegível.");
            }
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
        }

        public void SetBoardDimensions(string input)
        {
            var boardDefSplit = ExtractBoardDimension(input);

            if (boardDefSplit[0] >= 10 || boardDefSplit[1] >= 10 || boardDefSplit[0] < 4 || boardDefSplit[1] < 4)
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de tabuleiro grande demais.");
            }

            BoardX = boardDefSplit[0];
            BoardY = boardDefSplit[1];
        }
        
        public void SetBlocker(string input)
        {
            var blockerCoords = ExtractBoardPos(input);
            if (FirstBlocker == null)
                FirstBlocker = blockerCoords;
            else
                SecondBlocker = blockerCoords;
            try
            {
                Board[blockerCoords[0]][blockerCoords[1]] = Play.Blocked;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Posição inválida.");
            }
        }
        
        private int[] ExtractBoardPos(string input)
        {
            if (input == null)
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de jogada vazia.");
            }

            if (!Regex.IsMatch(input, "^[abcdefghABCDEFGH][12345678]$"))
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de jogada ilegível.");
            }

            return GameUtils.TranslateBoardPosToIntPos(input);
        }

        private int[] ExtractBoardDimension(string input)
        {
            if (input == null)
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de tabuleiro vazia.");
            }

            var boardSizeDescription = input
                .Replace(" ", "")
                .Replace("X", "x");

            if (!Regex.IsMatch(boardSizeDescription, "^\\dx\\d$"))
            {
                EndState = EndStates.Error;
                throw new ArgumentException("Definição de tabuleiro ilegível.");
            }

            return (from dim in boardSizeDescription.Split('x')
                    select int.Parse(dim)
                )
                .ToArray();
        }

        private int CheckWinCondition()
        {
            return 0;
        }

        public string DefineMatchStrategy(string input)
        {
            Type foundStrategy = FindStrategy(input);

            if (foundStrategy == null)
                return DefineMatchStrategy();

            var instanceStrategy = Activator.CreateInstance(foundStrategy) as MatchStrategy;

            if (instanceStrategy == null)
                return DefineMatchStrategy();

            Strategy = instanceStrategy;
            return Strategy.ToString();
        }

        private static Type FindStrategy(string input)
        {
            if (input == null)
                return null;
            
            Type strategy = (from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.IsSubclassOf(typeof(MatchStrategy)) && t.Name.ToLower().Contains(input.ToLower())
                select t).FirstOrDefault();

            return strategy;
        }
    }
}