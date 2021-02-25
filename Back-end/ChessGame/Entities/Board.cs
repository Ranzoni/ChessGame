using ChessGame.Domain.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class Board
    {
        private readonly IList<Piece> _pieces;
        private readonly IList<Piece> _deadPieces;

        public IReadOnlyCollection<Piece> Pieces { get { return _pieces.ToArray(); } }
        public IReadOnlyCollection<Piece> DeadPieces { get { return _pieces.ToArray(); } }

        public Board()
        {
            _pieces = new List<Piece>();
            _deadPieces = new List<Piece>();
        }

        public void AddPiece(Piece piece)
        {
            _deadPieces.Remove(piece);
            _pieces.Add(piece);
        }

        public void RemovePiece(Piece piece)
        {
            _pieces.Remove(piece);
            _deadPieces.Add(piece);
        }
    }
}
