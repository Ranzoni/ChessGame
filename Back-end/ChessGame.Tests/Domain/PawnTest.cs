using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using ChessGame.Tests.Builder;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class PawnTest
    {
        private readonly Pawn _whitePawn;
        private readonly Pawn _blackPawn;

        public static IEnumerable<object[]> WhiteValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.B, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Three), EColor.Black), new Position(EColumn.C, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Three), EColor.Black), new Position(EColumn.A, ELine.Three) }
            };

        public static IEnumerable<object[]> BlackValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.D, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.E, ELine.Six), EColor.White), new Position(EColumn.E, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Six), EColor.White), new Position(EColumn.C, ELine.Six) }
            };

        public static IEnumerable<object[]> WhiteInvalidMove =>
           new List<object[]>
           {
                new object[] { null, new Position(EColumn.C, ELine.One) },
                new object[] { null, new Position(EColumn.A, ELine.One) },
                new object[] { null, new Position(EColumn.B, ELine.One) },
                new object[] { null, new Position(EColumn.D, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Three), EColor.White), new Position(EColumn.A, ELine.Three) },
                new object[] { null, new Position(EColumn.B, ELine.Two) },
                new object[] { null, new Position(EColumn.E, ELine.Five) },
                new object[] { null, new Position(EColumn.F, ELine.Eight) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Three), EColor.Black), new Position(EColumn.D, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Four), EColor.Black), new Position(EColumn.A, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Three), EColor.Black), new Position(EColumn.B, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Three), EColor.White), new Position(EColumn.B, ELine.Three) }
           };

        public static IEnumerable<object[]> BlackInvalidMove =>
           new List<object[]>
           {
                new object[] { null, new Position(EColumn.E, ELine.Eight) },
                new object[] { null, new Position(EColumn.C, ELine.Eight) },
                new object[] { null, new Position(EColumn.D, ELine.Eight) },
                new object[] { null, new Position(EColumn.F, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Six), EColor.Black), new Position(EColumn.C, ELine.Six) },
                new object[] { null, new Position(EColumn.D, ELine.Seven) },
                new object[] { null, new Position(EColumn.E, ELine.Five) },
                new object[] { null, new Position(EColumn.A, ELine.Four) },
                new object[] { new Pawn(new Position(EColumn.F, ELine.Six), EColor.White), new Position(EColumn.F, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Five), EColor.White), new Position(EColumn.C, ELine.Five) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.White), new Position(EColumn.D, ELine.Six) },
                new object[] { new Pawn(new Position(EColumn.D, ELine.Six), EColor.Black), new Position(EColumn.D, ELine.Six) }
           };

        public PawnTest()
        {
            _whitePawn = PawnBuilder.New().WithPosition(new Position(EColumn.B, ELine.Two)).WithColor(EColor.White).Build();
            _blackPawn = PawnBuilder.New().WithPosition(new Position(EColumn.D, ELine.Seven)).WithColor(EColor.Black).Build();
        }

        [Theory]
        [MemberData(nameof(WhiteValidMove))]
        public void ShouldMoveWhitePawn(Piece pieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().WithPiece(pieceToAddBoard).WithPiece(_whitePawn).Build();
            var moved = _whitePawn.Move(newPosition, board);
            Assert.True(moved && _whitePawn.Position.Equals(newPosition));
        }

        [Theory]
        [MemberData(nameof(BlackValidMove))]
        public void ShouldMoveBlackPawn(Piece pieceToAddBoard, Position newPosition)
        {
            var board = BoardBuilder.New().WithPiece(pieceToAddBoard).WithPiece(_blackPawn).Build();
            var moved = _blackPawn.Move(newPosition, board);
            Assert.True(moved && _blackPawn.Position.Equals(newPosition));
        }

        [Theory]
        [MemberData(nameof(WhiteInvalidMove))]
        public void ShouldNotMoveWhitePawn(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _whitePawn.Position;
            var board = BoardBuilder.New().WithPiece(pieceToAddBoard).WithPiece(_whitePawn).Build();
            var notMoved = !_whitePawn.Move(newPosition, board);
            Assert.True(notMoved && _whitePawn.Position.Equals(actualPosition));
        }

        [Theory]
        [MemberData(nameof(BlackInvalidMove))]
        public void ShouldNotMoveBlackPawn(Piece pieceToAddBoard, Position newPosition)
        {
            var actualPosition = _blackPawn.Position;
            var board = BoardBuilder.New().WithPiece(pieceToAddBoard).WithPiece(_blackPawn).Build();
            var notMoved = !_whitePawn.Move(newPosition, board);
            Assert.True(notMoved && _blackPawn.Position.Equals(actualPosition));
        }
    }
}
