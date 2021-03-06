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
    public class QueenTest
    {
        private static readonly Board _board = BoardBuilder.New().Build();
        private readonly Queen _queen;

        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.C, ELine.Three) },
                new object[] { null, new Position(EColumn.E, ELine.Three) },
                new object[] { null, new Position(EColumn.E, ELine.Five) },
                new object[] { null, new Position(EColumn.C, ELine.Five) },
                new object[] { null, new Position(EColumn.A, ELine.Seven) },
                new object[] { null, new Position(EColumn.B, ELine.Six) },
                new object[] { null, new Position(EColumn.H, ELine.Eight) },
                new object[] { null, new Position(EColumn.F, ELine.Six) },
                new object[] { null, new Position(EColumn.B, ELine.Two) },
                new object[] { null, new Position(EColumn.G, ELine.One) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Three), EColor.White, _board), new Position(EColumn.C, ELine.Three) },
                new object[] { new Bishop(new Position(EColumn.E, ELine.Three), EColor.White, _board), new Position(EColumn.E, ELine.Three) },
                new object[] { new Rook(new Position(EColumn.E, ELine.Five), EColor.White, _board), new Position(EColumn.E, ELine.Five) },
                new object[] { new Queen(new Position(EColumn.C, ELine.Five), EColor.White, _board), new Position(EColumn.C, ELine.Five) },
                new object[] { new Rook(new Position(EColumn.A, ELine.Seven), EColor.White, _board), new Position(EColumn.A, ELine.Seven) },
                new object[] { new Knight(new Position(EColumn.H, ELine.Eight), EColor.White, _board), new Position(EColumn.H, ELine.Eight) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Two), EColor.White, _board), new Position(EColumn.B, ELine.Two) },
                new object[] { new Rook(new Position(EColumn.G, ELine.One), EColor.White, _board), new Position(EColumn.G, ELine.One) },
                new object[] { new Rook(new Position(EColumn.A, ELine.Seven), EColor.White, _board), new Position(EColumn.B, ELine.Six) },
                new object[] { new Bishop(new Position(EColumn.H, ELine.Eight), EColor.Black, _board), new Position(EColumn.F, ELine.Six) },
                new object[] { new Rook(new Position(EColumn.A, ELine.One), EColor.White, _board), new Position(EColumn.B, ELine.Two) },
                new object[] { new Knight(new Position(EColumn.G, ELine.One), EColor.Black, _board), new Position(EColumn.F, ELine.Two) },
                new object[] { null, new Position(EColumn.D, ELine.Eight) },
                new object[] { null, new Position(EColumn.D, ELine.Two) },
                new object[] { null, new Position(EColumn.D, ELine.One) },
                new object[] { null, new Position(EColumn.D, ELine.Six) },
                new object[] { null, new Position(EColumn.B, ELine.Four) },
                new object[] { null, new Position(EColumn.C, ELine.Four) },
                new object[] { null, new Position(EColumn.E, ELine.Four) },
                new object[] { null, new Position(EColumn.H, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.One), EColor.White, _board), new Position(EColumn.D, ELine.One) },
                new object[] { new Bishop(new Position(EColumn.D, ELine.Three), EColor.White, _board), new Position(EColumn.D, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Eight), EColor.White, _board), new Position(EColumn.D, ELine.Eight) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.White, _board), new Position(EColumn.D, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.White, _board), new Position(EColumn.B, ELine.Four) },
                new object[] { new Bishop(new Position(EColumn.F, ELine.Four), EColor.White, _board), new Position(EColumn.F, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.White, _board), new Position(EColumn.C, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.G, ELine.Four), EColor.White, _board), new Position(EColumn.G, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.D, ELine.One), EColor.White, _board), new Position(EColumn.D, ELine.Two) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Eight), EColor.Black, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.White, _board), new Position(EColumn.C, ELine.Four) },
                new object[] { new Bishop(new Position(EColumn.A, ELine.Four), EColor.Black, _board), new Position(EColumn.C, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.F, ELine.Four), EColor.White, _board), new Position(EColumn.E, ELine.Four) },
                new object[] { new Rook(new Position(EColumn.H, ELine.Four), EColor.Black, _board), new Position(EColumn.F, ELine.Four) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { null, new Position(EColumn.D, ELine.Four) },
               new object[] { null, new Position(EColumn.C, ELine.Two) },
               new object[] { null, new Position(EColumn.C, ELine.One) },
               new object[] { null, new Position(EColumn.F, ELine.Three) },
               new object[] { null, new Position(EColumn.G, ELine.Five) },
               new object[] { null, new Position(EColumn.H, ELine.Five) },
               new object[] { null, new Position(EColumn.C, ELine.Seven) },
               new object[] { null, new Position(EColumn.B, ELine.Eight) },
               new object[] { null, new Position(EColumn.A, ELine.Six) },
               new object[] { null, new Position(EColumn.A, ELine.Five) },
               new object[] { null, new Position(EColumn.B, ELine.Five) },
               new object[] { null, new Position(EColumn.G, ELine.Six) },
               new object[] { new Rook(new Position(EColumn.C, ELine.Three), EColor.Black, _board), new Position(EColumn.C, ELine.Three) },
               new object[] { new Knight(new Position(EColumn.E, ELine.Three), EColor.Black, _board), new Position(EColumn.E, ELine.Three) },
               new object[] { new Rook(new Position(EColumn.F, ELine.Six), EColor.Black, _board), new Position(EColumn.F, ELine.Six) },
               new object[] { new Pawn(new Position(EColumn.C, ELine.Three), EColor.White, _board), new Position(EColumn.B, ELine.Two) },
               new object[] { new Rook(new Position(EColumn.F, ELine.Six), EColor.Black, _board), new Position(EColumn.G, ELine.Seven) },
               new object[] { new Knight(new Position(EColumn.C, ELine.Five), EColor.Black, _board), new Position(EColumn.B, ELine.Six) },
               new object[] { new Rook(new Position(EColumn.C, ELine.Five), EColor.Black, _board), new Position(EColumn.A, ELine.Seven) },
               new object[] { new Rook(new Position(EColumn.B, ELine.Six), EColor.Black, _board), new Position(EColumn.A, ELine.Seven) },
               new object[] { new Knight(new Position(EColumn.F, ELine.Six), EColor.White, _board), new Position(EColumn.G, ELine.Seven) },
               new object[] { new Knight(new Position(EColumn.F, ELine.Six), EColor.White, _board), new Position(EColumn.H, ELine.Eight) },
               new object[] { null, new Position(EColumn.E, ELine.Eight) },
               new object[] { null, new Position(EColumn.A, ELine.Two) },
               new object[] { null, new Position(EColumn.C, ELine.Six) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Five), EColor.Black, _board), new Position(EColumn.D, ELine.Five) },
               new object[] { new Rook(new Position(EColumn.D, ELine.Three), EColor.Black, _board), new Position(EColumn.D, ELine.Three) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Eight), EColor.Black, _board), new Position(EColumn.D, ELine.Eight) },
               new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.Black, _board), new Position(EColumn.B, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.F, ELine.Four), EColor.Black, _board), new Position(EColumn.F, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.Black, _board), new Position(EColumn.C, ELine.Four) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Five), EColor.White, _board), new Position(EColumn.D, ELine.Six) },
               new object[] { new Rook(new Position(EColumn.D, ELine.Three), EColor.Black, _board), new Position(EColumn.D, ELine.One) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Two), EColor.Black, _board), new Position(EColumn.D, ELine.One) },
               new object[] { new Pawn(new Position(EColumn.D, ELine.Seven), EColor.Black, _board), new Position(EColumn.D, ELine.Eight) },
               new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.Black, _board), new Position(EColumn.A, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.F, ELine.Four), EColor.White, _board), new Position(EColumn.H, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.White, _board), new Position(EColumn.B, ELine.Four) },
               new object[] { new Rook(new Position(EColumn.C, ELine.Four), EColor.Black, _board), new Position(EColumn.A, ELine.Four) }
           };

        public QueenTest()
        {
            _board.ClearBoard();
            _queen = QueenBuilder.New().WithBoard(_board).Build();
            _board.AddPiece(_queen);
        }

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMoveQueen(Piece pieceToAddBoard, Position newPosition)
        {
            _board.AddPiece(pieceToAddBoard);
            var moved = _queen.Move(newPosition);
            Assert.True(moved && _queen.Position.Equals(newPosition));
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMoveQueen(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _queen.Position;
            _board.AddPiece(pieceToAddBoard);
            var notMoved = !_queen.Move(newPosition);
            Assert.True(notMoved && _queen.Position.Equals(actualPosition));
        }
    }
}
