using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;

namespace ChessGame.Tests.Builder
{
    public class RookBuilder
    {
        private static Position Position = new Position(EColumn.A, ELine.One);
        private static EColor Color = EColor.White;
        private static Board Board = BoardBuilder.New().Build();

        public static RookBuilder New()
        {
            return new RookBuilder();
        }

        public RookBuilder WithPosition(Position position)
        {
            Position = position;
            return this;
        }

        public RookBuilder WithColor(EColor color)
        {
            Color = color;
            return this;
        }

        public RookBuilder WithBoard(Board board)
        {
            Board = board;
            return this;
        }

        public Rook Build()
        {
            return new Rook(Position, Color, Board);
        }
    }
}
