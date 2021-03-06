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
    public class PawnTest
    {
        private static readonly Board _board = BoardBuilder.New().Build();
        private readonly Pawn _whitePawn;
        private readonly Pawn _blackPawn;

        public static IEnumerable<object[]> WhiteValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.B, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Three), EColor.Black, _board), new Position(EColumn.C, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Three), EColor.Black, _board), new Position(EColumn.A, ELine.Three) },
                new object[] { null, new Position(EColumn.B, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.White, _board), new Position(EColumn.B, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.Black, _board), new Position(EColumn.B, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Five), EColor.White, _board), new Position(EColumn.B, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Five), EColor.Black, _board), new Position(EColumn.B, ELine.Four) }
            };

        public static IEnumerable<object[]> BlackValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.D, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.E, ELine.Six), EColor.White, _board), new Position(EColumn.E, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Six), EColor.White, _board), new Position(EColumn.C, ELine.Six) },
                new object[] { null, new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Five), EColor.White, _board), new Position(EColumn.D, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Five), EColor.Black, _board), new Position(EColumn.D, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Four), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Four), EColor.Black, _board), new Position(EColumn.D, ELine.Five) }
            };

        public static IEnumerable<object[]> WhiteInvalidMove =>
           new List<object[]>
           {
                new object[] { null, new Position(EColumn.C, ELine.One) },
                new object[] { null, new Position(EColumn.A, ELine.One) },
                new object[] { null, new Position(EColumn.B, ELine.One) },
                new object[] { null, new Position(EColumn.D, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Three), EColor.White, _board), new Position(EColumn.A, ELine.Three) },
                new object[] { null, new Position(EColumn.B, ELine.Two) },
                new object[] { null, new Position(EColumn.E, ELine.Five) },
                new object[] { null, new Position(EColumn.F, ELine.Eight) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Three), EColor.Black, _board), new Position(EColumn.D, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Four), EColor.Black, _board), new Position(EColumn.A, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Three), EColor.Black, _board), new Position(EColumn.B, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Three), EColor.White, _board), new Position(EColumn.B, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.White, _board), new Position(EColumn.B, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Three), EColor.White, _board), new Position(EColumn.B, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Four), EColor.Black, _board), new Position(EColumn.B, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Three), EColor.Black, _board), new Position(EColumn.B, ELine.Four) },
                new object[] { null, new Position(EColumn.B, ELine.Five) }
           };

        public static IEnumerable<object[]> BlackInvalidMove =>
           new List<object[]>
           {
                new object[] { null, new Position(EColumn.E, ELine.Eight) },
                new object[] { null, new Position(EColumn.C, ELine.Eight) },
                new object[] { null, new Position(EColumn.D, ELine.Eight) },
                new object[] { null, new Position(EColumn.F, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Six), EColor.Black, _board), new Position(EColumn.C, ELine.Six) },
                new object[] { null, new Position(EColumn.D, ELine.Seven) },
                new object[] { null, new Position(EColumn.E, ELine.Five) },
                new object[] { null, new Position(EColumn.A, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.F, ELine.Six), EColor.White, _board), new Position(EColumn.F, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Five), EColor.White, _board), new Position(EColumn.C, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.White, _board), new Position(EColumn.D, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.Black, _board), new Position(EColumn.D, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Five), EColor.Black, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.Black, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Five), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.White, _board), new Position(EColumn.D, ELine.Five) },
                new object[] { null, new Position(EColumn.D, ELine.Four) }
           };

        public PawnTest()
        {
            _board.ClearBoard();
            _whitePawn = PawnBuilder.New().WithPosition(new Position(EColumn.B, ELine.Two)).WithColor(EColor.White).WithBoard(_board).Build();
            _board.AddPiece(_whitePawn);
            _blackPawn = PawnBuilder.New().WithPosition(new Position(EColumn.D, ELine.Seven)).WithColor(EColor.Black).WithBoard(_board).Build();
            _board.AddPiece(_blackPawn);
        }

        [Theory]
        [MemberData(nameof(WhiteValidMove))]
        public void ShouldMoveWhitePawn(Piece pieceToAddBoard, Position newPosition)
        {
            _board.AddPiece(pieceToAddBoard);
            var moved = _whitePawn.Move(newPosition);
            Assert.True(moved && _whitePawn.Position.Equals(newPosition) && _whitePawn.QuantityMove == 1);
        }

        [Theory]
        [MemberData(nameof(BlackValidMove))]
        public void ShouldMoveBlackPawn(Piece pieceToAddBoard, Position newPosition)
        {
            _board.AddPiece(pieceToAddBoard);
            var moved = _blackPawn.Move(newPosition);
            Assert.True(moved && _blackPawn.Position.Equals(newPosition) && _blackPawn.QuantityMove == 1);
        }

        [Theory]
        [MemberData(nameof(WhiteInvalidMove))]
        public void ShouldNotMoveWhitePawn(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _whitePawn.Position;
            _board.AddPiece(pieceToAddBoard);
            var notMoved = !_whitePawn.Move(newPosition);
            Assert.True(notMoved && _whitePawn.Position.Equals(actualPosition) && _whitePawn.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(BlackInvalidMove))]
        public void ShouldNotMoveBlackPawn(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _blackPawn.Position;
            _board.AddPiece(pieceToAddBoard);
            var notMoved = !_blackPawn.Move(newPosition);
            Assert.True(notMoved && _blackPawn.Position.Equals(actualPosition) && _blackPawn.QuantityMove == 0);
        }

        [Fact]
        public void ShouldRegisterQuantityMovie()
        {
            _whitePawn.Move(new Position(EColumn.B, ELine.Three));
            _whitePawn.Move(new Position(EColumn.B, ELine.Four));
            Assert.True(_whitePawn.QuantityMove == 2);
        }
    }
}
