using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class Bishop : Piece
    {
        public Bishop(Position position, EColor color, Board board) : base(position, color, board)
        {
        }

        protected override bool ValidMove(Position newPosition)
        {
            if (!base.ValidMove(newPosition))
                return false;

            if (Math.Abs(Position.DifferenceColumn(newPosition)) != Math.Abs(Position.DifferenceLine(newPosition)))
                return false;

            if (PositionWillJumpPiece(newPosition))
                return false;

            return true;
        }

        protected override bool PositionWillJumpPiece(Position newPosition)
        {
            var piecesOnWay = _board.Pieces
                .Where(p =>
                    Math.Abs(Position.DifferenceColumn(p.Position)) == Math.Abs(Position.DifferenceLine(p.Position))
                    && Math.Abs(p.Position.DifferenceColumn(newPosition)) == Math.Abs(p.Position.DifferenceLine(newPosition))
                    && p != this);
            foreach (var pieceOnWay in piecesOnWay)
            {
                if (Position.DifferenceLine(newPosition) > 0)
                {
                    if (Position.DifferenceLine(pieceOnWay.Position) > 0 && newPosition.DifferenceLine(pieceOnWay.Position) < 0)
                        return true;
                }
                else
                {
                    if (Position.DifferenceLine(pieceOnWay.Position) < 0 && newPosition.DifferenceLine(pieceOnWay.Position) > 0)
                        return true;
                }
            }

            return false;
        }
    }
}
