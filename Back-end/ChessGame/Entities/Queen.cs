using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class Queen : Piece
    {
        public Queen(Position position, EColor color, Board board) : base(position, color, board)
        {
        }

        protected override bool ValidMove(Position newPosition)
        {
            if (!base.ValidMove(newPosition))
                return false;

            if (MovementDiagonally(newPosition))
            {
                if (PositionWillJumpPieceOnMovementDiagonally(newPosition))
                    return false;
            }
            else if (MovementVerticalOrHorizontal(newPosition))
            {
                if (PositionWillJumpPieceOnMovementVerOrtHor(newPosition))
                    return false;
            }
            else
                return false;

            return true;
        }

        private bool PositionWillJumpPieceOnMovementDiagonally(Position newPosition)
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

        private bool PositionWillJumpPieceOnMovementVerOrtHor(Position newPosition)
        {
            if (Position.EqualsLine(newPosition))
            {
                var piecesOnWay = _board.Pieces.Where(p => p.Position.EqualsLine(newPosition) && p != this);
                foreach (var pieceOnWay in piecesOnWay)
                {
                    if (Position.DifferenceColumn(pieceOnWay.Position) > 0)
                    {
                        if (pieceOnWay.Position.DifferenceColumn(newPosition) > 0)
                            return true;
                    }
                    else
                        if (pieceOnWay.Position.DifferenceColumn(newPosition) < 0)
                        return true;
                }
            }
            else
            {
                var piecesOnWay = _board.Pieces.Where(p => p.Position.EqualsColumn(newPosition) && p != this);
                foreach (var pieceOnWay in piecesOnWay)
                {
                    if (Position.DifferenceLine(pieceOnWay.Position) > 0)
                    {
                        if (pieceOnWay.Position.DifferenceLine(newPosition) > 0)
                            return true;
                    }
                    else
                        if (pieceOnWay.Position.DifferenceLine(newPosition) < 0)
                        return true;
                }
            }

            return false;
        }

        private bool MovementDiagonally(Position newPosition)
        {
            return Math.Abs(Position.DifferenceColumn(newPosition)) == Math.Abs(Position.DifferenceLine(newPosition));
        }

        private bool MovementVerticalOrHorizontal(Position newPosition)
        {
            return Position.EqualsColumn(newPosition) || Position.EqualsLine(newPosition);
        }
    }
}
