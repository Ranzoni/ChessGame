using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Shared;

namespace ChessGame.Domain.Builder
{
    public class RookBuilder : PieceBuilder<Rook>
    {
        public RookBuilder()
        {
            _position = new Position(EColumn.A, ELine.One);
            _color = EColor.White;
            _board = BoardBuilder.New().Build();
        }

        public static RookBuilder New()
        {
            return new RookBuilder();
        }

        public override Rook Build()
        {
            return new Rook(_position, _color, _board);
        }
    }
}
