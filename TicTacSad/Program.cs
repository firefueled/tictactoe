using System;
using System.Collections.Generic;

namespace TicTacSad
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Init();

            try
            {
                // Lê tabuleiro
                Console.WriteLine("Digite o tamanho do tabuleiro. [axb]");
                var dimensionsRead = Console.ReadLine();
                game.SetBoardDimensions(dimensionsRead);

                game.BuildBoard();

                // Recebe definição de jogador. X ou O
                Console.WriteLine("Digite o nosso jogador. [x ou o]");
                var playerDefRead = Console.ReadLine();
                game.ReadPlayerDefinition(playerDefRead);

                PrintBoard(game.Board);

                // Define estratégia de jogo
                game.DefineMatchStrategy();

                while (true)
                {
                    Console.WriteLine("Digite sua jogada. [axb]");
                    var moveDef = Console.ReadLine();
                    var ourMove = game.PlayOneOtherMove(moveDef);
                    Console.WriteLine("Jogo em " + ourMove[0] + " X " + ourMove[1]);
                    PrintBoard(game.Board);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("*************");
                Console.WriteLine("Erro no Jogo:");
                Console.WriteLine(e);
                Console.WriteLine("*************");
            }
            finally
            {
                EndGame(game);
            }
        }

        private static void PrintBoard(List<List<Play>> board)
        {
            Console.WriteLine();
            foreach (var row in board)
            {
                var line = "";
                foreach (var col in row)
                {
                    var placeStr = "[ ]";
                    
                    if (col == Play.X)
                        placeStr = "[x]";
                    if (col == Play.O)
                        placeStr = "[o]";
                    if (col == Play.Blocked)
                        placeStr = "[#]";
                    
                    line += placeStr;
                }
                
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

        private static void EndGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}