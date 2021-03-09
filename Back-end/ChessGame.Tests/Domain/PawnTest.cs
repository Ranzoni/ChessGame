using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Builder;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace ChessGame.Tests.Domain
{
    public class PawnTest
    {
        public static IEnumerable<object[]> ValidMove =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.Three), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.Four), EColor.White },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Six), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Five), EColor.Black }
            };

        public static IEnumerable<object[]> ValidMoveWithPiecesOnBoard =>
            new List<object[]>
            {
                new object[] { new Position(EColumn.B, ELine.Four), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Three) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Three) },
                new object[] { new Position(EColumn.B, ELine.Five), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Five), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.C, ELine.Three) },
                new object[] { new Position(EColumn.A, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Three) },
                new object[] { new Position(EColumn.E, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.E, ELine.Six) },
                new object[] { new Position(EColumn.C, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.C, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Four), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Four), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) }
            };

        public static IEnumerable<object[]> InvalidMove =>
           new List<object[]>
           {
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.C, ELine.One), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.A, ELine.One), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.One), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.D, ELine.Three), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.Two), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.E, ELine.Five), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.F, ELine.Eight), EColor.White },
                new object[] { new Position(EColumn.B, ELine.Two), new Position(EColumn.B, ELine.Five), EColor.White },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.E, ELine.Eight), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.C, ELine.Eight), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Eight), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.F, ELine.Six), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Seven), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.E, ELine.Five), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.A, ELine.Four), EColor.Black },
                new object[] { new Position(EColumn.D, ELine.Seven), new Position(EColumn.D, ELine.Four), EColor.Black }
           };

        public static IEnumerable<object[]> InvalidMoveWithPiecesOnBoard =>
           new List<object[]>
           {
                new object[] { new Position(EColumn.A, ELine.Three), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Three) },
                new object[] { new Position(EColumn.D, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.D, ELine.Three) },
                new object[] { new Position(EColumn.A, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.A, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Three) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Three) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.White, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Four), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.B, ELine.Three), EColor.Black, new Position(EColumn.B, ELine.Two), EColor.White, new Position(EColumn.B, ELine.Four) },
                new object[] { new Position(EColumn.C, ELine.Six), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.C, ELine.Six) },
                new object[] { new Position(EColumn.F, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.F, ELine.Six) },
                new object[] { new Position(EColumn.C, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.C, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Six) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.Black, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Five), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
                new object[] { new Position(EColumn.D, ELine.Six), EColor.White, new Position(EColumn.D, ELine.Seven), EColor.Black, new Position(EColumn.D, ELine.Five) },
           };

        public static IEnumerable<object[]> InvalidMoveEnPassant =>
           new List<object[]>
           {
                new object[] { new Position(EColumn.E, ELine.Five) },
                new object[] { new Position(EColumn.F, ELine.Six) },
                new object[] { new Position(EColumn.F, ELine.Five) },
                new object[] { new Position(EColumn.F, ELine.Four) },
                new object[] { new Position(EColumn.D, ELine.Four) },
                new object[] { new Position(EColumn.E, ELine.Four) }
           };

        [Theory]
        [MemberData(nameof(ValidMove))]
        public void ShouldMove(Position actualPosition, Position newPosition, EColor color)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pawn = PawnBuilder.New().WithColor(color).WithPosition(actualPosition).WithBoard(board).Build();
            board.AddPiece(pawn);
            var moved = pawn.Move(newPosition);
            Assert.True(moved && pawn.Position.Equals(newPosition) && pawn.QuantityMove == 1);
        }

        [Theory]
        [MemberData(nameof(ValidMoveWithPiecesOnBoard))]
        public void ShouldMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position actualPosition, EColor color, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = PawnBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var pawn = PawnBuilder.New().WithColor(color).WithPosition(actualPosition).WithBoard(board).Build();
            var moved = pawn.Move(newPosition);
            Assert.True(moved && pawn.Position.Equals(newPosition) && pawn.QuantityMove == 1);
        }

        [Theory]
        [MemberData(nameof(InvalidMove))]
        public void ShouldNotMove(Position actualPosition, Position newPosition, EColor color)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pawn = PawnBuilder.New().WithColor(color).WithPosition(actualPosition).WithBoard(board).Build();
            board.AddPiece(pawn);
            var notMoved = !pawn.Move(newPosition);
            Assert.True(notMoved && pawn.Position.Equals(actualPosition) && pawn.QuantityMove == 0);
        }

        [Theory]
        [MemberData(nameof(InvalidMoveWithPiecesOnBoard))]
        public void ShouldNotMoveWithPiecesOnBoard(Position positionPieceToAddBoard, EColor colorPieceToAddBoard, Position actualPosition, EColor color, Position newPosition)
        {
            var board = BoardBuilder.New().Build();
            board.ClearBoard();
            var pieceToAddBoard = PawnBuilder.New().WithPosition(positionPieceToAddBoard).WithColor(colorPieceToAddBoard).WithBoard(board).Build();
            board.AddPiece(pieceToAddBoard);
            var pawn = PawnBuilder.New().WithColor(color).WithPosition(actualPosition).WithBoard(board).Build();
            var notMoved = !pawn.Move(newPosition);
            Assert.True(notMoved && pawn.Position.Equals(actualPosition) && pawn.QuantityMove == 0);
        }

        [Fact]
        public void ShouldRegisterQuantityMove()
        {
            var pawn = PawnBuilder.New().Build();
            pawn.Move(new Position(EColumn.B, ELine.Three));
            pawn.Move(new Position(EColumn.B, ELine.Four));
            Assert.True(pawn.QuantityMove == 2);
        }

        [Fact]
        public void ShouldKillWhitePawnToLeftEnPassant()
        {
            var board = BoardBuilder.New().Build();
            var gameplay = GameplayBuilder.New().WithBoard(board).Build();
            gameplay.StartGame();
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.A, ELine.Two)), new Position(EColumn.A, ELine.Four));
            //Movimenta o peão que irá comer
            var enemyPawn = gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Seven));
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.E, ELine.Five));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.A, ELine.Four)), new Position(EColumn.A, ELine.Five));
            //Movimenta o peão que irá comer
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.E, ELine.Four));
            //Movimenta o peão que será comido
            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two));
            gameplay.PlayerMove(pawn, new Position(EColumn.D, ELine.Four));
            //Faz o En Passant
            var posToKillEnemyPawn = new Position(EColumn.D, ELine.Three);
            var moved = gameplay.PlayerMove(enemyPawn, posToKillEnemyPawn);
            Assert.True(moved && enemyPawn.Position.Equals(posToKillEnemyPawn) && board.DeadPieces.Any(p => p == pawn));
        }

        [Fact]
        public void ShouldKillWhitePawnToRightEnPassant()
        {
            var board = BoardBuilder.New().Build();
            var gameplay = GameplayBuilder.New().WithBoard(board).Build();
            gameplay.StartGame();
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.A, ELine.Two)), new Position(EColumn.A, ELine.Four));
            //Movimenta o peão que irá comer
            var enemyPawn = gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Seven));
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.E, ELine.Five));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.A, ELine.Four)), new Position(EColumn.A, ELine.Five));
            //Movimenta o peão que irá comer
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.E, ELine.Four));
            //Movimenta o peão que será comido
            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.F, ELine.Two));
            gameplay.PlayerMove(pawn, new Position(EColumn.F, ELine.Four));
            //Faz o En Passant
            var posToKillEnemyPawn = new Position(EColumn.F, ELine.Three);
            var moved = gameplay.PlayerMove(enemyPawn, posToKillEnemyPawn);
            Assert.True(moved && enemyPawn.Position.Equals(posToKillEnemyPawn) && board.DeadPieces.Any(p => p == pawn));
        }

        [Fact]
        public void ShouldKillBlackPawnToLeftEnPassant()
        {
            var board = BoardBuilder.New().Build();
            var gameplay = GameplayBuilder.New().WithBoard(board).Build();
            gameplay.StartGame();
            //Movimenta o peão que irá comer
            var enemyPawn = gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two));
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Four));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Seven)), new Position(EColumn.H, ELine.Five));
            //Movimenta o peão que irá comer
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Five));
            //Movimenta o peão que será comido
            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.C, ELine.Seven));
            gameplay.PlayerMove(pawn, new Position(EColumn.C, ELine.Five));
            //Faz o En Passant
            var posToKillEnemyPawn = new Position(EColumn.C, ELine.Six);
            var moved = gameplay.PlayerMove(enemyPawn, posToKillEnemyPawn);
            Assert.True(moved && enemyPawn.Position.Equals(posToKillEnemyPawn) && board.DeadPieces.Any(p => p == pawn));
        }

        [Fact]
        public void ShouldKillBlackePawnToRightEnPassant()
        {
            var board = BoardBuilder.New().Build();
            var gameplay = GameplayBuilder.New().WithBoard(board).Build();
            gameplay.StartGame();
            //Movimenta o peão que irá comer
            var enemyPawn = gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two));
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Four));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Seven)), new Position(EColumn.H, ELine.Five));
            //Movimenta o peão que irá comer
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Five));
            //Movimenta o peão que será comido
            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Seven));
            gameplay.PlayerMove(pawn, new Position(EColumn.E, ELine.Five));
            //Faz o En Passant
            var posToKillEnemyPawn = new Position(EColumn.E, ELine.Six);
            var moved = gameplay.PlayerMove(enemyPawn, posToKillEnemyPawn);
            Assert.True(moved && enemyPawn.Position.Equals(posToKillEnemyPawn) && board.DeadPieces.Any(p => p == pawn));
        }

        [Theory]
        [MemberData(nameof(InvalidMoveEnPassant))]
        public void ShouldNoKillEnPassant(Position positionEnPassant)
        {
            var board = BoardBuilder.New().Build();
            var gameplay = GameplayBuilder.New().WithBoard(board).Build();
            gameplay.StartGame();
            //Movimenta o peão que irá comer
            var enemyPawn = gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two));
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Four));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Seven)), new Position(EColumn.H, ELine.Five));
            //Movimenta o peão que irá comer
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Five));
            //Movimenta o peão que será comido
            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Seven));
            gameplay.PlayerMove(pawn, new Position(EColumn.E, ELine.Five));
            //Faz o En Passant
            var posBeforeEnPasasnt = enemyPawn.Position;
            var notMoved = !gameplay.PlayerMove(enemyPawn, positionEnPassant);
            Assert.True(notMoved && enemyPawn.Position.Equals(posBeforeEnPasasnt) && !board.DeadPieces.Any(p => p == pawn));
        }

        [Fact]
        public void ShouldNoKillEnPassantWhenPawnHasSameColor()
        {
            var board = BoardBuilder.New().Build();
            var gameplay = GameplayBuilder.New().WithBoard(board).Build();
            gameplay.StartGame();
            //Movimenta o peão que irá comer
            var enemyPawn = gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two));
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Four));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Seven)), new Position(EColumn.H, ELine.Five));
            //Movimenta o peão que irá comer
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Five));
            //Movimenta o peão que será comido
            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Two));
            gameplay.PlayerMove(pawn, new Position(EColumn.E, ELine.Four));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Five)), new Position(EColumn.H, ELine.Four));
            //Movimenta o peão que será comido
            gameplay.PlayerMove(pawn, new Position(EColumn.E, ELine.Five));
            //Faz o En Passant
            var posBeforeEnPasasnt = enemyPawn.Position;
            var notMoved = !gameplay.PlayerMove(enemyPawn, new Position(EColumn.E, ELine.Six));
            Assert.True(notMoved && enemyPawn.Position.Equals(posBeforeEnPasasnt) && !board.DeadPieces.Any(p => p == pawn));
        }

        [Fact]
        public void ShouldNoKillEnPassantWhenRoundHasPassed()
        {
            var board = BoardBuilder.New().Build();
            var gameplay = GameplayBuilder.New().WithBoard(board).Build();
            gameplay.StartGame();
            //Movimenta o peão que irá comer
            var enemyPawn = gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two));
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Four));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Seven)), new Position(EColumn.H, ELine.Five));
            //Movimenta o peão que irá comer
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Five));
            //Movimenta o peão que será comido
            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Seven));
            gameplay.PlayerMove(pawn, new Position(EColumn.E, ELine.Five));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.A, ELine.Two)), new Position(EColumn.A, ELine.Three));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Five)), new Position(EColumn.H, ELine.Four));
            //Faz o En Passant
            var posBeforeEnPasasnt = enemyPawn.Position;
            var notMoved = !gameplay.PlayerMove(enemyPawn, new Position(EColumn.E, ELine.Six));
            Assert.True(notMoved && enemyPawn.Position.Equals(posBeforeEnPasasnt) && !board.DeadPieces.Any(p => p == pawn));
        }

        [Fact]
        public void ShouldNoKillEnPassantWhenPawnMovedTwice()
        {
            var board = BoardBuilder.New().Build();
            var gameplay = GameplayBuilder.New().WithBoard(board).Build();
            gameplay.StartGame();
            //Movimenta o peão que irá comer
            var enemyPawn = gameplay.GetPieceFromPosition(new Position(EColumn.D, ELine.Two));
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Four));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.H, ELine.Seven)), new Position(EColumn.H, ELine.Five));
            //Movimenta o peão que irá comer
            gameplay.PlayerMove(enemyPawn, new Position(EColumn.D, ELine.Five));
            //Movimenta o peão que será comido
            var pawn = gameplay.GetPieceFromPosition(new Position(EColumn.E, ELine.Seven));
            gameplay.PlayerMove(pawn, new Position(EColumn.E, ELine.Six));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(gameplay.GetPieceFromPosition(new Position(EColumn.A, ELine.Two)), new Position(EColumn.A, ELine.Three));
            //Movimenta uma peça qualquer
            gameplay.PlayerMove(pawn, new Position(EColumn.E, ELine.Six));
            //Faz o En Passant
            var posBeforeEnPasasnt = enemyPawn.Position;
            var notMoved = !gameplay.PlayerMove(enemyPawn, new Position(EColumn.E, ELine.Six));
            Assert.True(notMoved && enemyPawn.Position.Equals(posBeforeEnPasasnt) && !board.DeadPieces.Any(p => p == pawn));
        }
    }
}
