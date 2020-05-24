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
                // Recebe definição de jogador. X ou O
                Console.WriteLine("Digite o nosso jogador. [X ou O]");
                var playerDefRead = Console.ReadLine();
                game.ReadPlayerDefinition(playerDefRead);

                // Lê tabuleiro
                Console.WriteLine("Digite o tamanho do tabuleiro. [axb]");
                var dimensionsRead = Console.ReadLine();
                game.SetBoardDimensions(dimensionsRead);
                game.BuildBoard();

                while (game.FirstBlocker == null || game.SecondBlocker == null)
                {
                    PrintBoard(game.Board);
                    
                    // Lê primeiro bloqueio
                    Console.WriteLine("Digite o primeiro bloqueio. [axb]");
                    var firstBlockerDef = Console.ReadLine();
                    game.SetBlocker(firstBlockerDef);
                    
                    PrintBoard(game.Board);
                    
                    // Lê segundo bloqueio
                    Console.WriteLine("Digite o segundo bloqueio. [axb]");
                    var secondBlockerDef = Console.ReadLine();
                    game.SetBlocker(secondBlockerDef);
                }


                PrintBoard(game.Board);

                // Define estratégia de jogo
                game.DefineMatchStrategy();

                while (true)
                {
                    Console.WriteLine("Digite sua jogada.");
                    try
                    {
                        var moveDef = Console.ReadLine();
                        game.PlayOneOtherMove(moveDef);
                        var ourMove = game.PlayOneMove();
                        Console.WriteLine("Eu jogo em " + ourMove.ToUpper());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro na jogada.");
                        Console.WriteLine(e.Message);
                    }
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
        }

        private static void PrintBoard(List<List<Play>> board)
        {
            Console.WriteLine();
            var header1 = "   A  B  C  D  E  F  G  H ";
            header1 = header1.Substring(0, board[0].Count * 3 + 2);
            Console.WriteLine(header1);

            for (var i = 0; i < board.Count; i++)
            {
                var row = board[i];
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

                Console.WriteLine(i + 1 + " " + line);
            }

            Console.WriteLine();
        }

        private static void EndGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}