using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacSad
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Init();

            // Define estratégia de jogo
            var strategyDef = args.FirstOrDefault();
            var strategy = game.DefineMatchStrategy(strategyDef);
            Console.WriteLine("Estratégia escolhida: " + strategy);
            Console.WriteLine();

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

                var firstPlay = true;
                
                while (true)
                {
                    try
                    {
                        if (firstPlay && game.Player == Play.X)
                        {
                            var ourMove = game.PlayOneMove();
                            Console.WriteLine("Eu jogo em " + ourMove.ToUpper());
                        }
                        else
                        {
                            Console.WriteLine("Digite sua jogada.");
                            var moveDef = Console.ReadLine();
                            game.PlayOneOtherMove(moveDef);
                            
                            var ourMove = game.PlayOneMove();
                            Console.WriteLine("Eu jogo em " + ourMove.ToUpper());
                        }

                        firstPlay = false;
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro na jogada. Jogue novamente.");
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
            var header = "   A  B  C  D  E  F  G  H  I  J  K ";
            header = header.Substring(0, board[0].Count * 3 + 2);
            Console.WriteLine(header);

            for (var i = 0; i < board.Count; i++)
            {
                var row = board[i];
                var line = "";
                foreach (var col in row)
                {
                    var placeStr = "[ ]";

                    if (col == Play.X)
                        placeStr = "[x]";
                    else if (col == Play.O)
                        placeStr = "[o]";
                    else if (col == Play.Blocked)
                        placeStr = "[#]";

                    line += placeStr;
                }

                Console.WriteLine(i + 1 + " " + line);
            }

            Console.WriteLine();
        }
    }
}