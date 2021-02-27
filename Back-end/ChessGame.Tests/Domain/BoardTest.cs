using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using ChessGame.Tests.Builder;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class BoardTest
    {
        private readonly Board _board;

        public static IEnumerable<object[]> InvalidAddPiece =>
            new List<object[]>
            {
                new object[] { null, null },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Two), EColor.Black), new Pawn(new Position(EColumn.A, ELine.Two), EColor.Black) },
            };

        public static IEnumerable<object[]> InvalidKillPiece =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Two), EColor.Black) },
            };

        public BoardTest()
        {
            _board = new Board();
        }

        [Fact]
        public void ShouldAddPiece()
        {
            var pawn = PawnBuilder.New().Build();
            _board.AddPiece(pawn);

            var existisPieceOnBoard = _board.GetPieces().Any(p => p.Equals(pawn));
            Assert.True(existisPieceOnBoard);
        }

        [Fact]
        public void ShouldKillPiece()
        {
            var pawn = PawnBuilder.New().Build();
            var board = BoardBuilder.New().WithPiece(pawn).Build();
            board.KillPiece(pawn);

            var removedPiecefromBoard = !board.GetPieces().Any(p => p.Equals(pawn));
            var pieceIsDead = board.GetDeadPieces().Any(p => p.Equals(pawn));
            Assert.True(removedPiecefromBoard && pieceIsDead);
        }

        [Theory]
        [MemberData(nameof(InvalidAddPiece))]
        public void ShouldNotAddPiece(Piece pieceToPutOnBoard, Piece newPiece)
        {
            var board = BoardBuilder.New().WithPiece(pieceToPutOnBoard).Build();
            board.AddPiece(newPiece);

            var notExistisPieceOnBoard = !board.GetPieces().Any(p => p.Equals(newPiece));
            Assert.True(notExistisPieceOnBoard);
        }

        [Theory]
        [MemberData(nameof(InvalidKillPiece))]
        public void ShouldNotKillPiece(Piece piece)
        {
            _board.KillPiece(piece);

            var pieceIsNotDead = !_board.GetDeadPieces().Any(p => p.Equals(piece));
            Assert.True(pieceIsNotDead);
        }
    }
}
