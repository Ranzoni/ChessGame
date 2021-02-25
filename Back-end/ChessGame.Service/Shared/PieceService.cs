using ChessGame.Domain.Entities;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System.Linq;

namespace ChessGame.Service.Shared
{
    public class PieceService
    {
        protected readonly Piece _piece;

        public PieceService(Piece piece)
        {
            _piece = piece;
        }

        public bool Move(Position position, Board board)
        {
            if (!ValidMove(position, board))
                return false;

            _piece.Move(position);

            return true;
        }

        protected virtual bool ValidMove(Position position, Board board)
        {
            if (position.Equals(_piece.Position))
                return false;

            if (board.Pieces.Any(p => p.Color == _piece.Color && p.Position.Equals(position)))
                return false;

            return true;
        }
    }
}
