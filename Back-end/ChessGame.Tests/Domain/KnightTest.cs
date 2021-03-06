using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class KnightTest
    {
        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.A, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.One) },
                new object[] { new Position(EColumn.B, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.One) },
                new object[] { new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.E, ELine.Two) },
                new object[] { new Position(EColumn.E, ELine.Four) }
            };

        public static IEnumerable<object[]> ValidMoveWithPiecesOnBoard =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.A, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.Black, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.C, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.A, ELine.Three), EColor.Black, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.A, ELine.Four), EColor.White, new Position(EColumn.A, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.White, new Position(EColumn.A, ELine.Four) },
                new object[] { new Position(EColumn.A, ELine.Three), EColor.Black, new Position(EColumn.A, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Four), EColor.Black, new Position(EColumn.A, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.A, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.One), EColor.White, new Position(EColumn.B, ELine.One) },
                new object[] { new Position(EColumn.C, ELine.One), EColor.Black, new Position(EColumn.B, ELine.One) },
                new object[] { new Position(EColumn.C, ELine.Two), EColor.Black, new Position(EColumn.B, ELine.One) },
                new object[] { new Position(EColumn.B, ELine.Two), EColor.Black, new Position(EColumn.B, ELine.One) },
                new object[] { new Position(EColumn.B, ELine.Five), EColor.White, new Position(EColumn.B, ELine.Five) },
                new object[] { new Position(EColumn.C, ELine.Five), EColor.Black, new Position(EColumn.B, ELine.Five) },
                new object[] { new Position(EColumn.C, ELine.Four), EColor.White, new Position(EColumn.B, ELine.Five) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.One), EColor.White, new Position(EColumn.D, ELine.One) },
                new object[] { new Position(EColumn.C, ELine.Two), EColor.White, new Position(EColumn.D, ELine.One) },
                new object[] { new Position(EColumn.C, ELine.One), EColor.White, new Position(EColumn.D, ELine.One) },
                new object[] { new Position(EColumn.D, ELine.Two), EColor.Black, new Position(EColumn.D, ELine.One) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.C, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.C, ELine.Four), EColor.White, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Three), EColor.White, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Four), EColor.White, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.E, ELine.Two), EColor.White, new Position(EColumn.E, ELine.Two) },
                new object[] { new Position(EColumn.E, ELine.Four), EColor.White, new Position(EColumn.E, ELine.Four) },
                new object[] { new Position(EColumn.A, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.A, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.A, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.A, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.A, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.A, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) },
                new object[] { new Position(EColumn.A, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Two) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.C, ELine.Three) },
               new object[] { new Position(EColumn.A, ELine.One) },
               new object[] { new Position(EColumn.A, ELine.Three) },
               new object[] { new Position(EColumn.B, ELine.Two) },
               new object[] { new Position(EColumn.B, ELine.Four) },
               new object[] { new Position(EColumn.B, ELine.Three) },
               new object[] { new Position(EColumn.D, ELine.Two) },
               new object[] { new Position(EColumn.D, ELine.Three) },
               new object[] { new Position(EColumn.D, ELine.Four) },
               new object[] { new Position(EColumn.E, ELine.One) },
               new object[] { new Position(EColumn.E, ELine.Three) },
               new object[] { new Position(EColumn.E, ELine.Five) },
               new object[] { new Position(EColumn.E, ELine.Six) },
               new object[] { new Position(EColumn.H, ELine.Eight) },
               new object[] { new Position(EColumn.G, ELine.Seven) }
           };

        public static IEnumerable<object[]> InvalidMoveWithPiecesOnBoard =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.A, ELine.Two), EColor.Black, new Position(EColumn.A, ELine.Two) },
               new object[] { new Position(EColumn.A, ELine.Four), EColor.Black, new Position(EColumn.A, ELine.Four) },
               new object[] { new Position(EColumn.B, ELine.One), EColor.Black, new Position(EColumn.B, ELine.One) },
               new object[] { new Position(EColumn.B, ELine.Five), EColor.Black, new Position(EColumn.B, ELine.Five) },
               new object[] { new Position(EColumn.D, ELine.One), EColor.Black, new Position(EColumn.D, ELine.One) },
               new object[] { new Position(EColumn.D, ELine.Five), EColor.Black, new Position(EColumn.D, ELine.Five) },
               new object[] { new Position(EColumn.E, ELine.Two), EColor.Black, new Position(EColumn.E, ELine.Two) },
               new object[] { new Position(EColumn.E, ELine.Four), EColor.Black, new Position(EColumn.E, ELine.Four) }
           };

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMove(Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var knight = KnightBuilder.New().WithColor(EColor.Black).WithBoard(board).Build();
            board.AddPiece(knight);
            var moved = knight.Move(newPosition);
            Assert.True(moved && knight.Position.Equals(newPosition) && knight.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(ValidMoveWithPiecesOnBoard))]
        public void ShouldMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = KnightBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var knight = KnightBuilder.New().WithColor(EColor.Black).WithBoard(board).Build();
            var moved = knight.Move(newPosition);
            Assert.True(moved && knight.Position.Equals(newPosition) && knight.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMove(Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var knight = KnightBuilder.New().WithColor(EColor.Black).WithBoard(board).Build();
            var actualPosition = knight.Position;
            board.AddPiece(knight);
            var notMoved = !knight.Move(newPosition);
            Assert.True(notMoved && knight.Position.Equals(actualPosition) && knight.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMoveWithPiecesOnBoard))]
        public void ShouldNotMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = KnightBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var knight = KnightBuilder.New().WithColor(EColor.Black).WithBoard(board).Build();
            var actualPosition = knight.Position;
            var notMoved = !knight.Move(newPosition);
            Assert.True(notMoved && knight.Position.Equals(actualPosition) && knight.QuantityMove == 0);
        }
    }
}
