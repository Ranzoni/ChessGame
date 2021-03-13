using ChessGame.Domain.Builder;
using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Domain.Game
{
    public class Gameplay
    {
        private readonly Board _board;
        private bool _started;
        private Piece _lastPieceMoved;
        private Piece _lastPieceKilled;

        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }
        public Player PlayerRound { get; private set; }
        public int Round { get; private set; }

        public Gameplay(Board board, Player playerOne, Player playerTwo)
        {
            _board = board;
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public void StartGame()
        {
            _board.ClearBoard();
            Round = 1;
            OrganizePieces();
            PlayerRound = PlayerOne;
            _lastPieceMoved = null;
            _lastPieceKilled = null;
            _started = true;
        }

        public bool PlayerMove(Piece pieceToMove, Position newPosition)
        {
            if (!_started || pieceToMove == null || pieceToMove.Color != PlayerRound.Color || HasKingInCheckmate())
                return false;

            if (!ExecuteMove(pieceToMove, newPosition))
                return false;

            if (KingWillBeInCheck(pieceToMove.Color))
            {
                UndoMove();
                return false;
            }

            SetPlayerRound();

            Round++;

            return true;
        }

        private bool ExecuteMove(Piece piece, Position newPosition)
        {
            if (!piece.Move(newPosition))
                return false;

            var enemyPieceOnPosition = _board.Pieces.Where(p => p.Color != piece.Color && p.Position.Equals(newPosition)).FirstOrDefault();
            if (enemyPieceOnPosition != null)
            {
                _board.KillPiece(enemyPieceOnPosition);
                _lastPieceKilled = enemyPieceOnPosition;
            }

            _lastPieceMoved = piece;

            return true;
        }

        private void UndoMove()
        {
            if (_lastPieceMoved == null)
                return;

            _lastPieceMoved.UndoMove();
            _board.AddPiece(_lastPieceKilled);
        }

        public Piece GetPieceFromPosition(Position position)
        {
            return _board.GetPieceFromPosition(position);
        }

        public bool IsCheck(King king)
        {
            return _board.Pieces.Any(p => p.Color != king.Color && p.MoveIsValid(king.Position));
        }

        public bool IsCheckmate(King king)
        {
            if (!IsCheck(king))
                return false;

            foreach (var piece in _board.Pieces.Where(p => p.Color == king.Color))
                foreach (var position in piece.AvailableMovements())
                {
                    ExecuteMove(piece, position);
                    var notIsCheck = !IsCheck(king);
                    UndoMove();
                    if (notIsCheck)
                        return false;
                }

            return true;
        }

        private bool KingWillBeInCheck(EColor color)
        {
            var king = _board.Pieces.Where(p => p is King && p.Color == color).Select(p => (King)p).FirstOrDefault();
            if (IsCheck(king) && PlayerRound.Color == color)
                return true;

            return false;
        }

        private bool HasKingInCheckmate()
        {
            var kings = _board.Pieces.Where(p => p is King).Select(p => (King)p);
            foreach (var king in kings)
                if (IsCheckmate(king))
                    return true;

            return false;
        }

        private void OrganizePieces()
        {
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.A, ELine.Two)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.B, ELine.Two)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.C, ELine.Two)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.D, ELine.Two)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.E, ELine.Two)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.F, ELine.Two)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.G, ELine.Two)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.H, ELine.Two)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(RookBuilder.New().WithPosition(new Position(EColumn.A, ELine.One)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(KnightBuilder.New().WithPosition(new Position(EColumn.B, ELine.One)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(BishopBuilder.New().WithPosition(new Position(EColumn.C, ELine.One)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(QueenBuilder.New().WithPosition(new Position(EColumn.D, ELine.One)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(KingBuilder.New().WithPosition(new Position(EColumn.E, ELine.One)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(BishopBuilder.New().WithPosition(new Position(EColumn.F, ELine.One)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(KnightBuilder.New().WithPosition(new Position(EColumn.G, ELine.One)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(RookBuilder.New().WithPosition(new Position(EColumn.H, ELine.One)).WithColor(EColor.White).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.A, ELine.Seven)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.B, ELine.Seven)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.C, ELine.Seven)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.D, ELine.Seven)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.E, ELine.Seven)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.F, ELine.Seven)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.G, ELine.Seven)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(PawnBuilder.New().WithGameplay(this).WithPosition(new Position(EColumn.H, ELine.Seven)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(RookBuilder.New().WithPosition(new Position(EColumn.A, ELine.Eight)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(KnightBuilder.New().WithPosition(new Position(EColumn.B, ELine.Eight)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(BishopBuilder.New().WithPosition(new Position(EColumn.C, ELine.Eight)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(QueenBuilder.New().WithPosition(new Position(EColumn.D, ELine.Eight)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(KingBuilder.New().WithPosition(new Position(EColumn.E, ELine.Eight)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(BishopBuilder.New().WithPosition(new Position(EColumn.F, ELine.Eight)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(KnightBuilder.New().WithPosition(new Position(EColumn.G, ELine.Eight)).WithColor(EColor.Black).WithBoard(_board).Build());
            _board.AddPiece(RookBuilder.New().WithPosition(new Position(EColumn.H, ELine.Eight)).WithColor(EColor.Black).WithBoard(_board).Build());
        }

        private void SetPlayerRound()
        {
            PlayerRound = PlayerRound == PlayerOne ? PlayerTwo : PlayerOne;
        }

        public void ExchangePawnForAnotherPiece(Pawn pawn, Piece pieceToExchange)
        {
            if (pieceToExchange is Pawn && PawnIsEndOfBoard(pawn))
                return;

            _board.ExchangePieceForAnother(pawn, pieceToExchange);
        }

        private bool PawnIsEndOfBoard(Pawn pawn)
        {
            if (pawn.Color == EColor.White && pawn.Position.Line == ELine.Eight)
                return true;

            if (pawn.Color == EColor.Black && pawn.Position.Line == ELine.One)
                return true;

            return false;
        }

        public IEnumerable<Piece> GetDeadPieces(EColor color)
        {
            return _board.DeadPieces.Where(p => p.Color == color);
        }
    }
}
