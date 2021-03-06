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
            _position = new Position(EColumn.C, ELine.Three);
            _color = EColor.White;
            _board = BoardBuilder.New().Build();
        }

        public static KnightBuilder New()
        {
            return new KnightBuilder();
        }

        public override Knight Build()
        {
            return new Knight(_position, _color, _board);
        }
    }
}
