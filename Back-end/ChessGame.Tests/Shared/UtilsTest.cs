using ChessGame.Domain.Builder;
using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Shared
{
    public class UtilsTest
    {
        private static readonly Board _board = BoardBuilder.New().Build();

        public static IEnumerable<object[]> Pieces =>
            new List<object[]>
            {
                new object[] { RookBuilder.New().WithColor(EColor.White).WithBoard(_board).Build() },
                new object[] { KnightBuilder.New().WithColor(EColor.White).WithBoard(_board).Build() },
                new object[] { BishopBuilder.New().WithColor(EColor.White).WithBoard(_board).Build() },
                new object[] { QueenBuilder.New().WithColor(EColor.White).WithBoard(_board).Build() },
                new object[] { KingBuilder.New().WithColor(EColor.White).WithBoard(_board).Build() }
            };

        [Theory]
        [MemberData(nameof(Pieces))]
        public void ShouldGetNewInstanceOfAnotherPiece(Piece piece)
        {
            var pawn = new Pawn(new Position(EColumn.H, ELine.Seven), EColor.White, _board, GameplayBuilder.New().Build());
            var newPiece = Utils.GetBuildedPieceFromAnother(piece, pawn.Position, piece.Color, _board);
            Assert.True(newPiece != null && newPiece.GetType() == piece.GetType() && newPiece != piece && newPiece.Position.Equals(pawn.Position) && newPiece.Color == piece.Color);
        }

        [Fact]
        public void ShouldGetNullWhenInstanceIsPawn()
        {
            var bishop = new Bishop(new Position(EColumn.H, ELine.Seven), EColor.White, _board);
            var pawn = new Pawn(new Position(EColumn.A, ELine.One), EColor.White, _board, GameplayBuilder.New().Build());
            var newPiece = Utils.GetBuildedPieceFromAnother(pawn, bishop.Position, pawn.Color, _board);
            Assert.Null(newPiece);
        }
    }
}
