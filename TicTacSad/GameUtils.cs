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
    }
}