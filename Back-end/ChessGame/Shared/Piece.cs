using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;

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

        public void Move(Position position)
        {            
            Position = position;
        }
    }
}
