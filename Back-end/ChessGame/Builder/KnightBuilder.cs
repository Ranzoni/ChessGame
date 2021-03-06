using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Shared;

namespace ChessGame.Domain.Builder
{
    public class KnightBuilder : PieceBuilder<Knight>
    {
        public KnightBuilder()
        {
            Position = new Position(EColumn.C, ELine.Three);
            Color = EColor.White;
            Board = BoardBuilder.New().Build();
        }

        public static KnightBuilder New()
        {
            return new KnightBuilder();
        }

        public override Knight Build()
        {
            return new Knight(Position, Color, Board);
        }
    }
}
