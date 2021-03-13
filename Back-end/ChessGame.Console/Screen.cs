using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Linq;

namespace ChessGame.Console
{
    public static class Screen
    {
        private static readonly ConsoleColor _defaultForegroundColor = ConsoleColor.Yellow;

        public static void DisplayBoard(Board board)
        {
            System.Console.Clear();
            var originalFouregroundColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = _defaultForegroundColor;
            System.Console.WriteLine("   A   B   C   D   E   F   G   H");
            foreach (var line in Enum.GetValues(typeof(ELine)).Cast<ELine>().OrderByDescending(x => x))
            {
                System.Console.WriteLine("  --- --- --- --- --- --- --- ---");
                System.Console.Write((int)line);
                foreach (var column in Enum.GetValues(typeof(EColumn)).Cast<EColumn>())
                {
                    System.Console.Write("| ");
                    var piece = board.GetPieceFromPosition(new Position(column, line));
                    if (piece != null)
                    {
                        SetForegroundColorByPieceColor(piece.Color);
                        System.Console.Write($"{piece} ");
                        System.Console.ForegroundColor = _defaultForegroundColor;
                    }
                    else
                        System.Console.Write("  ");
                }
                System.Console.Write("|");
                System.Console.Write((int)line);
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  --- --- --- --- --- --- --- ---");
            System.Console.WriteLine("   A   B   C   D   E   F   G   H");
            System.Console.ForegroundColor = originalFouregroundColor;
        }

        private static void SetForegroundColorByPieceColor(EColor color)
        {
            System.Console.ForegroundColor = color == EColor.White ? ConsoleColor.White : ConsoleColor.Black;
        }
    }
}
