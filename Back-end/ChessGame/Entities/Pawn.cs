using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class Pawn : Piece
    {
        public Pawn(Position position, EColor color) : base(position, color)
        {
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
    }
}
