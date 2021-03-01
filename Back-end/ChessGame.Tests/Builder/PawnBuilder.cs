using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Tests.Shared;

namespace ChessGame.Tests.Builder
{
    public class PawnBuilder : PieceBuilder<Pawn>
    {
        public PawnBuilder()
        {
            Position = new Position(EColumn.B, ELine.Two);
            Color = EColor.White;
            Board = BoardBuilder.New().Build();
        }

        public static PawnBuilder New()
        {
            return new PawnBuilder();
        }

        public override Pawn Build()
        {
            return new Pawn(Position, Color, Board);
        }
    }
}
