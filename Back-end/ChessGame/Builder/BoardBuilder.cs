using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;

namespace ChessGame.Domain.Builder
{
    public class BoardBuilder : IBuilder<Board>
    {
        public static BoardBuilder New()
        {
            return new BoardBuilder();
        }

        public Board Build()
        {
            return new Board();
        }
    }
}
