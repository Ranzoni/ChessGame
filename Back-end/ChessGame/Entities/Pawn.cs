using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class Pawn : Piece
    {
        private int _lastRoundMoved;
        private readonly Gameplay _gameplay;
        private Pawn _pawnToKillEnPassant;

        public Pawn(Position position, EColor color, Board board, Gameplay gameplay) : base(position, color, board)
        {
            _gameplay = gameplay;
        }

        public override bool Move(Position newPosition)
        {
            _pawnToKillEnPassant = null;
            if (!base.Move(newPosition))
                return false;

            _board.KillPiece(_pawnToKillEnPassant);
            _lastRoundMoved = _gameplay.Round;
            return true;
        }

        protected override bool SpecialMove(Position newPosition)
        {
            if (_board.Pieces.Any(p => p.Position.Equals(newPosition)))
                return false;

            if (QuantityMove == 0 && Position.EqualsColumn(newPosition) && Math.Abs(Position.DifferenceLine(newPosition)) == 2 && !PositionWillJumpPiece(newPosition))
                return true;

            var pawns = _board.Pieces.Where(p => p is Pawn && p.Color != Color).Select(p => (Pawn)p);
            _pawnToKillEnPassant = pawns.Where(p => p.IsEnPassant(this, newPosition)).FirstOrDefault();
            if (_pawnToKillEnPassant != null)
                return true;

            return false;
        }

        protected override bool ValidMove(Position newPosition)
        {
            if (!base.ValidMove(newPosition))
                return false;

            if (Color == EColor.White && newPosition.DifferenceLine(Position) == 1 && Math.Abs(newPosition.DifferenceColumn(Position)) == 1)
                if (_board.Pieces.Any(p => p.Color != Color && p.Position.Equals(newPosition)))
                    return true;
                else
                    return false;

            if (Color == EColor.Black && newPosition.DifferenceLine(Position) == -1 && Math.Abs(newPosition.DifferenceColumn(Position)) == 1)
                if (_board.Pieces.Any(p => p.Color != Color && p.Position.Equals(newPosition)))
                    return true;
                else
                    return false;

            if (_board.Pieces.Any(p => p.Position.Equals(newPosition)))
                return false;

            if (newPosition.DifferenceColumn(Position) != 0)
                return false;

            if (Color == EColor.White && newPosition.DifferenceLine(Position) != 1)
                return false;

            if (Color == EColor.Black && newPosition.DifferenceLine(Position) != -1)
                return false;

            return true;
        }

        protected override bool PositionWillJumpPiece(Position newPosition)
        {
            if (Color == EColor.White)
            {
                var piecesOnWay = _board.Pieces.Where(p => p.Position.EqualsColumn(Position) && p.Position.DifferenceLine(Position) > 0);
                foreach (var pieceOnWay in piecesOnWay)
                    if (newPosition.DifferenceLine(pieceOnWay.Position) >= 0)
                        return true;
            }
            else
            {
                var piecesOnWay = _board.Pieces.Where(p => p.Position.EqualsColumn(Position) && p.Position.DifferenceLine(Position) < 0);
                foreach (var pieceOnWay in piecesOnWay)
                    if (newPosition.DifferenceLine(pieceOnWay.Position) <= 0)
                        return true;
            }

            return false;
        }

        private bool IsEnPassant(Pawn enemyPawn, Position enemyPawnNewPosition)
        {
            if (QuantityMove != 1 || _lastRoundMoved != _gameplay.Round - 1)
                return false;

            if (!(Color == EColor.White && Position.Line == ELine.Four) && !(Color == EColor.Black && Position.Line == ELine.Five))
                return false;

            if (!Position.EqualsLine(enemyPawn.Position) || Math.Abs(Position.DifferenceColumn(enemyPawn.Position)) != 1)
                return false;

            if (!enemyPawnNewPosition.EqualsColumn(Position))
                return false;

            if (!(Color == EColor.White && enemyPawnNewPosition.DifferenceLine(Position) == -1) && !(Color == EColor.Black && enemyPawnNewPosition.DifferenceLine(Position) == 1))
                return false;

            return true;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
