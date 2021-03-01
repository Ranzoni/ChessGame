using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Tests.Shared;

namespace ChessGame.Tests.Builder
{
    public class RookBuilder : PieceBuilder<Rook>
    {
        public RookBuilder()
        {
            Position = new Position(EColumn.A, ELine.One);
            Color = EColor.White;
            Board = BoardBuilder.New().Build();
        }

        public static RookBuilder New()
        {
            return new RookBuilder();
        }

        public override Rook Build()
        {
            return new Rook(Position, Color, Board);
        }
    }
}
