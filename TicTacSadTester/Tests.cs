using System;
using NUnit.Framework;
using TicTacSad;

namespace TicTacSadTester
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CanCreateGame()
        {
            Assert.DoesNotThrow(() => new Game());
        }
        
        [Test]
        public void CanReachDefaultState()
        {
            var game = new Game();
            game.Init();
            Assert.NotNull(game.EndState);
            Assert.IsInstanceOf<EndStates>(game.EndState);
            Assert.AreEqual(EndStates.NotStarted, game.EndState);
        }
        
        [TestCase("4x5")]
        [TestCase("4X5")]
        [TestCase(" 4x5")]
        [TestCase("4 x5")]
        [TestCase("4x 5")]
        [TestCase("4x5 ")]
        [TestCase(" 4x5")]
        [TestCase(" 4 x5")]
        [TestCase(" 4 x 5")]
        [TestCase(" 4 x 5 ")]
        [TestCase("  4  x  5  ")]
        public void CanReadBoardDimensions(string input)
        {
            var game = new Game();
            game.SetBoardDimensions(input);
            Assert.AreEqual(4, game.BoardX); 
            Assert.AreEqual(5, game.BoardY); 
        }
        
        [TestCase("ax5")]
        [TestCase("4xb")]
        [TestCase("4v5")]
        [TestCase("4Y5")]
        [TestCase("10x5")]
        [TestCase("4x10")]
        [TestCase("")]
        [TestCase("x")]
        [TestCase("ab")]
        [TestCase(".")]
        public void ThrowsOnInvalidBoardDimensions(string input)
        {
            var game = new Game();
            Assert.Throws<ArgumentException>(() => game.SetBoardDimensions(input));
            Assert.AreEqual(game.EndState, EndStates.Error); 
        }

        [Test]
        public void BuildsBoardWithCorrectContent()
        {
            var game = new Game();
            game.Init();
            game.SetBoardDimensions("4x5");
            game.BuildBoard();
            
            var blockerCount = 0;
            foreach (var line in game.Board)
            {
                foreach (Play play in line)
                {
                    if (blockerCount < 2 && play.Equals(Play.Blocked))
                    {
                        blockerCount++;
                    }
                    else
                    {
                        Assert.AreEqual(Play.Empty, play);
                    }
                }
            }
            Assert.AreEqual(2, blockerCount);
        }

        [TestCase("4x5", 4, 5)]
        [TestCase("5x4", 5, 4)]
        [TestCase("6x5", 6, 5)]
        [TestCase("5x6", 5, 6)]
        [TestCase("4x6", 4, 6)]
        [TestCase("6x4", 6, 4)]
        public void BuildsBoardWithCorrectSize(string size, int x, int y)
        {
            var game = new Game();
            game.Init();
            game.SetBoardDimensions(size);
            game.BuildBoard();
            var board = game.Board;
            
            Assert.AreEqual(x, board.Count);
            for (var i = 0; i < x; i++)
            {
                Assert.AreEqual(y, board[i].Count);
            }
        }
    }
}