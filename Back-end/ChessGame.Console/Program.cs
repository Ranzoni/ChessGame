using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;

namespace ChessGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.BackgroundColor = System.ConsoleColor.DarkGray;
            System.Console.Clear();

            var gameplay = ConfigureGameplay();
            gameplay.StartGame();

            Screen.DisplayBoard(gameplay.Board);
        }

        public static Player DefinePlayer(string screenMessage, EColor color)
        {
            System.Console.WriteLine(screenMessage);
            System.Console.Write("Nome: ");
            var namePlayer = System.Console.ReadLine();
            return new Player(namePlayer, color);
        }

        public static Gameplay ConfigureGameplay()
        {
            var playerOne = DefinePlayer("Defina o jogador branco", EColor.White);
            var playerTwo = DefinePlayer("Defina o jogador preto", EColor.Black);
            return new Gameplay(new Board(), playerOne, playerTwo);
        }
    }
}
