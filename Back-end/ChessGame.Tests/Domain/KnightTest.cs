using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class KnightTest
    {
        private static readonly Board _board = BoardBuilder.New().Build();
        private readonly Knight _knight;

        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.A, ELine.Two) },
                new object[] { null, new Position(EColumn.A, ELine.Four) },
                new object[] { null, new Position(EColumn.B, ELine.One) },
                new object[] { null, new Position(EColumn.B, ELine.Five) },
                new object[] { null, new Position(EColumn.D, ELine.One) },
                new object[] { null, new Position(EColumn.D, ELine.Five) },
                new object[] { null, new Position(EColumn.E, ELine.Two) },
                new object[] { null, new Position(EColumn.E, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Knight(new Position(EColumn.B, ELine.Three), EColor.Black, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Rook(new Position(EColumn.C, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Rook(new Position(EColumn.A, ELine.Three), EColor.Black, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Rook(new Position(EColumn.A, ELine.Four), EColor.White, _board), new Position(EColumn.A, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.B, ELine.Three), EColor.White, _board), new Position(EColumn.A, ELine.Four) },
                new object[] { new Knight(new Position(EColumn.A, ELine.Three), EColor.Black, _board), new Position(EColumn.A, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Four), EColor.Black, _board), new Position(EColumn.A, ELine.Four) },
                new object[] { new Knight(new Position(EColumn.B, ELine.Four), EColor.Black, _board), new Position(EColumn.A, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.B, ELine.One), EColor.White, _board), new Position(EColumn.B, ELine.One) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.One), EColor.Black, _board), new Position(EColumn.B, ELine.One) },
                new object[] { new Rook(new Position(EColumn.C, ELine.Two), EColor.Black, _board), new Position(EColumn.B, ELine.One) },
                new object[] { new Knight(new Position(EColumn.B, ELine.Two), EColor.Black, _board), new Position(EColumn.B, ELine.One) },
                new object[] { new Rook(new Position(EColumn.B, ELine.Five), EColor.White, _board), new Position(EColumn.B, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Five), EColor.Black, _board), new Position(EColumn.B, ELine.Five) },
                new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.White, _board), new Position(EColumn.B, ELine.Five) },
                new object[] { new Rook(new Position(EColumn.B, ELine.Four), EColor.Black, _board), new Position(EColumn.B, ELine.Five) },
                new object[] { new Knight(new Position(EColumn.D, ELine.One), EColor.White, _board), new Position(EColumn.D, ELine.One) },
                new object[] { new Knight(new Position(EColumn.C, ELine.Two), EColor.White, _board), new Position(EColumn.D, ELine.One) },
                new object[] { new Rook(new Position(EColumn.C, ELine.One), EColor.White, _board), new Position(EColumn.D, ELine.One) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Two), EColor.Black, _board), new Position(EColumn.D, ELine.One) },
                new object[] { new Knight(new Position(EColumn.D, ELine.Five), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Knight(new Position(EColumn.C, ELine.Five), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Knight(new Position(EColumn.C, ELine.Four), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Three), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Rook(new Position(EColumn.D, ELine.Four), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Rook(new Position(EColumn.E, ELine.Two), EColor.White, _board), new Position(EColumn.E, ELine.Two) },
                new object[] { new Knight(new Position(EColumn.E, ELine.Four), EColor.White, _board), new Position(EColumn.E, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Knight(new Position(EColumn.A, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Rook(new Position(EColumn.A, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Rook(new Position(EColumn.A, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Knight(new Position(EColumn.A, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) },
                new object[] { new Rook(new Position(EColumn.A, ELine.Two), EColor.White, _board), new Position(EColumn.A, ELine.Two) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { null, new Position(EColumn.C, ELine.Three) },
               new object[] { null, new Position(EColumn.A, ELine.One) },
               new object[] { null, new Position(EColumn.A, ELine.Three) },
               new object[] { null, new Position(EColumn.B, ELine.Two) },
               new object[] { null, new Position(EColumn.B, ELine.Four) },
               new object[] { null, new Position(EColumn.B, ELine.Three) },
               new object[] { null, new Position(EColumn.D, ELine.Two) },
               new object[] { null, new Position(EColumn.D, ELine.Three) },
               new object[] { null, new Position(EColumn.D, ELine.Four) },
               new object[] { null, new Position(EColumn.E, ELine.One) },
               new object[] { null, new Position(EColumn.E, ELine.Three) },
               new object[] { null, new Position(EColumn.E, ELine.Five) },
               new object[] { null, new Position(EColumn.E, ELine.Six) },
               new object[] { null, new Position(EColumn.H, ELine.Eight) },
               new object[] { null, new Position(EColumn.G, ELine.Seven) },
               new object[] { new Knight(new Position(EColumn.A, ELine.Two), EColor.Black, _board), new Position(EColumn.A, ELine.Two) },
               new object[] { new Rook(new Position(EColumn.A, ELine.Four), EColor.Black, _board), new Position(EColumn.A, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.B, ELine.One), EColor.Black, _board), new Position(EColumn.B, ELine.One) },
               new object[] { new Knight(new Position(EColumn.B, ELine.Five), EColor.Black, _board), new Position(EColumn.B, ELine.Five) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.One), EColor.Black, _board), new Position(EColumn.D, ELine.One) },
               new object[] { new Rook(new Position(EColumn.D, ELine.Five), EColor.Black, _board), new Position(EColumn.D, ELine.Five) },
               new object[] { new Pawn(new Position(EColumn.E, ELine.Two), EColor.Black, _board), new Position(EColumn.E, ELine.Two) },
               new object[] { new Knight(new Position(EColumn.E, ELine.Four), EColor.Black, _board), new Position(EColumn.E, ELine.Four) }
           };

        public KnightTest()
        {
            _board.ClearBoard();
            _knight = KnightBuilder.New().WithColor(EColor.Black).WithBoard(_board).Build();
            _board.AddPiece(_knight);
        }

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMoveKnight(Piece pieceToAddBoard, Position newPosition)
        {
            _board.AddPiece(pieceToAddBoard);
            var moved = _knight.Move(newPosition);
            Assert.True(moved && _knight.Position.Equals(newPosition));
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMoveKnight(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _knight.Position;
            _board.AddPiece(pieceToAddBoard);
            var notMoved = !_knight.Move(newPosition);
            Assert.True(notMoved && _knight.Position.Equals(actualPosition));
        }
    }
}
