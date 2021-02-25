using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Service.Services;
using Xunit;

namespace ChessGame.Tests.Service
{
    public class PawnServiceTest
    {
        private readonly Board _board;
        private readonly PawnService _pawnService;

        public PawnServiceTest()
        {
            _board = new Board();

            var position = new Position(ELine.Two, EColumn.B);
            var pawn = new Pawn(position, EColor.White);
            _board.AddPiece(pawn);

            var posSecondPawn = new Position(ELine.Three, EColumn.A);
            var secondPawn = new Pawn(posSecondPawn, EColor.White);
            _board.AddPiece(secondPawn);

            var oosThird = new Position(ELine.Three, EColumn.C);
            var thirdPawn = new Pawn(oosThird, EColor.Black);
            _board.AddPiece(thirdPawn);

            _pawnService = new PawnService(pawn);
        }

        [Theory]
        [InlineData(ELine.Three, EColumn.C)]
        [InlineData(ELine.Three, EColumn.B)]
        public void ShouldMoveWhitePawn(ELine line, EColumn column)
        {
            var position = new Position(line, column);
            var moved = _pawnService.Move(position, _board);
            Assert.True(moved);
        }

        [Theory]
        [InlineData(ELine.One, EColumn.C)]
        [InlineData(ELine.One, EColumn.A)]
        [InlineData(ELine.One, EColumn.B)]
        [InlineData(ELine.Three, EColumn.D)]
        [InlineData(ELine.Three, EColumn.A)]
        [InlineData(ELine.Two, EColumn.B)]
        [InlineData(ELine.Five, EColumn.E)]
        [InlineData(ELine.Eight, EColumn.F)]
        public void ShouldNotMoveWhitePawn(ELine line, EColumn column)
        {
            var position = new Position(line, column);
            var notMoved = !_pawnService.Move(position, _board);
            Assert.True(notMoved);
        }
    }
}
