using System;

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
                var dimensionsRead = Console.ReadLine();
                game.SetBoardDimensions(dimensionsRead);

                game.BuildBoard();

                // Recebe definição de jogador. X ou O
                var playerDefRead = Console.ReadLine();
                game.ReadPlayerDefinition(playerDefRead);

                // Define estratégia de jogo
                game.DefineMatchStrategy();

                // Passa controle para o Game jogar 
                game.PlayMatch();

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

        private static void EndGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}