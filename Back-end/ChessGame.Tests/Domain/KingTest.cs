using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using ChessGame.Tests.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class KingTest
    {
        private static readonly Board _board = BoardBuilder.New().Build();
        private readonly King _king;

        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.C, ELine.Three) },
                new object[] { null, new Position(EColumn.D, ELine.Three) },
                new object[] { null, new Position(EColumn.E, ELine.Three) },
                new object[] { null, new Position(EColumn.C, ELine.Four) },
                new object[] { null, new Position(EColumn.E, ELine.Four) },
                new object[] { null, new Position(EColumn.C, ELine.Five) },
                new object[] { null, new Position(EColumn.D, ELine.Five) },
                new object[] { null, new Position(EColumn.E, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Three), EColor.Black, _board), new Position(EColumn.C, ELine.Three) },
                new object[] { new Bishop(new Position(EColumn.D, ELine.Three), EColor.Black, _board), new Position(EColumn.D, ELine.Three) },
                new object[] { new Queen(new Position(EColumn.E, ELine.Three), EColor.Black, _board), new Position(EColumn.E, ELine.Three) },
                new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.Black, _board), new Position(EColumn.C, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.E, ELine.Four), EColor.Black, _board), new Position(EColumn.E, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Five), EColor.Black, _board), new Position(EColumn.C, ELine.Five) },
                new object[] { new Knight(new Position(EColumn.D, ELine.Five), EColor.Black, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Knight(new Position(EColumn.E, ELine.Five), EColor.Black, _board), new Position(EColumn.E, ELine.Five) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { null, new Position(EColumn.D, ELine.Four) },
               new object[] { null, new Position(EColumn.B, ELine.Three) },
               new object[] { null, new Position(EColumn.B, ELine.Two) },
               new object[] { null, new Position(EColumn.C, ELine.Two) },
               new object[] { null, new Position(EColumn.D, ELine.Two) },
               new object[] { null, new Position(EColumn.E, ELine.Two) },
               new object[] { null, new Position(EColumn.F, ELine.Two) },
               new object[] { null, new Position(EColumn.F, ELine.Three) },
               new object[] { null, new Position(EColumn.F, ELine.Four) },
               new object[] { null, new Position(EColumn.F, ELine.Five) },
               new object[] { null, new Position(EColumn.E, ELine.Six) },
               new object[] { null, new Position(EColumn.D, ELine.Six) },
               new object[] { null, new Position(EColumn.F, ELine.Six) },
               new object[] { null, new Position(EColumn.C, ELine.Six) },
               new object[] { null, new Position(EColumn.B, ELine.Five) },
               new object[] { null, new Position(EColumn.B, ELine.Four) },
               new object[] { new Pawn(new Position(EColumn.C, ELine.Three), EColor.White, _board), new Position(EColumn.C, ELine.Three) },
               new object[] { new Queen(new Position(EColumn.D, ELine.Three), EColor.White, _board), new Position(EColumn.D, ELine.Three) },
               new object[] { new Knight(new Position(EColumn.E, ELine.Three), EColor.White, _board), new Position(EColumn.E, ELine.Three) },
               new object[] { new Pawn(new Position(EColumn.C, ELine.Four), EColor.White, _board), new Position(EColumn.C, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.E, ELine.Four), EColor.White, _board), new Position(EColumn.E, ELine.Four) },
               new object[] { new Knight(new Position(EColumn.C, ELine.Five), EColor.White, _board), new Position(EColumn.C, ELine.Five) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Five), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
               new object[] { new Bishop(new Position(EColumn.E, ELine.Five), EColor.White, _board), new Position(EColumn.E, ELine.Five) }
           };

        public KingTest()
        {
            _board.ClearBoard();
            _king = KingBuilder.New().WithBoard(_board).Build();
            _board.AddPiece(_king);
        }

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMoveKing(Piece pieceToAddBoard, Position newPosition)
        {
            _board.AddPiece(pieceToAddBoard);
            var moved = _king.Move(newPosition);
            Assert.True(moved && _king.Position.Equals(newPosition));
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMoveKing(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _king.Position;
            _board.AddPiece(pieceToAddBoard);
            var notMoved = !_king.Move(newPosition);
            Assert.True(notMoved && _king.Position.Equals(actualPosition));
        }
    }
}
