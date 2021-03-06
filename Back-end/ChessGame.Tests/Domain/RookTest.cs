using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class RookTest
    {
        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.D, ELine.Eight) },
                new object[] { new Position(EColumn.D, ELine.Two) },
                new object[] { new Position(EColumn.D, ELine.One) },
                new object[] { new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.E, ELine.Four) },
                new object[] { new Position(EColumn.H, ELine.Four) }
            };

        public static IEnumerable<object[]> ValidMoveWithPiecesOnBoard =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.D, ELine.One), EColor.Black, new Position(EColumn.D, ELine.One) },
                new object[] { new Position(EColumn.D, ELine.Three), EColor.Black, new Position(EColumn.D, ELine.Three) },
                new object[] { new Position(EColumn.D, ELine.Eight), EColor.Black, new Position(EColumn.D, ELine.Eight) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.Black, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.F, ELine.Four), EColor.Black, new Position(EColumn.F, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Four), EColor.Black, new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.G, ELine.Four), EColor.Black, new Position(EColumn.G, ELine.Four) },
                new object[] { new Position(EColumn.D, ELine.One), EColor.Black, new Position(EColumn.D, ELine.Two) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Eight), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.A, ELine.Four), EColor.Black, new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.F, ELine.Four), EColor.Black, new Position(EColumn.E, ELine.Four) },
                new object[] { new Position(EColumn.H, ELine.Four), EColor.Black, new Position(EColumn.F, ELine.Four) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.D, ELine.Four) },
               new object[] { new Position(EColumn.E, ELine.Eight) },
               new object[] { new Position(EColumn.A, ELine.One) },
               new object[] { new Position(EColumn.C, ELine.Five) }
           };

        public static IEnumerable<object[]> InvalidMoveWithPiecesOnBoard =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.D, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Five) },
               new object[] { new Position(EColumn.D, ELine.Three), EColor.White, new Position(EColumn.D, ELine.Three) },
               new object[] { new Position(EColumn.D, ELine.Eight), EColor.White, new Position(EColumn.D, ELine.Eight) },
               new object[] { new Position(EColumn.B, ELine.Four), EColor.White, new Position(EColumn.B, ELine.Four) },
               new object[] { new Position(EColumn.F, ELine.Four), EColor.White, new Position(EColumn.F, ELine.Four) },
               new object[] { new Position(EColumn.C, ELine.Four), EColor.White, new Position(EColumn.C, ELine.Four) },
               new object[] { new Position(EColumn.D, ELine.Five), EColor.Black, new Position(EColumn.D, ELine.Six) },
               new object[] { new Position(EColumn.D, ELine.Three), EColor.White, new Position(EColumn.D, ELine.One) },
               new object[] { new Position(EColumn.D, ELine.Two), EColor.White, new Position(EColumn.D, ELine.One) },
               new object[] { new Position(EColumn.D, ELine.Seven), EColor.White, new Position(EColumn.D, ELine.Eight) },
               new object[] { new Position(EColumn.B, ELine.Four), EColor.White, new Position(EColumn.A, ELine.Four) },
               new object[] { new Position(EColumn.F, ELine.Four), EColor.Black, new Position(EColumn.H, ELine.Four) },
               new object[] { new Position(EColumn.C, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Four) },
               new object[] { new Position(EColumn.C, ELine.Four), EColor.White, new Position(EColumn.A, ELine.Four) }
           };

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMove(Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var rook = RookBuilder.New().WithColor(EColor.White).WithPosition(new Position(EColumn.D, ELine.Four)).WithBoard(board).Build();
            board.AddPiece(rook);
            var moved = rook.Move(newPosition);
            Assert.True(moved && rook.Position.Equals(newPosition) && rook.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(ValidMoveWithPiecesOnBoard))]
        public void ShouldMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = PawnBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var rook = RookBuilder.New().WithColor(EColor.White).WithPosition(new Position(EColumn.D, ELine.Four)).WithBoard(board).Build();
            var moved = rook.Move(newPosition);
            Assert.True(moved && rook.Position.Equals(newPosition) && rook.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMove(Position newPosition)
        {
            var actualPosition = new Position(EColumn.D, ELine.Four);
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var rook = RookBuilder.New().WithColor(EColor.White).WithPosition(actualPosition).WithBoard(board).Build();
            board.AddPiece(rook);
            var notMoved = !rook.Move(newPosition);
            Assert.True(notMoved && rook.Position.Equals(actualPosition) && rook.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMoveWithPiecesOnBoard))]
        public void ShouldNotMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var actualPosition = new Position(EColumn.D, ELine.Four);
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = RookBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var rook = RookBuilder.New().WithColor(EColor.White).WithPosition(actualPosition).WithBoard(board).Build();
            var notMoved = !rook.Move(newPosition);
            Assert.True(notMoved && rook.Position.Equals(actualPosition) && rook.QuantityMove == 0);
        }
    }
}
