using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class KingTest
    {
        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.C, ELine.Three) },
                new object[] { new Position(EColumn.D, ELine.Three) },
                new object[] { new Position(EColumn.E, ELine.Three) },
                new object[] { new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.E, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.E, ELine.Five) }
            };

        public static IEnumerable<object[]> ValidMoveWithPiecesOnBoard =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.C, ELine.Three), EColor.Black, new Position(EColumn.C, ELine.Three) },
                new object[] { new Position(EColumn.D, ELine.Three), EColor.Black, new Position(EColumn.D, ELine.Three) },
                new object[] { new Position(EColumn.E, ELine.Three), EColor.Black, new Position(EColumn.E, ELine.Three) },
                new object[] { new Position(EColumn.C, ELine.Four), EColor.Black, new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.E, ELine.Four), EColor.Black, new Position(EColumn.E, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Five), EColor.Black, new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.E, ELine.Five), EColor.Black, new Position(EColumn.E, ELine.Five) },
                new object[] { new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.C, ELine.Three) },
                new object[] { new Position(EColumn.D, ELine.Two), EColor.White, new Position(EColumn.D, ELine.Three) },
                new object[] { new Position(EColumn.F, ELine.Two), EColor.White, new Position(EColumn.E, ELine.Three) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.White, new Position(EColumn.C, ELine.Four) },
                new object[] { new Position(EColumn.F, ELine.Four), EColor.White, new Position(EColumn.E, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Six), EColor.White, new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.F, ELine.Six), EColor.White, new Position(EColumn.E, ELine.Five) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.D, ELine.Four) },
               new object[] { new Position(EColumn.B, ELine.Three) },
               new object[] { new Position(EColumn.B, ELine.Two) },
               new object[] { new Position(EColumn.C, ELine.Two) },
               new object[] { new Position(EColumn.D, ELine.Two) },
               new object[] { new Position(EColumn.E, ELine.Two) },
               new object[] { new Position(EColumn.F, ELine.Two) },
               new object[] { new Position(EColumn.F, ELine.Three) },
               new object[] { new Position(EColumn.F, ELine.Four) },
               new object[] { new Position(EColumn.F, ELine.Five) },
               new object[] { new Position(EColumn.E, ELine.Six) },
               new object[] { new Position(EColumn.D, ELine.Six) },
               new object[] { new Position(EColumn.F, ELine.Six) },
               new object[] { new Position(EColumn.C, ELine.Six) },
               new object[] { new Position(EColumn.B, ELine.Five) },
               new object[] { new Position(EColumn.B, ELine.Four) }
           };

        public static IEnumerable<object[]> InvalidMoveWithPiecesOnBoard =>
           new List<object[]>
           {
               new object[] { new Position(EColumn.C, ELine.Three), EColor.White, new Position(EColumn.C, ELine.Three) },
               new object[] { new Position(EColumn.D, ELine.Three), EColor.White, new Position(EColumn.D, ELine.Three) },
               new object[] { new Position(EColumn.E, ELine.Three), EColor.White, new Position(EColumn.E, ELine.Three) },
               new object[] { new Position(EColumn.C, ELine.Four), EColor.White, new Position(EColumn.C, ELine.Four) },
               new object[] { new Position(EColumn.E, ELine.Four), EColor.White, new Position(EColumn.E, ELine.Four) },
               new object[] { new Position(EColumn.C, ELine.Five), EColor.White, new Position(EColumn.C, ELine.Five) },
               new object[] { new Position(EColumn.D, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Five) },
               new object[] { new Position(EColumn.E, ELine.Five), EColor.White, new Position(EColumn.E, ELine.Five) },
               new object[] { new Position(EColumn.B, ELine.Two), EColor.Black, new Position(EColumn.C, ELine.Three) },
               new object[] { new Position(EColumn.D, ELine.Two), EColor.Black, new Position(EColumn.D, ELine.Three) },
               new object[] { new Position(EColumn.F, ELine.Two), EColor.Black, new Position(EColumn.E, ELine.Three) },
               new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.C, ELine.Four) },
               new object[] { new Position(EColumn.F, ELine.Four), EColor.Black, new Position(EColumn.E, ELine.Four) },
               new object[] { new Position(EColumn.B, ELine.Six), EColor.Black, new Position(EColumn.C, ELine.Five) },
               new object[] { new Position(EColumn.D, ELine.Six), EColor.Black, new Position(EColumn.D, ELine.Five) },
               new object[] { new Position(EColumn.F, ELine.Six), EColor.Black, new Position(EColumn.E, ELine.Five) }
           };

        public static IEnumerable<object[]> ValidCastlingMove =>
            new List<object[]>
            {
                new object[]
                {
                    new Position(EColumn.A, ELine.One),
                    new Position(EColumn.H, ELine.One),
                    EColor.White,
                    new Position(EColumn.C, ELine.One),
                    new Position(EColumn.E, ELine.One),
                    new Position(EColumn.D, ELine.One),
                    new Position(EColumn.H, ELine.One)
                },
                new object[]
                {
                    new Position(EColumn.A, ELine.One),
                    new Position(EColumn.H, ELine.One),
                    EColor.White,
                    new Position(EColumn.G, ELine.One),
                    new Position(EColumn.E, ELine.One),
                    new Position(EColumn.A, ELine.One),
                    new Position(EColumn.F, ELine.One)
                },
                new object[]
                {
                    new Position(EColumn.A, ELine.Eight),
                    new Position(EColumn.H, ELine.Eight),
                    EColor.Black,
                    new Position(EColumn.C, ELine.Eight),
                    new Position(EColumn.E, ELine.Eight),
                    new Position(EColumn.D, ELine.Eight),
                    new Position(EColumn.H, ELine.Eight)
                },
                new object[]
                {
                    new Position(EColumn.A, ELine.Eight),
                    new Position(EColumn.H, ELine.Eight),
                    EColor.Black,
                    new Position(EColumn.G, ELine.Eight),
                    new Position(EColumn.E, ELine.Eight),
                    new Position(EColumn.A, ELine.Eight),
                    new Position(EColumn.F, ELine.Eight)
                }
            };

        public static IEnumerable<object[]> InvalidCastlingMoveWhenKingMoved =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.D, ELine.One), new Position(EColumn.C, ELine.One) },
                new object[] { new Position(EColumn.F, ELine.One), new Position(EColumn.G, ELine.One) },
            };

        public static IEnumerable<object[]> InvalidCastlingMoveWhenRookMoved =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.B, ELine.One), new Position(EColumn.C, ELine.One) }
            };

        public static IEnumerable<object[]> InvalidCastlingMoveWhenHasPieceOnWay =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.C, ELine.One), new Position(EColumn.D, ELine.One), EColor.White },
                new object[] { new Position(EColumn.C, ELine.One), new Position(EColumn.C, ELine.One), EColor.White },
                new object[] { new Position(EColumn.C, ELine.One), new Position(EColumn.B, ELine.One), EColor.White },
                new object[] { new Position(EColumn.G, ELine.One), new Position(EColumn.F, ELine.One), EColor.White },
                new object[] { new Position(EColumn.G, ELine.One), new Position(EColumn.G, ELine.One), EColor.White }
            };

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMove(Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var king = KingBuilder.New().WithBoard(board).Build();
            board.AddPiece(king);
            var moved = king.Move(newPosition);
            Assert.True(moved && king.Position.Equals(newPosition) && king.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(ValidMoveWithPiecesOnBoard))]
        public void ShouldMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = KingBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var king = KingBuilder.New().WithBoard(board).Build();
            var moved = king.Move(newPosition);
            Assert.True(moved && king.Position.Equals(newPosition) && king.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMove(Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var king = KingBuilder.New().WithBoard(board).Build();
            var actualPosition = king.Position;
            board.AddPiece(king);
            var notMoved = !king.Move(newPosition);
            Assert.True(notMoved && king.Position.Equals(actualPosition) && king.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMoveWithPiecesOnBoard))]
        public void ShouldNotMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = KingBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var king = KingBuilder.New().WithBoard(board).Build();
            var actualPosition = king.Position;
            var notMoved = !king.Move(newPosition);
            Assert.True(notMoved && king.Position.Equals(actualPosition) && king.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(ValidCastlingMove))]
        public void ShouldCastling(Position posFirstRook, Position posLastRook, EColor color, Position newPosition, Position initialPosKing, Position expectedPosFirstRook, Position expectedPosLastRook)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var king = KingBuilder.New().WithPosition(initialPosKing).WithColor(color).WithBoard(board).Build();
            board.AddPiece(king);
            var firstRook = RookBuilder.New().WithPosition(posFirstRook).WithColor(color).WithBoard(board).Build();
            board.AddPiece(firstRook);
            var lastRook = RookBuilder.New().WithPosition(posLastRook).WithColor(color).WithBoard(board).Build();
            board.AddPiece(lastRook);
            var moved = king.Move(newPosition);
            Assert.True(moved && king.Position.Equals(newPosition) && firstRook.Position.Equals(expectedPosFirstRook) && lastRook.Position.Equals(expectedPosLastRook));
        }

        [Theory]
        [MemberData(nameof(InvalidCastlingMoveWhenKingMoved))]
        public void ShouldNotCastlingWhenKingMoved(Position posKing, Position newPosKing)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var iniPosKing = new Position(EColumn.E, ELine.One);
            var king = KingBuilder.New().WithPosition(iniPosKing).WithColor(EColor.White).Build();
            board.AddPiece(king);
            var iniPosFirstRook = new Position(EColumn.A, ELine.One);
            var firstRook = RookBuilder.New().WithPosition(iniPosFirstRook).WithColor(EColor.White).Build();
            board.AddPiece(firstRook);
            var iniPosLastRook = new Position(EColumn.H, ELine.One);
            var lastRook = RookBuilder.New().WithPosition(iniPosLastRook).WithColor(EColor.White).Build();
            board.AddPiece(lastRook);
            king.Move((Position)posKing);
            king.Move(iniPosKing);
            var notMoved = !king.Move(newPosKing);
            Assert.True(notMoved && king.Position.Equals(iniPosKing) && firstRook.Position.Equals(iniPosFirstRook) && lastRook.Position.Equals(iniPosLastRook));
        }

        [Theory]
        [MemberData(nameof(InvalidCastlingMoveWhenRookMoved))]
        public void ShouldNotCastlingWhenRookMoved(Position posFirstRook, Position newPosKing)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var iniPosKing = new Position(EColumn.E, ELine.One);
            var king = KingBuilder.New().WithPosition(iniPosKing).WithColor(EColor.White).Build();
            board.AddPiece(king);
            var iniPosFirstRook = new Position(EColumn.A, ELine.One);
            var firstRook = RookBuilder.New().WithPosition(iniPosFirstRook).WithColor(EColor.White).Build();
            board.AddPiece(firstRook);
            var iniPosLastRook = new Position(EColumn.H, ELine.One);
            var lastRook = RookBuilder.New().WithPosition(iniPosLastRook).WithColor(EColor.White).Build();
            board.AddPiece(lastRook);
            firstRook.Move((Position)posFirstRook);
            firstRook.Move(iniPosFirstRook);
            var notMoved = !king.Move(newPosKing);
            Assert.True(notMoved && king.Position.Equals(iniPosKing) && firstRook.Position.Equals(iniPosFirstRook) && lastRook.Position.Equals(iniPosLastRook));
        }

        [Theory]
        [MemberData(nameof(InvalidCastlingMoveWhenHasPieceOnWay))]
        public void ShouldNotCastlingWhenHasPieceOnWay(Position newPosition, Position positionPieceOnWay, EColor colorPieceOnWay)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceOnWay = KingBuilder.New().WithPosition(positionPieceOnWay).WithColor(colorPieceOnWay).Build();
            board.AddPiece(pieceOnWay);
            var iniPosKing = new Position(EColumn.E, ELine.One);
            var king = KingBuilder.New().WithPosition(iniPosKing).WithColor(EColor.White).Build();
            board.AddPiece(king);
            var iniPosFirstRook = new Position(EColumn.A, ELine.One);
            var firstRook = RookBuilder.New().WithPosition(iniPosFirstRook).WithColor(EColor.White).Build();
            board.AddPiece(firstRook);
            var iniPosLastRook = new Position(EColumn.H, ELine.One);
            var lastRook = RookBuilder.New().WithPosition(iniPosLastRook).WithColor(EColor.White).Build();
            var notMoved = !king.Move(newPosition);
            Assert.True(notMoved && king.Position.Equals(iniPosKing) && firstRook.Position.Equals(iniPosFirstRook) && lastRook.Position.Equals(iniPosLastRook));
        }
    }
}
