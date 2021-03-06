using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Shared;

namespace ChessGame.Domain.Builder
{
    public class KingBuilder : PieceBuilder<King>
    {
        public KingBuilder()
        {
            _position = new Position(EColumn.D, ELine.Four);
            _color = EColor.White;
            _board = BoardBuilder.New().Build();
        }

        public static KingBuilder New()
        {
            return new KingBuilder();
        }

        public override King Build()
        {
            return new King(_position, _color, _board);
        }
    }
}
