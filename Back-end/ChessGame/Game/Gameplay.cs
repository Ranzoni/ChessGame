using ChessGame.Domain.Builder;
using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using System.Linq;

namespace ChessGame.Domain.Game
{
    public class Gameplay
    {
        public Board Board { get; private set; }
        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }
        public Player PlayerTurn { get; private set; }
        public int Round { get; private set; }

        public Gameplay(Board board, Player playerOne, Player playerTwo)
        {
            Board = board;
            PlayerOne = playerOne;
            PlayerTurn = PlayerOne;
            PlayerTwo = playerTwo;
        }

        public void StartGame()
        {
            OrganizePieces();
        }

        public void MovePlayer(Position actualPosition, Position newPosition)
        {
            var pieceToMove = Board.Pieces.Where(p => p.Color == PlayerTurn.Color && p.Position.Equals(actualPosition)).FirstOrDefault();
            if (pieceToMove == null)
                return;

            var enemyPieceOnPosition = Board.Pieces.Where(p => p.Color != pieceToMove.Color && p.Position.Equals(newPosition)).FirstOrDefault();
            if (pieceToMove.Move(newPosition))
            {
                if (PlayerTurn == PlayerOne)
                    PlayerTurn = PlayerTwo;
                else
                    PlayerTurn = PlayerOne;

                if (enemyPieceOnPosition != null)
                    Board.KillPiece(enemyPieceOnPosition);
            }
        }

        private void OrganizePieces()
        {
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.A, ELine.Two)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.B, ELine.Two)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.C, ELine.Two)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.D, ELine.Two)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.E, ELine.Two)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.F, ELine.Two)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.G, ELine.Two)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.H, ELine.Two)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(RookBuilder.New().WithPosition(new Position(EColumn.A, ELine.One)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(KnightBuilder.New().WithPosition(new Position(EColumn.B, ELine.One)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(BishopBuilder.New().WithPosition(new Position(EColumn.C, ELine.One)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(QueenBuilder.New().WithPosition(new Position(EColumn.D, ELine.One)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(KingBuilder.New().WithPosition(new Position(EColumn.E, ELine.One)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(BishopBuilder.New().WithPosition(new Position(EColumn.F, ELine.One)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(KnightBuilder.New().WithPosition(new Position(EColumn.G, ELine.One)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(RookBuilder.New().WithPosition(new Position(EColumn.H, ELine.One)).WithColor(EColor.White).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.A, ELine.Seven)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.B, ELine.Seven)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.C, ELine.Seven)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.D, ELine.Seven)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.E, ELine.Seven)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.F, ELine.Seven)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.G, ELine.Seven)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(PawnBuilder.New().WithPosition(new Position(EColumn.H, ELine.Seven)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(RookBuilder.New().WithPosition(new Position(EColumn.A, ELine.Eight)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(KnightBuilder.New().WithPosition(new Position(EColumn.B, ELine.Eight)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(BishopBuilder.New().WithPosition(new Position(EColumn.C, ELine.Eight)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(QueenBuilder.New().WithPosition(new Position(EColumn.D, ELine.Eight)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(KingBuilder.New().WithPosition(new Position(EColumn.E, ELine.Eight)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(BishopBuilder.New().WithPosition(new Position(EColumn.F, ELine.Eight)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(KnightBuilder.New().WithPosition(new Position(EColumn.G, ELine.Eight)).WithColor(EColor.Black).WithBoard(Board).Build());
            Board.AddPiece(RookBuilder.New().WithPosition(new Position(EColumn.H, ELine.Eight)).WithColor(EColor.Black).WithBoard(Board).Build());
        }
    }
}
