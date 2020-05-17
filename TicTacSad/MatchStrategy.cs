using System.Collections.Generic;

namespace TicTacSad
{
    public abstract class MatchStrategy
    {
        public abstract void DoPlay(List<List<Play>> board, Play player);
    }
}