﻿using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Domain.Game
{
    public class Board
    {
        private readonly IList<Piece> _pieces;
        private readonly IList<Piece> _deadPieces;

        public IReadOnlyCollection<Piece> Pieces { get { return _pieces.ToArray(); } }
        public IReadOnlyCollection<Piece> DeadPieces { get { return _deadPieces.ToArray(); } }

        public Board()
        {
            _pieces = new List<Piece>();
            _deadPieces = new List<Piece>();
        }

        public void AddPiece(Piece piece)
        {
            if (piece == null)
                return;

            if (_pieces.Any(p => p.Position.Equals(piece.Position) && p.Color == piece.Color))
                return;

            _deadPieces.Remove(piece);
            _pieces.Add(piece);
        }

        public void KillPiece(Piece piece)
        {
            if (piece == null)
                return;

            if (_pieces.Any(p => p.Position.Equals(piece.Position) && p.Color == piece.Color))
            {
                _pieces.Remove(piece);
                _deadPieces.Add(piece);
            }
        }

        public void ClearBoard()
        {
            _pieces.Clear();
            _deadPieces.Clear();
        }

        public Piece GetPieceFromPosition(Position positionPiece)
        {
            return Pieces.Where(p => p.Position.Equals(positionPiece)).FirstOrDefault();
        }
    }
}
