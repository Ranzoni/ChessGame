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

        public Pawn(Position position, EColor color, Board board, Gameplay gameplay) : base(position, color, board)
        {
            _gameplay = gameplay;
        }

        public override bool Move(Position newPosition)
        {
            if (!base.Move(newPosition))
                return false;

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
            if (pawns.Any(p => p.IsEnPassant(this, newPosition)))
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
            var piecesOnWay = _board.Pieces.Where(p => p.Position.EqualsColumn(Position) && p != this);
            foreach (var pieceOnWay in piecesOnWay)
            {
                if (Color == EColor.White && newPosition.DifferenceLine(pieceOnWay.Position) >= 0)
                    return true;

                if (Color == EColor.Black && newPosition.DifferenceLine(pieceOnWay.Position) <= 0)
                    return true;
            }

            return false;
        }

        private bool IsEnPassant(Pawn enemyPawn, Position enemyPawnNewPosition)
        {
            if (_lastRoundMoved != _gameplay.Round - 1)
                return false;

            if (!Position.EqualsLine(enemyPawn.Position) || Math.Abs(Position.DifferenceColumn(enemyPawn.Position)) != 1)
                return false;

            if (Math.Abs(enemyPawnNewPosition.DifferenceLine(Position)) != 1 || !enemyPawnNewPosition.EqualsColumn(Position))
                return false;

            return true;
        }
    }
}
