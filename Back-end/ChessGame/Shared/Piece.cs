using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using System.Linq;

namespace ChessGame.Domain.Shared
{
    public abstract class Piece
    {
        protected readonly Board _board;

        public Position Position { get; private set; }
        public EColor Color { get; private set; }

        public Piece(Position position, EColor color, Board board)
        {
            Position = position;
            Color = color;
            _board = board;
        }

        public virtual bool Move(Position newPosition)
        {
            if (!SpecialMove(newPosition) && !ValidMove(newPosition))
                return false;

            Position = newPosition;
            return true;
        }

        protected virtual bool ValidMove(Position newPosition)
        {
            if (newPosition.Equals(Position))
                return false;

            if (_board.Pieces.Any(p => p.Color == Color && p.Position.Equals(newPosition)))
                return false;

            return true;
        }

        protected virtual bool SpecialMove(Position newPosition)
        {
            return false;
        }

        protected virtual bool PositionWillJumpPiece(Position newPosition)
        {
            return false;
        }
    }
}
