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
        private static readonly Board _board = new Board();

        public static IEnumerable<object[]> InvalidAddPiece =>
            new List<object[]>
            {
                new object[] { null, null },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Two), EColor.Black, _board), new Pawn(new Position(EColumn.A, ELine.Two), EColor.Black, _board) },
            };

        public static IEnumerable<object[]> InvalidKillPiece =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Two), EColor.Black, _board) },
            };

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

        [Fact]
        public void ShouldClearBoard()
        {
            var pawn1 = PawnBuilder.New().WithPosition(new Position(EColumn.A, ELine.Two)).WithBoard(_board).Build();
            _board.AddPiece(pawn1);
            var pawn2 = PawnBuilder.New().WithPosition(new Position(EColumn.B, ELine.Two)).WithBoard(_board).Build();
            _board.AddPiece(pawn2);
            var pawn3 = PawnBuilder.New().WithPosition(new Position(EColumn.C, ELine.Two)).WithBoard(_board).Build();
            _board.AddPiece(pawn3);
            _board.KillPiece(pawn3);

            _board.ClearBoard();

            var boardWasClean = _board.Pieces.Count == 0 && _board.DeadPieces.Count == 0;
            Assert.True(boardWasClean);
        }
    }
}
