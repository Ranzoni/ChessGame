using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class QueenTest
    {
        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.C, ELine.Three) },
                new object[] { new Position(EColumn.E, ELine.Three) },
                new object[] { new Position(EColumn.E, ELine.Five) },
                new object[] { new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.A, ELine.Seven) },
                new object[] { new Position(EColumn.B, ELine.Six) },
                new object[] { new Position(EColumn.H, ELine.Eight) },
                new object[] { new Position(EColumn.F, ELine.Six) },
                new object[] { new Position(EColumn.B, ELine.Two) },
                new object[] { new Position(EColumn.G, ELine.One) },
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
                new object[] { new Position(EColumn.C, ELine.Three), EColor.White, new Position(EColumn.C, ELine.Three) },
                new object[] { new Position(EColumn.E, ELine.Three), EColor.White, new Position(EColumn.E, ELine.Three) },
                new object[] { new Position(EColumn.E, ELine.Five), EColor.White, new Position(EColumn.E, ELine.Five) },
                new object[] { new Position(EColumn.C, ELine.Five), EColor.White, new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.A, ELine.Seven), EColor.White, new Position(EColumn.A, ELine.Seven) },
                new object[] { new Position(EColumn.H, ELine.Eight), EColor.White, new Position(EColumn.H, ELine.Eight) },
                new object[] { new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Two) },
                new object[] { new Position(EColumn.G, ELine.One), EColor.White, new Position(EColumn.G, ELine.One) },
                new object[] { new Position(EColumn.A, ELine.Seven), EColor.White, new Position(EColumn.B, ELine.Six) },
                new object[] { new Position(EColumn.H, ELine.Eight), EColor.Black, new Position(EColumn.F, ELine.Six) },
                new object[] { new Position(EColumn.A, ELine.One), EColor.White, new Position(EColumn.B, ELine.Two) },
                new object[] { new Position(EColumn.G, ELine.One), EColor.Black, new Position(EColumn.F, ELine.Two) },
                new object[] { new Position(EColumn.D, ELine.One), EColor.White, new Position(EColumn.D, ELine.One) },
                new object[] { new Position(EColumn.D, ELine.Three), EColor.White, new Position(EColumn.D, ELine.Three) },
                new object[] { new Position(EColumn.D, ELine.Eight), EColor.White, new Position(EColumn.D, ELine.Eight) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.F, ELine.Four), EColor.White, new Position(EColumn.F, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Four), EColor.White, new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.G, ELine.Four), EColor.White, new Position(EColumn.G, ELine.Four) },
                new object[] { new Position(EColumn.D, ELine.One), EColor.White, new Position(EColumn.D, ELine.Two) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Eight), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.White, new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.A, ELine.Four), EColor.Black, new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.F, ELine.Four), EColor.White, new Position(EColumn.E, ELine.Four) },
                new object[] { new Position(EColumn.H, ELine.Four), EColor.Black, new Position(EColumn.F, ELine.Four) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.D, ELine.Four) },
               new object[] { new Position(EColumn.C, ELine.Two) },
               new object[] { new Position(EColumn.C, ELine.One) },
               new object[] { new Position(EColumn.F, ELine.Three) },
               new object[] { new Position(EColumn.G, ELine.Five) },
               new object[] { new Position(EColumn.H, ELine.Five) },
               new object[] { new Position(EColumn.C, ELine.Seven) },
               new object[] { new Position(EColumn.B, ELine.Eight) },
               new object[] { new Position(EColumn.A, ELine.Six) },
               new object[] { new Position(EColumn.A, ELine.Five) },
               new object[] { new Position(EColumn.B, ELine.Five) },
               new object[] { new Position(EColumn.G, ELine.Six) },
               new object[] { new Position(EColumn.E, ELine.Eight) },
               new object[] { new Position(EColumn.A, ELine.Two) },
               new object[] { new Position(EColumn.C, ELine.Six) }
           };

        public static IEnumerable<object[]> InvalidMoveWithPiecesOnBoard =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.C, ELine.Three), EColor.Black, new Position(EColumn.C, ELine.Three) },
               new object[] { new Position(EColumn.E, ELine.Three), EColor.Black, new Position(EColumn.E, ELine.Three) },
               new object[] { new Position(EColumn.F, ELine.Six), EColor.Black, new Position(EColumn.F, ELine.Six) },
               new object[] { new Position(EColumn.C, ELine.Three), EColor.White, new Position(EColumn.B, ELine.Two) },
               new object[] { new Position(EColumn.F, ELine.Six), EColor.Black, new Position(EColumn.G, ELine.Seven) },
               new object[] { new Position(EColumn.C, ELine.Five), EColor.Black, new Position(EColumn.B, ELine.Six) },
               new object[] { new Position(EColumn.C, ELine.Five), EColor.Black, new Position(EColumn.A, ELine.Seven) },
               new object[] { new Position(EColumn.B, ELine.Six), EColor.Black, new Position(EColumn.A, ELine.Seven) },
               new object[] { new Position(EColumn.F, ELine.Six), EColor.White, new Position(EColumn.G, ELine.Seven) },
               new object[] { new Position(EColumn.F, ELine.Six), EColor.White, new Position(EColumn.H, ELine.Eight) },
               new object[] { new Position(EColumn.D, ELine.Five), EColor.Black, new Position(EColumn.D, ELine.Five) },
               new object[] { new Position(EColumn.D, ELine.Three), EColor.Black, new Position(EColumn.D, ELine.Three) },
               new object[] { new Position(EColumn.D, ELine.Eight), EColor.Black, new Position(EColumn.D, ELine.Eight) },
               new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Four) },
               new object[] { new Position(EColumn.F, ELine.Four), EColor.Black, new Position(EColumn.F, ELine.Four) },
               new object[] { new Position(EColumn.C, ELine.Four), EColor.Black, new Position(EColumn.C, ELine.Four) },
               new object[] { new Position(EColumn.D, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Six) },
               new object[] { new Position(EColumn.D, ELine.Three), EColor.Black, new Position(EColumn.D, ELine.One) },
               new object[] { new Position(EColumn.D, ELine.Two), EColor.Black, new Position(EColumn.D, ELine.One) },
               new object[] { new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Eight) },
               new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.A, ELine.Four) },
               new object[] { new Position(EColumn.F, ELine.Four), EColor.White, new Position(EColumn.H, ELine.Four) },
               new object[] { new Position(EColumn.C, ELine.Four), EColor.White, new Position(EColumn.B, ELine.Four) },
               new object[] { new Position(EColumn.C, ELine.Four), EColor.Black, new Position(EColumn.A, ELine.Four) }
           };

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMove(Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var queen = QueenBuilder.New().WithBoard(board).Build();
            board.AddPiece(queen);
            var moved = queen.Move(newPosition);
            Assert.True(moved && queen.Position.Equals(newPosition) && queen.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(ValidMoveWithPiecesOnBoard))]
        public void ShouldMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = QueenBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var queen = QueenBuilder.New().WithBoard(board).Build();
            var moved = queen.Move(newPosition);
            Assert.True(moved && queen.Position.Equals(newPosition) && queen.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMove(Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var queen = QueenBuilder.New().WithBoard(board).Build();
            var actualPosition = queen.Position;
            board.AddPiece(queen);
            var notMoved = !queen.Move(newPosition);
            Assert.True(notMoved && queen.Position.Equals(actualPosition) && queen.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMoveWithPiecesOnBoard))]
        public void ShouldNotMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = RookBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var queen = QueenBuilder.New().WithBoard(board).Build();
            var actualPosition = queen.Position;
            var notMoved = !queen.Move(newPosition);
            Assert.True(notMoved && queen.Position.Equals(actualPosition) && queen.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldReturnAvailableMovements(Position position)
        {
            var queen = QueenBuilder.New().Build();
            Assert.Contains(position, queen.AvailableMovements());
        }
    }
}
