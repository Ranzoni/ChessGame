using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Structs;

namespace ChessGame.Domain.Shared
{
    public abstract class PieceBuilder<T> : IBuilder<T>
    {
        protected static Position Position;
        protected static EColor Color;
        protected static Board Board;

        public PieceBuilder<T> WithPosition(Position position)
        {
            Position = position;
            return this;
        }

        public PieceBuilder<T> WithColor(EColor color)
        {
            Color = color;
            return this;
        }

        public PieceBuilder<T> WithBoard(Board board)
        {
            Board = board;
            return this;
        }

        public abstract T Build();
    }
}
