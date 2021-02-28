using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;

namespace ChessGame.Tests.Builder
{
    public class PawnBuilder
    {
        private static Position Position = new Position(EColumn.B, ELine.Two);
        private static EColor Color = EColor.White;
        private static Board Board = BoardBuilder.New().Build();

        public static PawnBuilder New()
        {
            return new PawnBuilder();
        }

        public PawnBuilder WithPosition(Position position)
        {
            Position = position;
            return this;
        }

        public PawnBuilder WithColor(EColor color)
        {
            Color = color;
            return this;
        }

        public PawnBuilder WithBoard(Board board)
        {
            Board = board;
            return this;
        }

        public Pawn Build()
        {
            return new Pawn(Position, Color, Board);
        }
    }
}
