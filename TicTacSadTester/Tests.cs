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
        public void GameCanReachAnyEndState()
        {
            var game = new Game();
            WinCondition winCondition = game.Start();
            Assert.NotNull(winCondition);
            Assert.IsInstanceOf<WinCondition>(winCondition);
        }
    }
}