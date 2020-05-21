using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TicTacSad;

namespace TicTacSadTester
{
    [TestFixture]
    public class TestStrategy
    {
        [TestCase(typeof(RandomStrategy))]
        public void Strategy_PlaysOnePlay<T>(T strategyType) where T: MatchStrategy
        {
            MatchStrategy strategy = Activator.CreateInstance<T>();
            var board = TestUtils.BuildBoard(4, 5);
            
            var availableBoardPlacesBefore = TestUtils.CountAvailableBoardPlaces(board);
            strategy.DoPlay(board, Play.X);
            var availableBoardPlacesAfter = TestUtils.CountAvailableBoardPlaces(board);
            
            Assert.AreEqual(1, availableBoardPlacesBefore - availableBoardPlacesAfter, 
                "A diferença da quantidade de casas antes e depois nao é -1.");
        }
    }
}