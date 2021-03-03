using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;

namespace ChessGame.Domain.Entities
{
    public class King : Piece
    {
        public King(Position position, EColor color, Board board) : base(position, color, board)
        {
        }

        protected override bool ValidMove(Position newPosition)
        {
            if (!base.ValidMove(newPosition))
                    return false;

            if (Math.Abs(Position.DifferenceColumn(newPosition)) > 1 || Math.Abs(Position.DifferenceLine(newPosition)) > 1)
                return false;

            return true;
        }
    }
}
