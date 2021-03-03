using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Tests.Shared;

namespace ChessGame.Tests.Builder
{
    public class KingBuilder : PieceBuilder<King>
    {
        public KingBuilder()
        {
            Position = new Position(EColumn.D, ELine.Four);
            Color = EColor.White;
            Board = BoardBuilder.New().Build();
        }

        public static KingBuilder New()
        {
            return new KingBuilder();
        }

        public override King Build()
        {
            return new King(Position, Color, Board);
        }
    }
}
