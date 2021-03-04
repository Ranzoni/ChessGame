using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class King : Piece
    {
        public King(Position position, EColor color, Board board) : base(position, color, board)
        {
        }

        protected override bool SpecialMove(Position newPosition)
        {
            return IsCastling(newPosition);
        }

        protected override bool ValidMove(Position newPosition)
        {
            if (!base.ValidMove(newPosition))
                    return false;

            if (Math.Abs(Position.DifferenceColumn(newPosition)) > 1 || Math.Abs(Position.DifferenceLine(newPosition)) > 1)
                return false;

            return true;
        }

        private bool IsCastling(Position newPosition)
        {
            if (QuantityMove > 0)
                return false;

            if (Position.EqualsLine(newPosition) && Math.Abs(Position.DifferenceColumn(newPosition)) == 2 && !PositionWillJumpPiece(newPosition))
            {
                Piece rookToCastling;
                if (newPosition.DifferenceColumn(Position) > 0)
                {
                    rookToCastling = _board.Pieces.Where(p => p is Rook && p.QuantityMove == 0 && p.Position.DifferenceColumn(newPosition) > 0).FirstOrDefault();
                    if (rookToCastling != null)
                    {
                        var newPositionRook = new Position(EColumn.F, rookToCastling.Position.Line);
                        rookToCastling.Move(newPositionRook);
                        return true;
                    }
                }
                else
                {
                    rookToCastling = _board.Pieces.Where(p => p is Rook && p.QuantityMove == 0 && p.Position.DifferenceColumn(newPosition) < 0).FirstOrDefault();
                    if (rookToCastling != null)
                    {
                        var newPositionRook = new Position(EColumn.D, rookToCastling.Position.Line);
                        rookToCastling.Move(newPositionRook);
                        return true;
                    }
                }
            }

            return false;
        }

        protected override bool PositionWillJumpPiece(Position newPosition)
        {
            var piecesOnWay = _board.Pieces.Where(p => p.Position.EqualsLine(Position) && p != this && !(p is Rook));
            foreach (var pieceOnWay in piecesOnWay)
            {
                if (newPosition.DifferenceColumn(Position) < 0 && pieceOnWay.Position.DifferenceColumn(Position) < 0 && newPosition.DifferenceColumn(pieceOnWay.Position) <= 0)
                    return true;

                if (newPosition.DifferenceColumn(Position) > 0 && pieceOnWay.Position.DifferenceColumn(Position) > 0 && newPosition.DifferenceColumn(pieceOnWay.Position) >= 0)
                    return true;
            }

            return false;
        }
    }
}
