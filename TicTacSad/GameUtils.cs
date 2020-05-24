using System;
using System.Collections.Generic;
using System.Linq;
using TicTacSad;

namespace TicTacSad
{
    public static class GameUtils
    {
        public static int CountAvailableBoardPlaces(List<List<Play>> board)
        {
            return 
                (from row in board
                    from col in row
                    where col == Play.Empty
                    select col).Count();
        }

        public static List<List<Play>> BuildBoard(int length, int width)
        {
            var board = new List<List<Play>>(length);
            
            for (var i = 0; i < length; i++)
            {   
                board.Add(new List<Play>(width));
                var line = board[i];
                
                for (var j = 0; j < width; j++)
                {
                    line.Add(Play.Empty);
                }
            }
            
            // Escolhe duas casas para bloquear
            var rand = new Random();
            var firstBlocker = new[]
            {
                rand.Next(0, length - 1), 
                rand.Next(0, length - 1)
            };

            int[] secondBlocker = null;
            while (secondBlocker == null || secondBlocker.SequenceEqual(firstBlocker)) {
                secondBlocker = new[]
                {
                    rand.Next(0, width - 1), 
                    rand.Next(0, width - 1)
                };
            }
            
            // Bloqueia duas casas
            board[firstBlocker[0]][firstBlocker[1]] = Play.Blocked;
            board[secondBlocker[0]][secondBlocker[1]] = Play.Blocked;
            return board;
        }

        public static int[] GetRandomEmptyPlace(List<List<Play>> board)
        {
            var rand = new Random();
            var pos = new[] {rand.Next(0, board.Count), rand.Next(0, board[0].Count)};
            while (board[pos[0]][pos[1]] != Play.Empty)
            {
                pos = new[] {rand.Next(0, board.Count), rand.Next(0, board[0].Count)};
            }

            return pos;
        }

        public static int[] TranslateBoardPosToIntPos(string pos)
        {
            int[] intPos = {0, 0};
            switch (pos[0].ToString().ToLower())
            {
                case "a": intPos[1] = 0; break;
                case "b": intPos[1] = 1; break;
                case "c": intPos[1] = 2; break;
                case "d": intPos[1] = 3; break;
                case "e": intPos[1] = 4; break;
                case "f": intPos[1] = 5; break;
                case "g": intPos[1] = 6; break;
            }
            switch (pos[1].ToString().ToLower())
            {
                case "1": intPos[0] = 0; break;
                case "2": intPos[0] = 1; break;
                case "3": intPos[0] = 2; break;
                case "4": intPos[0] = 3; break;
                case "5": intPos[0] = 4; break;
                case "6": intPos[0] = 5; break;
                case "7": intPos[0] = 6; break;
            }
            return intPos;
        } 
        
        public static string TranslateIntPosToBoardPos(int[] pos)
        {
            var boardPos = "";
            switch (pos[1])
            {
                case 0: boardPos += 'A'; break;
                case 1: boardPos += 'B'; break;
                case 2: boardPos += 'C'; break;
                case 3: boardPos += 'D'; break;
                case 4: boardPos += 'E'; break;
                case 5: boardPos += 'F'; break;
                case 6: boardPos += 'G'; break;
            }
            switch (pos[0])
            {
                case 0: boardPos += '1'; break;
                case 1: boardPos += '2'; break;
                case 2: boardPos += '3'; break;
                case 3: boardPos += '4'; break;
                case 4: boardPos += '5'; break;
                case 5: boardPos += '6'; break;
                case 6: boardPos += '7'; break;
            }
            return boardPos;
        } 
    }
}