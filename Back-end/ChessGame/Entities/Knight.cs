using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;

namespace ChessGame.Domain.Entities
{
    public class Knight : Piece
    {
        public Knight(Position position, EColor color, Board board) : base(position, color, board)
        {
        }

        protected override bool ValidMove(Position newPosition)
        {
            if (!base.ValidMove(newPosition))
                return false;

            if (Math.Abs(Position.DifferenceColumn(newPosition)) == 2 && Math.Abs(Position.DifferenceLine(newPosition)) == 1)
                return true;

            if (Math.Abs(Position.DifferenceColumn(newPosition)) == 1 && Math.Abs(Position.DifferenceLine(newPosition)) == 2)
                return true;

            return false;
        }
    }
}
