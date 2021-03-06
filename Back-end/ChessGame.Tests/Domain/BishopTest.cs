using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class BishopTest
    {
        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.D, ELine.Two) },
                new object[] { new Position(EColumn.C, ELine.One) },
                new object[] { new Position(EColumn.F, ELine.Two) },
                new object[] { new Position(EColumn.G, ELine.One) },
                new object[] { new Position(EColumn.D, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.B, ELine.Six) },
                new object[] { new Position(EColumn.A, ELine.Seven) },
                new object[] { new Position(EColumn.F, ELine.Four) },
                new object[] { new Position(EColumn.G, ELine.Five) },
                new object[] { new Position(EColumn.H, ELine.Six) }
            };

        public static IEnumerable<object[]> ValidMoveWithPiecesOnBoard =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.D, ELine.Two), EColor.Black, new Position(EColumn.D, ELine.Two) },
                new object[] { new Position(EColumn.C, ELine.One), EColor.Black, new Position(EColumn.C, ELine.One) },
                new object[] { new Position(EColumn.F, ELine.Two), EColor.Black, new Position(EColumn.F, ELine.Two) },
                new object[] { new Position(EColumn.G, ELine.One), EColor.Black, new Position(EColumn.G, ELine.One) },
                new object[] { new Position(EColumn.D, ELine.Four), EColor.Black, new Position(EColumn.D, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Five), EColor.Black, new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.B, ELine.Six), EColor.Black, new Position(EColumn.B, ELine.Six) },
                new object[] { new Position(EColumn.A, ELine.Seven), EColor.Black, new Position(EColumn.A, ELine.Seven) },
                new object[] { new Position(EColumn.F, ELine.Four), EColor.Black, new Position(EColumn.F, ELine.Four) },
                new object[] { new Position(EColumn.G, ELine.Five), EColor.Black, new Position(EColumn.G, ELine.Five) },
                new object[] { new Position(EColumn.H, ELine.Six), EColor.Black, new Position(EColumn.H, ELine.Six) },
                new object[] { new Position(EColumn.C, ELine.One), EColor.White, new Position(EColumn.D, ELine.Two) },
                new object[] { new Position(EColumn.G, ELine.One), EColor.Black, new Position(EColumn.F, ELine.Two) },
                new object[] { new Position(EColumn.C, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Six), EColor.Black, new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.A, ELine.Seven), EColor.Black, new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.A, ELine.Seven), EColor.Black, new Position(EColumn.B, ELine.Six) },
                new object[] { new Position(EColumn.G, ELine.Five), EColor.White, new Position(EColumn.F, ELine.Four) },
                new object[] { new Position(EColumn.H, ELine.Six), EColor.Black, new Position(EColumn.G, ELine.Five) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.E, ELine.Three) },
               new object[] { new Position(EColumn.D, ELine.One) },
               new object[] { new Position(EColumn.D, ELine.Three) },
               new object[] { new Position(EColumn.H, ELine.Three) },
               new object[] { new Position(EColumn.B, ELine.One) },
               new object[] { new Position(EColumn.F, ELine.Three) },
               new object[] { new Position(EColumn.G, ELine.Four) },
               new object[] { new Position(EColumn.H, ELine.Four) },
               new object[] { new Position(EColumn.C, ELine.Seven) },
               new object[] { new Position(EColumn.B, ELine.Eight) },
               new object[] { new Position(EColumn.A, ELine.Six) },
               new object[] { new Position(EColumn.A, ELine.Four) },
               new object[] { new Position(EColumn.B, ELine.Five) },
               new object[] { new Position(EColumn.G, ELine.Six) }
           };

        public static IEnumerable<object[]> InvalidMoveWithPiecesOnBoard =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.D, ELine.Two), EColor.White, new Position(EColumn.D, ELine.Two) },
               new object[] { new Position(EColumn.C, ELine.One), EColor.White, new Position(EColumn.C, ELine.One) },
               new object[] { new Position(EColumn.G, ELine.One), EColor.White, new Position(EColumn.G, ELine.One) },
               new object[] { new Position(EColumn.D, ELine.Two), EColor.White, new Position(EColumn.C, ELine.One) },
               new object[] { new Position(EColumn.F, ELine.Two), EColor.Black, new Position(EColumn.G, ELine.One) },
               new object[] { new Position(EColumn.D, ELine.Four), EColor.Black, new Position(EColumn.C, ELine.Five) },
               new object[] { new Position(EColumn.D, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Six) },
               new object[] { new Position(EColumn.C, ELine.Five), EColor.Black, new Position(EColumn.B, ELine.Six) },
               new object[] { new Position(EColumn.C, ELine.Five), EColor.Black, new Position(EColumn.A, ELine.Seven) },
               new object[] { new Position(EColumn.F, ELine.Four), EColor.White, new Position(EColumn.G, ELine.Five) },
               new object[] { new Position(EColumn.G, ELine.Five), EColor.White, new Position(EColumn.H, ELine.Six) }
           };

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMove(Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var bishop = BishopBuilder.New().WithBoard(board).Build();
            board.AddPiece(bishop);
            var moved = bishop.Move(newPosition);
            Assert.True(moved && bishop.Position.Equals(newPosition) && bishop.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(ValidMoveWithPiecesOnBoard))]
        public void ShouldMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = BishopBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var bishop = BishopBuilder.New().WithBoard(board).Build();
            var moved = bishop.Move(newPosition);
            Assert.True(moved && bishop.Position.Equals(newPosition) && bishop.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMove(Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var bishop = BishopBuilder.New().WithBoard(board).Build();
            var actualPosition = bishop.Position;
            board.AddPiece(bishop);
            var notMoved = !bishop.Move(newPosition);
            Assert.True(notMoved && bishop.Position.Equals(actualPosition) && bishop.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMoveWithPiecesOnBoard))]
        public void ShouldNotMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = BishopBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var bishop = BishopBuilder.New().WithBoard(board).Build();
            var actualPosition = bishop.Position;
            var notMoved = !bishop.Move(newPosition);
            Assert.True(notMoved && bishop.Position.Equals(actualPosition) && bishop.QuantityMove == 0);
        }
    }
}
