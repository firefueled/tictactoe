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
            Assert.NotNull(game.WinCondition);
            Assert.IsInstanceOf<WinCondition>(game.WinCondition);
            Assert.AreEqual(WinCondition.NotStarted, game.WinCondition);
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
        public void ErrorsOnInvalidBoardDimensions(string input)
        {
            var game = new Game();
            game.SetBoardDimensions(input);
            Assert.AreEqual(game.WinCondition, WinCondition.Error); 
        }
    }
}