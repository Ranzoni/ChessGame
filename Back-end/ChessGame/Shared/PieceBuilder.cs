using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Structs;

namespace ChessGame.Domain.Shared
{
    public abstract class PieceBuilder<T> : IBuilder<T>
    {
        protected static Position _position;
        protected static EColor _color;
        protected static Board _board;

        public PieceBuilder<T> WithPosition(Position position)
        {
            _position = position;
            return this;
        }

        public PieceBuilder<T> WithColor(EColor color)
        {
            _color = color;
            return this;
        }

        public PieceBuilder<T> WithBoard(Board board)
        {
            _board = board;
            return this;
        }

        public abstract T Build();
    }
}
