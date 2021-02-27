using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using ChessGame.Service.Services;
using ChessGame.Tests.Builder;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ChessGame.Tests.Service
{
    public class PawnServiceTest
    {
        private readonly Board _board;
        private readonly PawnService _whitePawnService;
        private readonly PawnService _blackPawnService;

        public static IEnumerable<object[]> WhiteValidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.B, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.C, ELine.Three), EColor.Black), new Position(EColumn.C, ELine.Three) }
            };

        public static IEnumerable<object[]> WhiteInvalidMove =>
            new List<object[]>
            {
                new object[] { null, new Position(EColumn.C, ELine.One) },
                new object[] { null, new Position(EColumn.A, ELine.One) },
                new object[] { null, new Position(EColumn.B, ELine.One) },
                new object[] { null, new Position(EColumn.D, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.A, ELine.Three), EColor.White), new Position(EColumn.A, ELine.Three) },
                new object[] { new Pawn(new Position(EColumn.B, ELine.Two), EColor.White), new Position(EColumn.B, ELine.Two) },
                new object[] { null, new Position(EColumn.E, ELine.Five) },
                new object[] { null, new Position(EColumn.F, ELine.Eight) }
            };

        public PawnServiceTest()
        {
            _board = new Board();

            var position = new Position(EColumn.B, ELine.Two);
            var pawn = PawnBuilder.New().WithPosition(position).WithColor(EColor.White).Build();
            _whitePawnService = new PawnService(pawn);
            _board.AddPiece(pawn);

            //position = new Position(EColumn.C, ELine.Seven);
            //pawn = PawnBuilder.New().WithPosition(position).WithColor(EColor.Black).Build();
            //_blackPawnService = new PawnService(pawn);
            //_board.AddPiece(pawn);
        }

        [Theory]
        [MemberData(nameof(WhiteValidMove))]
        public void ShouldMoveWhitePawn(Piece pieceToAddBoard, Position newPosition)
        {
            _board.AddPiece(pieceToAddBoard);
            var moved = _whitePawnService.Move(newPosition, _board);
            Assert.True(moved);
        }

        //[Theory]
        //[InlineData(EColumn.C, ELine.Three)]
        //[InlineData(EColumn.B, ELine.Three)]
        //public void ShouldMoveWhitePawn(EColumn column, ELine line)
        //{
        //    var position = new Position(column, line);
        //    var moved = _whitePawnService.Move(position, _board);
        //    Assert.True(moved);
        //}

        [Theory]
        [MemberData(nameof(WhiteInvalidMove))]
        public void ShouldNotMoveWhitePawn(EColumn column, ELine line)
        {
            var position = new Position(column, line);
            var notMoved = !_whitePawnService.Move(position, _board);
            Assert.True(notMoved);
        }
    }
}
