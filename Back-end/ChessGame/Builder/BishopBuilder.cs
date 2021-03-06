using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Shared;

namespace ChessGame.Domain.Builder
{
    public class BishopBuilder : PieceBuilder<Bishop>
    {
        public BishopBuilder()
        {
            Position = new Position(EColumn.E, ELine.Three);
            Color = EColor.White;
            Board = BoardBuilder.New().Build();
        }

        public static BishopBuilder New()
        {
            return new BishopBuilder();
        }

        public override Bishop Build()
        {
            return new Bishop(Position, Color, Board);
        }
    }
}
