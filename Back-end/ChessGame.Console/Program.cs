using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Linq;

namespace ChessGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.BackgroundColor = Utils.GetBackgroundColor();
            System.Console.Clear();

            var gameplay = ConfigureGameplay();
            gameplay.StartGame();

            var kingInCheckmate = false;
            while (!kingInCheckmate)
            {
                Screen.DisplayBoard(gameplay.Board);

                var piece = PlayerRoundDefinePieceToMove(gameplay);
                while (piece == null || piece.Color != gameplay.PlayerRound.Color || piece.AvailableMovements().Count() == 0)
                {
                    Screen.DisplayBoard(gameplay.Board);
                    System.Console.WriteLine("Não existe peça sua com movimentos válidos na posição escolhida!");
                    piece = PlayerRoundDefinePieceToMove(gameplay);
                }

                var moved = false;
                while (!moved)
                {
                    Screen.DisplayBoard(gameplay.Board, piece.AvailableMovements());
                    var newPosition = PlayerRoundDefineNewPosition();
                    moved = gameplay.PlayerMove(piece, newPosition);
                    if (!moved)
                        System.Console.WriteLine("A nova posição escolhida para a peça é inválida!");
                }

                kingInCheckmate = HasKingInCheck(gameplay);
                if (kingInCheckmate)
                {
                    Screen.DisplayBoard(gameplay.Board);
                    System.Console.WriteLine("Cheque-mate!");
                    continue;
                }

                if (HasKingInCheck(gameplay))
                    System.Console.WriteLine("Cheque!");
            }
        }

        private static Player DefinePlayer(string screenMessage, EColor color)
        {
            System.Console.WriteLine(screenMessage);
            System.Console.Write("Nome: ");
            var namePlayer = System.Console.ReadLine();
            return new Player(namePlayer, color);
        }

        private static Gameplay ConfigureGameplay()
        {
            var playerOne = DefinePlayer("Defina o jogador branco", EColor.White);
            var playerTwo = DefinePlayer("Defina o jogador preto", EColor.Black);
            return new Gameplay(new Board(), playerOne, playerTwo);
        }

        private static Piece PlayerRoundDefinePieceToMove(Gameplay gameplay)
        {
            System.Console.WriteLine($"{gameplay.PlayerRound.Name}, escolha a posição que se encontra a peça que você deseja movimentar");
            System.Console.Write("Coluna (A..Z): ");
            EColumn column;
            while (!TryParseStringToEColumn(System.Console.ReadLine().ToUpper(), out column))
                System.Console.WriteLine("O valor da coluna escolhido é inválido!");

            System.Console.WriteLine();
            System.Console.Write("Linha (1..8): ");
            ELine line;
            while (!TryParseStringToELine(System.Console.ReadLine(), out line))
                System.Console.WriteLine("O valor da linha escolhido é inválido!");

            return gameplay.GetPieceFromPosition(new Position(column, line));
        }

        private static Position PlayerRoundDefineNewPosition()
        {
            System.Console.WriteLine($"Escolha a nova posição para a peça");
            System.Console.Write("Coluna (A..Z): ");
            EColumn column;
            while (!TryParseStringToEColumn(System.Console.ReadLine().ToUpper(), out column))
                System.Console.WriteLine("O valor da coluna escolhido é inválido!");

            System.Console.WriteLine();
            System.Console.Write("Linha (1..8): ");
            ELine line;
            while (!TryParseStringToELine(System.Console.ReadLine(), out line))
                System.Console.WriteLine("O valor da linha escolhido é inválido!");

            return new Position(column, line);
        }

        private static bool TryParseStringToEColumn(string value, out EColumn column)
        {
            char columnChoosed;
            column = EColumn.A;
            if (!char.TryParse(value, out columnChoosed))
                return false;

            if (!Enum.GetValues(typeof(EColumn)).Cast<EColumn>().Any(x => (char)x == columnChoosed))
                return false;

            column = (EColumn)columnChoosed;

            return true;
        }

        private static bool TryParseStringToELine(string value, out ELine line)
        {
            int lineChoosed;
            line = ELine.One;
            if (!int.TryParse(value, out lineChoosed))
                return false;

            if (!Enum.GetValues(typeof(ELine)).Cast<ELine>().Any(x => (int)x == lineChoosed))
                return false;

            line = (ELine)lineChoosed;

            return true;
        }

        private static bool HasKingInCheck(Gameplay gameplay)
        {
            foreach (var king in gameplay.Board.Pieces.Where(p => p is King).Select(p => (King)p))
                if (gameplay.IsCheck(king))
                    return true;

            return false;
        }
    }
}
