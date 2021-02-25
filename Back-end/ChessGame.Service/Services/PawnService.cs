using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Structs;
using ChessGame.Service.Shared;
using System.Linq;

namespace ChessGame.Service.Services
{
    public class PawnService : PieceService
    {
        public PawnService(Pawn pawn) : base (pawn)
        {
        }

        protected override bool ValidMove(Position newPosition, Board board)
        {
            if (!base.ValidMove(newPosition, board))
                return false;

            if (_piece.Color == EColor.White && newPosition.DifferenceLine(_piece.Position) == 1 && newPosition.DifferenceColumn(_piece.Position) == 1)
                if (board.Pieces.Any(p => p.Color != _piece.Color && p.Position.Equals(newPosition)))
                    return true;
                else
                    return false;

            if (_piece.Color == EColor.Black && newPosition.DifferenceLine(_piece.Position) == -1 && newPosition.DifferenceColumn(_piece.Position) == -1)
                if (board.Pieces.Any(p => p.Color != _piece.Color && p.Position.Equals(newPosition)))
                    return true;
                else
                    return false;

            if (newPosition.DifferenceColumn(_piece.Position) != 0)
                return false;

            if (_piece.Color == EColor.White && newPosition.DifferenceLine(_piece.Position) != 1)
                return false;

            if (_piece.Color == EColor.Black && newPosition.DifferenceLine(_piece.Position) != -1)
                return false;

            return true;
        }
    }
}
