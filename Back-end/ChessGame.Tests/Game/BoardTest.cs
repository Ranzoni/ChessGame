using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Builder;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChessGame.Tests.Game
{
    public class BoardTest
    {
        public static IEnumerable<object[]> InvalidAddSamePiece =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.G, ELine.Two), EColor.Black },
            };

        public static IEnumerable<object[]> InvalidKillNonExistentPiece =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.G, ELine.Two), EColor.Black },
            };

        [Fact]
        public void ShouldAddPiece()
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pawn = PawnBuilder.New().Build();
            board.AddPiece(pawn);
            var existisPieceOnBoard = board.GetPieces().Any(p => p.Equals(pawn));
            Assert.True(existisPieceOnBoard);
        }

        [Fact]
        public void ShouldKillPiece()
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pawn = PawnBuilder.New().WithBoard(board).Build();
            board.AddPiece(pawn);
            board.KillPiece(pawn);
            var removedPiecefromBoard = !board.GetPieces().Any(p => p.Equals(pawn));
            var pieceIsDead = board.GetDeadPieces().Any(p => p.Equals(pawn));
            Assert.True(removedPiecefromBoard && pieceIsDead);
        }

        [Theory]
        [MemberData(nameof(InvalidAddSamePiece))]
        public void ShouldNotAddSamePiece(Position positionPieceToAddOnBoard, EColor colorPieceToAddOnBoard)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddOnBoard = PawnBuilder.New().WithPosition(positionPieceToAddOnBoard).WithColor(colorPieceToAddOnBoard).Build();
            board.AddPiece(pieceToAddOnBoard);
            var newPiece = PawnBuilder.New().WithPosition(positionPieceToAddOnBoard).WithColor(colorPieceToAddOnBoard).Build(); ;
            board.AddPiece(newPiece);
            var notExistisPieceOnBoard = !board.GetPieces().Any(p => p.Equals(newPiece));
            Assert.True(notExistisPieceOnBoard);
        }

        [Fact]
        public void ShouldNotAddNullPiece()
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            board.AddPiece(null);
            Assert.True(board.Pieces.Count == 0);
        }

        [Theory]
        [MemberData(nameof(InvalidKillNonExistentPiece))]
        public void ShouldNotKillNonExistentPiece(Position positionPieceToAddOnBoard, EColor colorPieceToAddOnBoard)
        {
            var board = BoardBuilder.New().Build();
            var pieceToAddOnBoard = PawnBuilder.New().WithPosition(positionPieceToAddOnBoard).WithColor(colorPieceToAddOnBoard).Build();
            board.KillPiece(pieceToAddOnBoard);
            var pieceIsNotDead = !board.GetDeadPieces().Any(p => p.Equals(pieceToAddOnBoard));
            Assert.True(pieceIsNotDead);
        }

        [Fact]
        public void ShouldNotKillNullPiece()
        {
            var board = BoardBuilder.New().Build();
            board.KillPiece(null);
            Assert.True(board.DeadPieces.Count == 0);
        }

        [Fact]
        public void ShouldClearBoard()
        {
            var board = BoardBuilder.New().Build();
            var pawn1 = PawnBuilder.New().WithPosition(new Position(EColumn.A, ELine.Two)).WithBoard(board).Build();
            board.AddPiece(pawn1);
            var pawn2 = PawnBuilder.New().WithPosition(new Position(EColumn.B, ELine.Two)).WithBoard(board).Build();
            board.AddPiece(pawn2);
            var pawn3 = PawnBuilder.New().WithPosition(new Position(EColumn.C, ELine.Two)).WithBoard(board).Build();
            board.AddPiece(pawn3);
            board.KillPiece(pawn3);

            board.ClearBoard();

            var boardWasClean = board.Pieces.Count == 0 && board.DeadPieces.Count == 0;
            Assert.True(boardWasClean);
        }
    }
}
