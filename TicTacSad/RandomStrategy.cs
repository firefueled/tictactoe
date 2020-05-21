using System;
using System.Collections.Generic;

namespace TicTacSad
{
    public class RandomStrategy : MatchStrategy
    {
        public override List<List<Play>> DoPlay(List<List<Play>> board, Play player)
        {
            var length = board.Count;
            var height = board[0].Count;
            var boardSize = length + height;
            var triesCount = 0;
            
            var randomPlace = GetRandomPlace(length, height);
            while (board[randomPlace[0]][randomPlace[1]] != Play.Empty && triesCount < boardSize)
            {
                randomPlace = GetRandomPlace(length, height);
                triesCount++;
            }
            
            if (triesCount < boardSize)
                board[randomPlace[0]][randomPlace[1]] = player;
            
            return board;
        }

        private static int[] GetRandomPlace(int length, int height)
        {
            var rand = new Random();
            return new[] { rand.Next(0, length - 1), rand.Next(0, height - 1) };
        }
    }
}