using System.Collections.Generic;
using System.Linq;

namespace TicTacSad.Strategies
{
    public class BlockTwoAdjacent : MatchStrategy
    {
        public override int[] DoPlay(in List<List<Play>> board, Play player)
        {
            var candidates = FindCandidates(board);
            
            var chosen = candidates.First();

            var side = ChoseSide(chosen, board);

            board[side[0]][side[1]] = player;
            return side;
        }

        private int[] ChoseSide(List<int[]> chosen, List<List<Play>> board)
        {
            foreach (var side in chosen)
            {
            }

            return null;
        }

        private List<List<int[]>> FindCandidates(List<List<Play>> board)
        {
            throw new System.NotImplementedException();
        }
    }
}