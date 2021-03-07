using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Game;

namespace ChessGame.Domain.Builder
{
    public class PawnBuilder : PieceBuilder<Pawn>
    {
        private Gameplay _gameplay = GameplayBuilder.New().Build();

        public PawnBuilder()
        {
            _position = new Position(EColumn.B, ELine.Two);
            _color = EColor.White;
            _board = BoardBuilder.New().Build();
        }

        public static PawnBuilder New()
        {
            return new PawnBuilder();
        }

        public PawnBuilder WithGameplay(Gameplay gameplay)
        {
            _gameplay = gameplay;
            return this;
        }

        public override Pawn Build()
        {
            return new Pawn(_position, _color, _board, _gameplay);
        }
    }
}
