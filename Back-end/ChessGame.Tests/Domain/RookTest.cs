using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using ChessGame.Tests.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class RookTest
    {
        private static readonly Board _board = BoardBuilder.New().Build();
        private readonly Rook _rook;

        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.D, ELine.Eight) },
                new object[] { null, new Position(EColumn.D, ELine.Two) },
                new object[] { null, new Position(EColumn.D, ELine.One) },
                new object[] { null, new Position(EColumn.D, ELine.Six) },
                new object[] { null, new Position(EColumn.B, ELine.Four) },
                new object[] { null, new Position(EColumn.C, ELine.Four) },
                new object[] { null, new Position(EColumn.E, ELine.Four) },
                new object[] { null, new Position(EColumn.H, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.One), EColor.Black, _board), new Position(EColumn.D, ELine.One) },
                new object[] { new Rook(new Position(EColumn.D, ELine.Three), EColor.Black, _board), new Position(EColumn.D, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Eight), EColor.Black, _board), new Position(EColumn.D, ELine.Eight) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.Black, _board), new Position(EColumn.D, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.Black, _board), new Position(EColumn.B, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.F, ELine.Four), EColor.Black, _board), new Position(EColumn.F, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.Black, _board), new Position(EColumn.C, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.G, ELine.Four), EColor.Black, _board), new Position(EColumn.G, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.D, ELine.One), EColor.Black, _board), new Position(EColumn.D, ELine.Two) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.Black, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Eight), EColor.Black, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.Black, _board), new Position(EColumn.C, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Four), EColor.Black, _board), new Position(EColumn.C, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.F, ELine.Four), EColor.Black, _board), new Position(EColumn.E, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.H, ELine.Four), EColor.Black, _board), new Position(EColumn.F, ELine.Four) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { null, new Position(EColumn.D, ELine.Four) },
               new object[] { null, new Position(EColumn.E, ELine.Eight) },
               new object[] { null, new Position(EColumn.A, ELine.One) },
               new object[] { null, new Position(EColumn.C, ELine.Five) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Five), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
               new object[] { new Rook(new Position(EColumn.D, ELine.Three), EColor.White, _board), new Position(EColumn.D, ELine.Three) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Eight), EColor.White, _board), new Position(EColumn.D, ELine.Eight) },
               new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.White, _board), new Position(EColumn.B, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.F, ELine.Four), EColor.White, _board), new Position(EColumn.F, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.White, _board), new Position(EColumn.C, ELine.Four) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Five), EColor.Black, _board), new Position(EColumn.D, ELine.Six) },
               new object[] { new Rook(new Position(EColumn.D, ELine.Three), EColor.White, _board), new Position(EColumn.D, ELine.One) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Two), EColor.White, _board), new Position(EColumn.D, ELine.One) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Seven), EColor.White, _board), new Position(EColumn.D, ELine.Eight) },
               new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.White, _board), new Position(EColumn.A, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.F, ELine.Four), EColor.Black, _board), new Position(EColumn.H, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.Black, _board), new Position(EColumn.B, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.White, _board), new Position(EColumn.A, ELine.Four) }
           };

        public RookTest()
        {
            _board.ClearBoard();
            _rook = RookBuilder.New().WithPosition(new Position(EColumn.D, ELine.Four)).WithColor(EColor.White).WithBoard(_board).Build();
            _board.AddPiece(_rook);
        }

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMoveRook(Piece pieceToAddBoard, Position newPosition)
        {
            _board.AddPiece(pieceToAddBoard);
            var moved = _rook.Move(newPosition);
            Assert.True(moved && _rook.Position.Equals(newPosition));
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMoveRook(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _rook.Position;
            _board.AddPiece(pieceToAddBoard);
            var notMoved = !_rook.Move(newPosition);
            Assert.True(notMoved && _rook.Position.Equals(actualPosition));
        }
    }
}
