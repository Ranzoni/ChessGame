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
            _position = new Position(EColumn.E, ELine.Three);
            _color = EColor.White;
            _board = BoardBuilder.New().Build();
        }

        public static BishopBuilder New()
        {
            return new BishopBuilder();
        }

        public override Bishop Build()
        {
            return new Bishop(_position, _color, _board);
        }
    }
}
