using System;
using NUnit.Framework;
using TicTacSad;

namespace TicTacSad
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
            Assert.NotNull(game.FirstBlocker);
            Assert.NotNull(game.SecondBlocker);
            Assert.IsNotEmpty(game.FirstBlocker);
            Assert.IsNotEmpty(game.SecondBlocker);
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

        [TestCase("X", Play.X)]
        [TestCase("x", Play.X)]
        [TestCase("O", Play.O)]
        [TestCase("o", Play.O)]
        [TestCase(" o ", Play.O)]
        [TestCase(" o", Play.O)]
        [TestCase("o ", Play.O)]
        [TestCase(" x ", Play.X)]
        [TestCase(" x", Play.X)]
        [TestCase("x ", Play.X)]
        public void ReadsPlayerDefinition(string playerString, Play player)
        {
            var game = new Game();
            game.Init();
            game.ReadPlayerDefinition(playerString);
            Assert.AreEqual(game.Player, player);
        }
        
        [TestCase("a")]
        [TestCase("A")]
        [TestCase("b")]
        [TestCase("B")]
        [TestCase("xx")]
        [TestCase("yy")]
        [TestCase("XX")]
        [TestCase("YY")]
        [TestCase("")]
        [TestCase(".")]
        [TestCase("ax")]
        [TestCase("ay")]
        public void ThrowsOnInvalidPlayerDefinition(string playerString)
        {
            var game = new Game();
            game.Init();
            Assert.Throws<ArgumentException>(() =>
            {
                game.ReadPlayerDefinition(playerString);
            });
        }        
        
        [Test]
        public void DefinesAStrategy()
        {
            var game = new Game();
            game.Init();
            Assert.DoesNotThrow(() =>
            {
                game.DefineMatchStrategy();
            });
            Assert.NotNull(game.Strategy);
            Assert.IsInstanceOf<MatchStrategy>(game.Strategy);
        }
        
        [Test]
        public void ReachesAnEnd()
        {
            var game = new Game();
            game.Init();
            game.SetBoardDimensions("4x5");
            game.BuildBoard();
            game.ReadPlayerDefinition("x");
            game.DefineMatchStrategy();
            game.PlayMatch();

            var endState = game.EndState;
            
            Assert.NotNull(endState);
            Assert.IsInstanceOf<EndStates>(endState);
            
            var boardPlacesLeft = GameUtils.CountAvailableBoardPlaces(game.Board);
            Assert.AreEqual(0, boardPlacesLeft);
        }
        
        [Test]
        public void PlaysOneMove()
        {
            var game = new Game();
            game.Init();
            game.SetBoardDimensions("4x5");
            game.BuildBoard();
            game.ReadPlayerDefinition("x");
            game.DefineMatchStrategy();

            // Get random empty position
            var pos = GameUtils.GetRandomEmptyPlace(game.Board);

            // Plays the one move
            var availableBoardPlacesBefore = GameUtils.CountAvailableBoardPlaces(game.Board);
            game.PlayOneMove(pos[0] + "x" + pos[1]);
            var availableBoardPlacesAfter = GameUtils.CountAvailableBoardPlaces(game.Board);
            
            Assert.AreEqual(1, availableBoardPlacesBefore - availableBoardPlacesAfter, 
                "A diferença da quantidade de casas antes e depois nao é 1.");
        }
        
        
        [Test]
        public void ThrowsOn_InvalidMove()
        {
            var game = new Game();
            game.Init();
            game.SetBoardDimensions("4x5");
            game.BuildBoard();
            game.ReadPlayerDefinition("x");
            game.DefineMatchStrategy();

            Assert.Throws<ArgumentException>(() =>
            {
                game.PlayOneMove(game.FirstBlocker);
            });
            
            Assert.Throws<ArgumentException>(() =>
            {
                game.PlayOneMove(game.SecondBlocker);
            });
        }
    }
}