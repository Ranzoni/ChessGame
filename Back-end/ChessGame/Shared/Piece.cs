using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using System.Linq;

namespace ChessGame.Domain.Shared
{
    public abstract class Piece
    {
        public Position Position { get; private set; }
        public EColor Color { get; private set; }

        public Piece(Position position, EColor color)
        {
            Position = position;
            Color = color;
        }

        public bool Move(Position newPosition, Board board)
        {
            if (!ValidMove(newPosition, board))
                return false;

            Position = newPosition;
            return true;
        }

        protected virtual bool ValidMove(Position newPosition, Board board)
        {
            if (newPosition.Equals(Position))
                return false;

            if (board.Pieces.Any(p => p.Color == Color && p.Position.Equals(newPosition)))
                return false;

            return true;
        }
    }
}
