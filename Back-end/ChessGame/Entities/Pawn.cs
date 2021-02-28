using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class Pawn : Piece
    {
        private int _quantityMove;

        public Pawn(Position position, EColor color) : base(position, color)
        {
        }

        public override bool Move(Position newPosition, Board board)
        {
            var moved = base.Move(newPosition, board);
            if (moved)
                _quantityMove++;

            return moved;
        }

        protected override bool SpecialMove(Position newPosition, Board board)
        {
            if (board.Pieces.Any(p => p.Position.Equals(newPosition)))
                return false;

            if (_quantityMove == 0 && Position.EqualsColumn(newPosition) && Math.Abs(Position.DifferenceLine(newPosition)) == 2 && !PositionWillJumpPiece(newPosition, board))
                return true;

            //Implementar movimento En Passant

            return false;
        }

        protected override bool ValidMove(Position newPosition, Board board)
        {
            if (!base.ValidMove(newPosition, board))
                return false;

            if (Color == EColor.White && newPosition.DifferenceLine(Position) == 1 && Math.Abs(newPosition.DifferenceColumn(Position)) == 1)
                if (board.Pieces.Any(p => p.Color != Color && p.Position.Equals(newPosition)))
                    return true;
                else
                    return false;

            if (Color == EColor.Black && newPosition.DifferenceLine(Position) == -1 && Math.Abs(newPosition.DifferenceColumn(Position)) == 1)
                if (board.Pieces.Any(p => p.Color != Color && p.Position.Equals(newPosition)))
                    return true;
                else
                    return false;

            if (board.Pieces.Any(p => p.Position.Equals(newPosition)))
                return false;

            if (newPosition.DifferenceColumn(Position) != 0)
                return false;

            if (Color == EColor.White && newPosition.DifferenceLine(Position) != 1)
                return false;

            if (Color == EColor.Black && newPosition.DifferenceLine(Position) != -1)
                return false;

            return true;
        }

        private bool PositionWillJumpPiece(Position position, Board board)
        {
            var piecesOnWay = board.Pieces.Where(p => p.Position.EqualsColumn(Position) && p.Position.DifferenceLine(Position) == 1);
            foreach (var pieceOnWay in piecesOnWay)
            {
                if (Color == EColor.White && position.DifferenceLine(pieceOnWay.Position) >= 0)
                    return true;

                if (Color == EColor.Black && position.DifferenceLine(pieceOnWay.Position) <= 0)
                    return true;
            }

            return false;
        }
    }
}
