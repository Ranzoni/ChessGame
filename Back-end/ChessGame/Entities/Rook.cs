using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class Rook : Piece
    {
        public Rook(Position position, EColor color, Board board) : base(position, color, board)
        {
        }

        protected override bool ValidMove(Position newPosition)
        {
            if (!base.ValidMove(newPosition))
                return false;

            if (Position.NotEquals(newPosition))
                return false;

            if (PositionWillJumpPiece(newPosition))
                return false;

            return true;
        }

        protected override bool PositionWillJumpPiece(Position newPosition)
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

        public override string ToString()
        {
            return "T";
        }
    }
}
