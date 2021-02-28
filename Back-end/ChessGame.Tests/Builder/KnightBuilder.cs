using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;

namespace ChessGame.Tests.Builder
{
    public class KnightBuilder
    {
        private static Position Position = new Position(EColumn.C, ELine.Three);
        private static EColor Color = EColor.White;
        private static Board Board = BoardBuilder.New().Build();

        public static KnightBuilder New()
        {
            return new KnightBuilder();
        }

        public KnightBuilder WithPosition(Position position)
        {
            Position = position;
            return this;
        }

        public KnightBuilder WithColor(EColor color)
        {
            Color = color;
            return this;
        }

        public KnightBuilder WithBoard(Board board)
        {
            Board = board;
            return this;
        }

        public Knight Build()
        {
            return new Knight(Position, Color, Board);
        }
    }
}
