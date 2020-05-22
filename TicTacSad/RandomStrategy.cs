using System;
using System.Collections.Generic;

namespace TicTacSad
{
    public class RandomStrategy : MatchStrategy
    {
        public override int[] DoPlay(in List<List<Play>> board, Play player)
        {
            var boardSize = board.Count + board[0].Count;
            var triesCount = 0;
            
            var randomPlace = GameUtils.GetRandomEmptyPlace(board);
            while (board[randomPlace[0]][randomPlace[1]] != Play.Empty && triesCount < boardSize)
            {
                randomPlace = GameUtils.GetRandomEmptyPlace(board);
                triesCount++;
            }
            
            if (triesCount < boardSize)
                board[randomPlace[0]][randomPlace[1]] = player;

            return randomPlace;
        }

        private static int[] GetRandomPlace(int length, int height)
        {
            var rand = new Random();
            return new[] { rand.Next(0, length - 1), rand.Next(0, height - 1) };
        }
    }
}