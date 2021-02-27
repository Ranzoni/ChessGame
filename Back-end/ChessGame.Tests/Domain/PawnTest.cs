using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Tests.Builder;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class PawnTest
    {
        private readonly Pawn _pawn;

        public PawnTest()
        {
            _pawn = PawnBuilder.New().Build();
        }

        [Theory]
        [InlineData(EColumn.C, ELine.Three)]
        [InlineData(EColumn.A, ELine.Three)]
        public void ShouldMovePawn(EColumn column, ELine line)
        {
            var position = new Position(column, line);
            _pawn.Move(position);
            Assert.True(position.Equals(_pawn.Position));
        }
    }
}
