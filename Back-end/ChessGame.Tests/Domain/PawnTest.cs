using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class PawnTest
    {
        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.Three), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.Four), EColor.White },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Six), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Five), EColor.Black }
            };

        public static IEnumerable<object[]> ValidMoveWithPiecesOnBoard =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.B, ELine.Four), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Three) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Three) },
                new object[] { new Position(EColumn.B, ELine.Five), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Five), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.C, ELine.Three) },
                new object[] { new Position(EColumn.A, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Three) },
                new object[] { new Position(EColumn.E, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.E, ELine.Six) },
                new object[] { new Position(EColumn.C, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.C, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Four), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Four), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.C, ELine.One), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.A, ELine.One), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.One), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.D, ELine.Three), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.Two), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.E, ELine.Five), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.F, ELine.Eight), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.Five), EColor.White },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.E, ELine.Eight), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.C, ELine.Eight), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Eight), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.F, ELine.Six), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Seven), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.E, ELine.Five), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.A, ELine.Four), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Four), EColor.Black }
           };

        public static IEnumerable<object[]> InvalidMoveWithPiecesOnBoard =>
           new List<object[]>
           {
                new object[] { new Position(EColumn.A, ELine.Three), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Three) },
                new object[] { new Position(EColumn.D, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.D, ELine.Three) },
                new object[] { new Position(EColumn.A, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Three) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Three) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Six), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.C, ELine.Six) },
                new object[] { new Position(EColumn.F, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.F, ELine.Six) },
                new object[] { new Position(EColumn.C, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
           };

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMove(Position actualPosition, Position newPosition, EColor color)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pawn = PawnBuilder.New().WithColor(color).WithPosition(actualPosition).WithBoard(board).Build();
            board.AddPiece(pawn);
            var moved = pawn.Move(newPosition);
            Assert.True(moved && pawn.Position.Equals(newPosition) && pawn.QuantityMove == 1);
        }

        [Theory]
        [MemberData(nameof(ValidMoveWithPiecesOnBoard))]
        public void ShouldMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position actualPosition, EColor color, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = PawnBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var pawn = PawnBuilder.New().WithColor(color).WithPosition(actualPosition).WithBoard(board).Build();
            var moved = pawn.Move(newPosition);
            Assert.True(moved && pawn.Position.Equals(newPosition) && pawn.QuantityMove == 1);
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMove(Position actualPosition, Position newPosition, EColor color)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pawn = PawnBuilder.New().WithColor(color).WithPosition(actualPosition).WithBoard(board).Build();
            board.AddPiece(pawn);
            var notMoved = !pawn.Move(newPosition);
            Assert.True(notMoved && pawn.Position.Equals(actualPosition) && pawn.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMoveWithPiecesOnBoard))]
        public void ShouldNotMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position actualPosition, EColor color, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = PawnBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var pawn = PawnBuilder.New().WithColor(color).WithPosition(actualPosition).WithBoard(board).Build();
            var notMoved = !pawn.Move(newPosition);
            Assert.True(notMoved && pawn.Position.Equals(actualPosition) && pawn.QuantityMove == 0);
        }

        [Fact]
        public void ShouldRegisterQuantityMove()
        {
            var pawn = PawnBuilder.New().Build();
            pawn.Move(new Position(EColumn.B, ELine.Three));
            pawn.Move(new Position(EColumn.B, ELine.Four));
            Assert.True(pawn.QuantityMove == 2);
        }
    }
}
