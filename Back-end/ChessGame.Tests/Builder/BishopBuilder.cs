using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;

namespace ChessGame.Tests.Builder
{
    public class BishopBuilder
    {
        private static Position Position = new Position(EColumn.E, ELine.Three);
        private static EColor Color = EColor.White;
        private static Board Board = BoardBuilder.New().Build();

        public static BishopBuilder New()
        {
            return new BishopBuilder();
        }

        public BishopBuilder WithPosition(Position position)
        {
            Position = position;
            return this;
        }

        public BishopBuilder WithColor(EColor color)
        {
            Color = color;
            return this;
        }

        public BishopBuilder WithBoard(Board board)
        {
            Board = board;
            return this;
        }

        public Bishop Build()
        {
            return new Bishop(Position, Color, Board);
        }
    }
}
