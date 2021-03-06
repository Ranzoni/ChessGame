using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Shared;

namespace ChessGame.Domain.Builder
{
    public class QueenBuilder : PieceBuilder<Queen>
    {
        public QueenBuilder()
        {
            Position = new Position(EColumn.D, ELine.Four);
            Color = EColor.Black;
            Board = BoardBuilder.New().Build();
        }

        public static QueenBuilder New()
        {
            return new QueenBuilder();
        }

        public override Queen Build()
        {
            return new Queen(Position, Color, Board);
        }
    }
}
