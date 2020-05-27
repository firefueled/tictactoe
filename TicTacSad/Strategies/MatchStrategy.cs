using System.Collections.Generic;

namespace TicTacSad.Strategies
{
    public abstract class MatchStrategy
    {
        public abstract int[] DoPlay(in List<List<Play>> board, Play player);
    }
}