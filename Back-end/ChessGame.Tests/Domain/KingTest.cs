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

        public static IEnumerable<object[]> ValidCastlingMove =>
            new List<object[]>
            {
                new object[]
                {
                    new Rook(new Position(EColumn.A, ELine.One), EColor.White, _board),
                    new Rook(new Position(EColumn.H, ELine.One), EColor.White, _board),
                    new Position(EColumn.C, ELine.One),
                    new Position(EColumn.E, ELine.One),
                    EColor.White,
                    new Position(EColumn.D, ELine.One),
                    new Position(EColumn.H, ELine.One)
                },
                new object[]
                {
                    new Rook(new Position(EColumn.A, ELine.One), EColor.White, _board),
                    new Rook(new Position(EColumn.H, ELine.One), EColor.White, _board),
                    new Position(EColumn.G, ELine.One),
                    new Position(EColumn.E, ELine.One),
                    EColor.White,
                    new Position(EColumn.A, ELine.One),
                    new Position(EColumn.F, ELine.One)
                },
                new object[]
                {
                    new Rook(new Position(EColumn.A, ELine.Eight), EColor.Black, _board),
                    new Rook(new Position(EColumn.H, ELine.Eight), EColor.Black, _board),
                    new Position(EColumn.C, ELine.Eight),
                    new Position(EColumn.E, ELine.Eight),
                    EColor.Black,
                    new Position(EColumn.D, ELine.Eight),
                    new Position(EColumn.H, ELine.Eight)
                },
                new object[]
                {
                    new Rook(new Position(EColumn.A, ELine.Eight), EColor.Black, _board),
                    new Rook(new Position(EColumn.H, ELine.Eight), EColor.Black, _board),
                    new Position(EColumn.G, ELine.Eight),
                    new Position(EColumn.E, ELine.Eight),
                    EColor.Black,
                    new Position(EColumn.A, ELine.Eight),
                    new Position(EColumn.F, ELine.Eight)
                }
            };

        public static IEnumerable<object[]> InvalidCastlingMoveWhenKingOrRookMoved =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.D, ELine.One), null, null, new Position(EColumn.C, ELine.One) },
                new object[] { new Position(EColumn.F, ELine.One), null, null, new Position(EColumn.G, ELine.One) },
                new object[] { null, new Position(EColumn.B, ELine.One), null, new Position(EColumn.C, ELine.One) },
                new object[] { null, null, new Position(EColumn.G, ELine.One), new Position(EColumn.G, ELine.One) }
            };

        public static IEnumerable<object[]> InvalidCastlingMoveWhenHasPieceOnWay =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.C, ELine.One), new Queen(new Position(EColumn.D, ELine.One), EColor.White, _board) },
                new object[] { new Position(EColumn.C, ELine.One), new Bishop(new Position(EColumn.C, ELine.One), EColor.White, _board) },
                new object[] { new Position(EColumn.C, ELine.One), new Knight(new Position(EColumn.B, ELine.One), EColor.White, _board) },
                new object[] { new Position(EColumn.G, ELine.One), new Bishop(new Position(EColumn.F, ELine.One), EColor.White, _board) },
                new object[] { new Position(EColumn.G, ELine.One), new Knight(new Position(EColumn.G, ELine.One), EColor.White, _board) }
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
            Assert.True(moved && _king.Position.Equals(newPosition) && _king.QuantityMove > 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMoveKing(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _king.Position;
            _board.AddPiece(pieceToAddBoard);
            var notMoved = !_king.Move(newPosition);
            Assert.True(notMoved && _king.Position.Equals(actualPosition) && _king.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(ValidCastlingMove))]
        public void ShouldCastling(Rook firstRook, Rook lastRook, Position newPosition, Position initialPosKing, EColor colorKing, Position expectedPosFirstRook, Position expectedPosLastRook)
        {
            _board.ClearBoard();
            var king = new King(initialPosKing, colorKing, _board);
            _board.AddPiece(king);
            _board.AddPiece(firstRook);
            _board.AddPiece(lastRook);
            var moved = king.Move(newPosition);
            Assert.True(moved && king.Position.Equals(newPosition) && firstRook.Position.Equals(expectedPosFirstRook) && lastRook.Position.Equals(expectedPosLastRook));
        }

        [Theory]
        [MemberData(nameof(InvalidCastlingMoveWhenKingOrRookMoved))]
        public void ShouldNotCastlingWhenKingOrRookMoved(Position? posKing, Position? posFirstRook, Position? posLastRook, Position newPosKing)
        {
            _board.ClearBoard();
            var iniPosKing = new Position(EColumn.E, ELine.One);
            var king = new King(iniPosKing, EColor.White, _board);
            _board.AddPiece(king);
            var iniPosFirstRook = new Position(EColumn.A, ELine.One);
            var firstRook = new Rook(iniPosFirstRook, EColor.White, _board);
            _board.AddPiece(firstRook);
            var iniPosLastRook = new Position(EColumn.H, ELine.One);
            var lastRook = new Rook(iniPosLastRook, EColor.White, _board);
            _board.AddPiece(lastRook);
            if (posKing != null)
            {
                king.Move((Position)posKing);
                king.Move(iniPosKing);
            }
            if (posFirstRook != null)
            {
                firstRook.Move((Position)posFirstRook);
                firstRook.Move(iniPosFirstRook);
            }
            if (posLastRook != null)
            {
                lastRook.Move((Position)posLastRook);
                lastRook.Move(iniPosLastRook);
            }
            var notMoved = !king.Move(newPosKing);
            Assert.True(notMoved && king.Position.Equals(iniPosKing) && firstRook.Position.Equals(iniPosFirstRook) && lastRook.Position.Equals(iniPosLastRook));
        }

        [Theory]
        [MemberData(nameof(InvalidCastlingMoveWhenHasPieceOnWay))]
        public void ShouldNotCastlingWhenHasPieceOnWay(Position newPosition, Piece pieceOnWay)
        {
            _board.ClearBoard();
            _board.AddPiece(pieceOnWay);
            var iniPosKing = new Position(EColumn.E, ELine.One);
            var king = new King(iniPosKing, EColor.White, _board);
            _board.AddPiece(king);
            var iniPosFirstRook = new Position(EColumn.A, ELine.One);
            var firstRook = new Rook(iniPosFirstRook, EColor.White, _board);
            _board.AddPiece(firstRook);
            var iniPosLastRook = new Position(EColumn.H, ELine.One);
            var lastRook = new Rook(iniPosLastRook, EColor.White, _board);
            var notMoved = !king.Move(newPosition);
            Assert.True(notMoved && king.Position.Equals(iniPosKing) && firstRook.Position.Equals(iniPosFirstRook) && lastRook.Position.Equals(iniPosLastRook));
        }
    }
}
