using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Console
{
    public static class Screen
    {
        private static readonly ConsoleColor _defaultForegroundColor = ConsoleColor.Yellow;

        public static void DisplayBoard(Board board, IEnumerable<Position> availablePositions = null)
        {
            System.Console.Clear();
            var originalFouregroundColor = System.Console.ForegroundColor;
            DisplayTop();
            DisplayHouses(board, availablePositions);
            DisplayEnd();
            DisplayDeadPieces(board);
            System.Console.ForegroundColor = originalFouregroundColor;
        }

        private static void DisplayTop()
        {
            System.Console.ForegroundColor = _defaultForegroundColor;
            System.Console.WriteLine("   A   B   C   D   E   F   G   H");
        }

        private static void DisplayHouses(Board board, IEnumerable<Position> availablePositions = null)
        {
            foreach (var line in Enum.GetValues(typeof(ELine)).Cast<ELine>().OrderByDescending(x => x))
            {
                System.Console.WriteLine("  --- --- --- --- --- --- --- ---");
                System.Console.Write((int)line);
                foreach (var column in Enum.GetValues(typeof(EColumn)).Cast<EColumn>())
                {
                    System.Console.Write("|");
                    var position = new Position(column, line);
                    var piece = board.GetPieceFromPosition(position);
                    if (availablePositions != null && availablePositions.Any(p => p.Equals(position)))
                        System.Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    if (piece != null)
                    {
                        SetForegroundColorByPieceColor(piece.Color);
                        System.Console.Write($" {piece} ");
                        System.Console.ForegroundColor = _defaultForegroundColor;
                    }
                    else
                        System.Console.Write("   ");
                    System.Console.BackgroundColor = Utils.GetBackgroundColor();
                }
                System.Console.Write("|");
                System.Console.Write((int)line);
                System.Console.WriteLine();
            }
        }

        private static void DisplayEnd()
        {
            System.Console.WriteLine("  --- --- --- --- --- --- --- ---");
            System.Console.WriteLine("   A   B   C   D   E   F   G   H");
        }

        private static void DisplayDeadPieces(Board board)
        {
            if (board.DeadPieces.Any(p => p.Color == EColor.White))
            {
                SetForegroundColorByPieceColor(EColor.White);
                System.Console.Write("Peças brancas mortas: ");
                foreach (var piece in board.DeadPieces.Where(p => p.Color == EColor.White))
                    System.Console.Write($"{piece} ");
                System.Console.WriteLine();
            }

            if (board.DeadPieces.Any(p => p.Color == EColor.Black))
            {
                SetForegroundColorByPieceColor(EColor.Black);
                System.Console.Write("Peças pretas mortas: ");
                foreach (var piece in board.DeadPieces.Where(p => p.Color == EColor.Black))
                    System.Console.Write($"{piece} ");
                System.Console.WriteLine();
            }
        }

        private static void SetForegroundColorByPieceColor(EColor color)
        {
            System.Console.ForegroundColor = color == EColor.White ? ConsoleColor.White : ConsoleColor.Black;
        }
    }
}
