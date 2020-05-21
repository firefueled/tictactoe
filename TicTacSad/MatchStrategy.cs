using System.Collections.Generic;

namespace TicTacSad
{
    public abstract class MatchStrategy
    {
        public abstract int[] DoPlay(in List<List<Play>> board, Play player);
    }
}