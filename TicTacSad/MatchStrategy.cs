using System.Collections.Generic;

namespace TicTacSad
{
    public abstract class MatchStrategy
    {
        public abstract List<List<Play>> DoPlay(List<List<Play>> board, Play player);
    }
}