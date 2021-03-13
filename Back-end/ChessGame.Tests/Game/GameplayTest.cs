using ChessGame.Domain.Builder;
using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using System.Linq;
using Xunit;

namespace ChessGame.Tests.Game
{
    public class GameplayTest
    {
        [Fact]
        public void ShouldPlayerOneMakeHisMove()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.C, ELine.Two));
            var newPosition = new Position(EColumn.C, ELine.Four);
            var moved = gameplay.PlayerMove(pawn, newPosition);
            Assert.True(moved && pawn.Position.Equals(newPosition));
        }

        [Fact]
        public void ShouldPlayerTwoMakeHisMove()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.C, ELine.Two));
            gameplay.PlayerMove(pawn, new Position(EColumn.C, ELine.Four));

            var knight = gameplay.GetPieceFromPosition(new Position(EColumn.G, ELine.Eight));
            var newPosition = new Position(EColumn.F, ELine.Six);
            var moved = gameplay.PlayerMove(knight, newPosition);

            Assert.True(moved && knight.Position.Equals(newPosition));
        }

        [Fact]
        public void ShouldDefinePlayerOneToRound()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();
            Assert.Equal(gameplay.PlayerRound, gameplay.PlayerOne);
        }

        [Fact]
        public void ShouldDefinePlayerTwoToRound()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.C, ELine.Two));
            gameplay.PlayerMove(pawn, new Position(EColumn.C, ELine.Four));

            Assert.Equal(gameplay.PlayerRound, gameplay.PlayerTwo);
        }

        [Fact]
        public void ShouldIncrementRound()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.C, ELine.Two));
            gameplay.PlayerMove(pawn, new Position(EColumn.C, ELine.Four));

            Assert.True(gameplay.Round == 2);
        }

        [Fact]
        public void ShouldNotMoveWhenGameIsNotStarted()
        {
            var gameplay = GameplayBuilder.New().Build();
            var newPosition = new Position(EColumn.C, ELine.Four);
            var notMoved = !gameplay.PlayerMove(null, newPosition);
            Assert.True(notMoved);
        }

        [Fact]
        public void ShouldNotMoveWhenPieceIsNull()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            var newPosition = new Position(EColumn.C, ELine.Four);
            var notMoved = !gameplay.PlayerMove(null, newPosition);
            Assert.True(notMoved);
        }

        [Fact]
        public void ShouldPlayerOneNotMoveBlackPiece()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            var actualPosition = new Position(EColumn.C, ELine.Seven);
            var pawn = gameplay.GetPieceFromPosition(actualPosition);
            var notMoved = !gameplay.PlayerMove(pawn, new Position(EColumn.C, ELine.Six));
            Assert.True(notMoved && pawn.Position.Equals(actualPosition));
        }

        [Fact]
        public void ShouldPlayerTwoNotMoveWhitePiece()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.C, ELine.Two));
            gameplay.PlayerMove(pawn, new Position(EColumn.C, ELine.Three));

            var actualPosition = new Position(EColumn.G, ELine.One);
            var knight = gameplay.GetPieceFromPosition(actualPosition);
            var notMoved = !gameplay.PlayerMove(knight, new Position(EColumn.F, ELine.Three));

            Assert.True(notMoved && knight.Position.Equals(actualPosition));
        }

        [Fact]
        public void ShouldUndoMovePlayer()
        {
            var board = BoardBuilder.New().Build();
            var gameplay = GameplayBuilder.New().WithBoard(board).Build();
            gameplay.StartGame();

            var bishop = gameplay.GetPieceFromPosition(new Position(EColumn.C, ELine.One));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two)), new Position(EColumn.D, ELine.Four));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.A, ELine.Seven)), new Position(EColumn.A, ELine.Six));
            gameplay.PlayerMove(bishop, new Position(EColumn.G, ELine.Five));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Seven)), new Position(EColumn.H, ELine.Six));
            var enemyPawn = gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Seven));
            var lastPositionBishop = bishop.Position;
            var moved = gameplay.PlayerMove(bishop, enemyPawn.Position);
            gameplay.UndoMove();
            Assert.True(moved && board.Pieces.Any(p => p == enemyPawn) && bishop.Position.Equals(lastPositionBishop));
        }

        [Fact]
        public void ShouldBlackKingInCheck()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Two)), new Position(EColumn.E, ELine.Four));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Seven)), new Position(EColumn.D, ELine.Six));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.F, ELine.One)), new Position(EColumn.B, ELine.Five));
            var king = (King)gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Eight));
            Assert.True(gameplay.IsCheck(king));
        }

        [Fact]
        public void ShouldWhiteKingInCheck()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two)), new Position(EColumn.D, ELine.Three));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Seven)), new Position(EColumn.E, ELine.Six));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Three)), new Position(EColumn.D, ELine.Four));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.F, ELine.Eight)), new Position(EColumn.B, ELine.Four));
            var king = (King)gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.One));
            Assert.True(gameplay.IsCheck(king));
        }

        [Fact]
        public void ShouldBlackKingInCheckmate()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Two)), new Position(EColumn.E, ELine.Four));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.F, ELine.Seven)), new Position(EColumn.F, ELine.Six));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.F, ELine.One)), new Position(EColumn.C, ELine.Four));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.G, ELine.Eight)), new Position(EColumn.H, ELine.Six));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.One)), new Position(EColumn.H, ELine.Five));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Six)), new Position(EColumn.F, ELine.Seven));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Five)), new Position(EColumn.F, ELine.Seven));
            var king = (King)gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Eight));
            Assert.True(gameplay.IsCheckmate(king));
        }

        [Fact]
        public void ShouldWhiteKingInCheckmate()
        {
            var gameplay = GameplayBuilder.New().Build();
            gameplay.StartGame();

            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two)), new Position(EColumn.D, ELine.Three));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Seven)), new Position(EColumn.E, ELine.Six));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Three)), new Position(EColumn.D, ELine.Four));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.F, ELine.Eight)), new Position(EColumn.B, ELine.Four));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.One)), new Position(EColumn.D, ELine.Two));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Eight)), new Position(EColumn.G, ELine.Five));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.G, ELine.One)), new Position(EColumn.H, ELine.Three));
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.G, ELine.Five)), new Position(EColumn.D, ELine.Two));
            var king = (King)gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.One));
            Assert.True(gameplay.IsCheckmate(king));
        }
    }
}
