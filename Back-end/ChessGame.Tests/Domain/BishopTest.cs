using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using ChessGame.Tests.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class BishopTest
    {
        private static readonly Board _board = BoardBuilder.New().Build();
        private readonly Bishop _bishop;

        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.D, ELine.Two) },
                new object[] { null, new Position(EColumn.C, ELine.One) },
                new object[] { null, new Position(EColumn.F, ELine.Two) },
                new object[] { null, new Position(EColumn.G, ELine.One) },
                new object[] { null, new Position(EColumn.D, ELine.Four) },
                new object[] { null, new Position(EColumn.C, ELine.Five) },
                new object[] { null, new Position(EColumn.B, ELine.Six) },
                new object[] { null, new Position(EColumn.A, ELine.Seven) },
                new object[] { null, new Position(EColumn.F, ELine.Four) },
                new object[] { null, new Position(EColumn.G, ELine.Five) },
                new object[] { null, new Position(EColumn.H, ELine.Six) },
                new object[] { new Rook(new Position(EColumn.D, ELine.Two), EColor.Black, _board), new Position(EColumn.D, ELine.Two) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.One), EColor.Black, _board), new Position(EColumn.C, ELine.One) },
                new object[] { new Pawn(new Position(EColumn.F, ELine.Two), EColor.Black, _board), new Position(EColumn.F, ELine.Two) },
                new object[] { new Rook(new Position(EColumn.G, ELine.One), EColor.Black, _board), new Position(EColumn.G, ELine.One) },
                new object[] { new Rook(new Position(EColumn.D, ELine.Four), EColor.Black, _board), new Position(EColumn.D, ELine.Four) },
                new object[] { new Knight(new Position(EColumn.C, ELine.Five), EColor.Black, _board), new Position(EColumn.C, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Six), EColor.Black, _board), new Position(EColumn.B, ELine.Six) },
                new object[] { new Rook(new Position(EColumn.A, ELine.Seven), EColor.Black, _board), new Position(EColumn.A, ELine.Seven) },
                new object[] { new Pawn(new Position(EColumn.F, ELine.Four), EColor.Black, _board), new Position(EColumn.F, ELine.Four) },
                new object[] { new Knight(new Position(EColumn.G, ELine.Five), EColor.Black, _board), new Position(EColumn.G, ELine.Five) },
                new object[] { new Knight(new Position(EColumn.H, ELine.Six), EColor.Black, _board), new Position(EColumn.H, ELine.Six) },
                new object[] { new Rook(new Position(EColumn.C, ELine.One), EColor.White, _board), new Position(EColumn.D, ELine.Two) },
                new object[] { new Pawn(new Position(EColumn.G, ELine.One), EColor.Black, _board), new Position(EColumn.F, ELine.Two) },
                new object[] { new Rook(new Position(EColumn.C, ELine.Five), EColor.White, _board), new Position(EColumn.D, ELine.Four) },
                new object[] { new Knight(new Position(EColumn.B, ELine.Six), EColor.Black, _board), new Position(EColumn.C, ELine.Five) },
                new object[] { new Knight(new Position(EColumn.A, ELine.Seven), EColor.Black, _board), new Position(EColumn.C, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Seven), EColor.Black, _board), new Position(EColumn.B, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.G, ELine.Five), EColor.White, _board), new Position(EColumn.F, ELine.Four) },
                new object[] { new Knight(new Position(EColumn.H, ELine.Six), EColor.Black, _board), new Position(EColumn.G, ELine.Five) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { null, new Position(EColumn.E, ELine.Three) },
               new object[] { null, new Position(EColumn.D, ELine.One) },
               new object[] { null, new Position(EColumn.B, ELine.One) },
               new object[] { null, new Position(EColumn.F, ELine.Three) },
               new object[] { null, new Position(EColumn.G, ELine.Four) },
               new object[] { null, new Position(EColumn.H, ELine.Four) },
               new object[] { null, new Position(EColumn.C, ELine.Seven) },
               new object[] { null, new Position(EColumn.B, ELine.Eight) },
               new object[] { null, new Position(EColumn.A, ELine.Six) },
               new object[] { null, new Position(EColumn.A, ELine.Four) },
               new object[] { null, new Position(EColumn.B, ELine.Five) },
               new object[] { null, new Position(EColumn.G, ELine.Six) },
               new object[] { new Rook(new Position(EColumn.D, ELine.Two), EColor.White, _board), new Position(EColumn.D, ELine.Two) },
               new object[] { new Knight(new Position(EColumn.C, ELine.One), EColor.White, _board), new Position(EColumn.C, ELine.One) },
               new object[] { new Rook(new Position(EColumn.G, ELine.One), EColor.White, _board), new Position(EColumn.G, ELine.One) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Two), EColor.White, _board), new Position(EColumn.C, ELine.One) },
               new object[] { new Rook(new Position(EColumn.F, ELine.Two), EColor.Black, _board), new Position(EColumn.G, ELine.One) },
               new object[] { new Knight(new Position(EColumn.D, ELine.Four), EColor.Black, _board), new Position(EColumn.C, ELine.Five) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Four), EColor.Black, _board), new Position(EColumn.B, ELine.Six) },
               new object[] { new Pawn(new Position(EColumn.C, ELine.Five), EColor.Black, _board), new Position(EColumn.B, ELine.Six) },
               new object[] { new Rook(new Position(EColumn.C, ELine.Five), EColor.Black, _board), new Position(EColumn.A, ELine.Seven) },
               new object[] { new Knight(new Position(EColumn.F, ELine.Four), EColor.White, _board), new Position(EColumn.G, ELine.Five) },
               new object[] { new Knight(new Position(EColumn.G, ELine.Five), EColor.White, _board), new Position(EColumn.H, ELine.Six) }
           };

        public BishopTest()
        {
            _board.ClearBoard();
            _bishop = BishopBuilder.New().WithBoard(_board).Build();
            _board.AddPiece(_bishop);
        }

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMoveBishop(Piece pieceToAddBoard, Position newPosition)
        {
            _board.AddPiece(pieceToAddBoard);
            var moved = _bishop.Move(newPosition);
            Assert.True(moved && _bishop.Position.Equals(newPosition));
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMoveBishop(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _bishop.Position;
            _board.AddPiece(pieceToAddBoard);
            var notMoved = !_bishop.Move(newPosition);
            Assert.True(notMoved && _bishop.Position.Equals(actualPosition));
        }
    }
}
