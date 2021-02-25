using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using Xunit;

namespace ChessGame.Tests.Domain
{
    public class PawnTest
    {
        private readonly Pawn _pawn;

        public PawnTest()
        {
            var position = new Position(ELine.Two, EColumn.B);
            _pawn = new Pawn(position, EColor.White);
        }

        [Theory]
        [InlineData(ELine.Three, EColumn.C)]
        [InlineData(ELine.Three, EColumn.A)]
        public void ShouldMovePawn(ELine line, EColumn column)
        {
            var position = new Position(line, column);
            _pawn.Move(position);
            Assert.True(position.Equals(_pawn.Position));
        }
    }
}
