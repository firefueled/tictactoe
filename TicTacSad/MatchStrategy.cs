using System.Collections.Generic;

namespace TicTacSad
{
    public abstract class MatchStrategy
    {
        public abstract EndStates DoPlay(in List<List<Play>> board, Play player);
    }
}