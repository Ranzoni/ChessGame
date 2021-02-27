using ChessGame.Domain.Entities;
using ChessGame.Domain.Shared;
using System.Collections.Generic;

namespace ChessGame.Tests.Builder
{
    public class BoardBuilder
    {
        private readonly List<Piece> _pieces = new List<Piece>();
        private readonly List<Piece> _deadPieces = new List<Piece>();

        public static BoardBuilder New()
        {
            return new BoardBuilder();
        }

        public BoardBuilder WithPiece(Piece piece)
        {
            _pieces.Add(piece);
            return this;
        }

        public BoardBuilder WithDeadPiece(Piece piece)
        {
            _deadPieces.Add(piece);
            return this;
        }

        public Board Build()
        {
            var board = new Board();
            foreach (var piece in _pieces)
                board.AddPiece(piece);
            foreach (var piece in _deadPieces)
            {
                board.AddPiece(piece);
                board.KillPiece(piece);
            }

            return board;
        }
    }
}
