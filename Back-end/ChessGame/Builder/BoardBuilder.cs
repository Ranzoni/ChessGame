using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using System.Collections.Generic;

namespace ChessGame.Domain.Builder
{
    public class BoardBuilder : IBuilder<Board>
    {
        private readonly List<Piece> _pieces = new List<Piece>();

        public static BoardBuilder New()
        {
            return new BoardBuilder();
        }

        public BoardBuilder WithPiece(Piece piece)
        {
            _pieces.Add(piece);
            return this;
        }

        public Board Build()
        {
            var board = new Board();
            foreach (var piece in _pieces)
                board.AddPiece(piece);

            return board;
        }
    }
}
