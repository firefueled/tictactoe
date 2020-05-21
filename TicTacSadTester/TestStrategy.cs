using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TicTacSad;

namespace TicTacSadTester
{
    [TestFixture]
    public class TestStrategy
    {
        [Test]
        public void RandomStrategy_PlaysOnePlay()
        {
            var strategy = new RandomStrategy();

            var game = new Game();
            game.Init();
            game.SetBoardDimensions("4x5");
            game.ReadPlayerDefinition("x");
            game.DefineMatchStrategy();
            game.BuildBoard();
            var board = game.Board;
            
            var availableBoardPlacesBefore = CountAvailableBoardPlaces(board);
            board = strategy.DoPlay(board, Play.X);
            var availableBoardPlacesAfter = CountAvailableBoardPlaces(board);
            
            Assert.AreEqual(1, availableBoardPlacesBefore - availableBoardPlacesAfter, 
                "A diferença da quantidade de casas antes e depois nao é -1.");
        }

        private static int CountAvailableBoardPlaces(List<List<Play>> board)
        {
            return 
                (from row in board
                    from col in row
                        where col == Play.Empty
                        select col).Count();
        }
    }
}