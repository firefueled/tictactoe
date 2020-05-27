using System.Collections.Generic;

namespace TicTacSad.Strategies
{
    public class CentralSpiralStrategy : MatchStrategy
    {
        public override int[] DoPlay(in List<List<Play>> board, Play player)
        {
            int[] next = ChoseNext(board);

            board[next[0]][next[1]] = player;
            return next;
        }

        private int[] ChoseNext(List<List<Play>> board)
        {
            var width = board.Count;
            var height = board[0].Count;

            var x = (int) width / 2;
            var y = (int) height / 2;

            var spiralLevel = 1;
            var spiralLevelCounter = 0;
            var currentDirection = 0;
            var triesCounter = 0;

            while (!IsEmpty(board, x, y))
            {
                if (currentDirection == 0)
                {
                    y += spiralLevel;
                    currentDirection = 1;
                }
                else if (currentDirection == 1)
                {
                    x -= spiralLevel;
                    currentDirection = 2;
                }
                else if (currentDirection == 2)
                {
                    y -= spiralLevel;
                    currentDirection = 3;
                }
                else if (currentDirection == 3)
                {
                    x += spiralLevel;
                    currentDirection = 0;
                }

                spiralLevelCounter++;

                if (spiralLevelCounter > 2)
                {
                    spiralLevelCounter = 0;
                    spiralLevel++;
                }

                if (triesCounter > 4)
                {
                    var randomPoint = GetRandomPoint(board);
                    x = randomPoint[0];
                    y = randomPoint[1];
                }
                
                triesCounter++;
            }

            return new[] {x, y};
        }

        private int[] GetRandomPoint(in List<List<Play>> board)
        {
            return GameUtils.GetRandomEmptyPlace(board);
        }

        private bool IsEmpty(List<List<Play>> board, int x, int y)
        {
            var width = board.Count;
            var height = board[0].Count;

            if (x < 0 || y < 0 || x >= width || y >= height)
                return false;

            return board[x][y] == Play.Empty;
        }
    }
}