using ChessGame.Domain.Builder;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
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

            Assert.True(gameplay.Round == 1);
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
    }
}
