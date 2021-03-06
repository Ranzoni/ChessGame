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
            _position = new Position(EColumn.D, ELine.Four);
            _color = EColor.Black;
            _board = BoardBuilder.New().Build();
        }

        public static QueenBuilder New()
        {
            return new QueenBuilder();
        }

        public override Queen Build()
        {
            return new Queen(_position, _color, _board);
        }
    }
}
