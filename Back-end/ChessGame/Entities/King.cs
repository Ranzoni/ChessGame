using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class King : Piece
    {
        private readonly Dictionary<Rook, Position> _infoRookToCasttling = new Dictionary<Rook, Position>();

        public King(Position position, EColor color, Board board) : base(position, color, board)
        {
        }

        public override bool Move(Position newPosition)
        {        
            if (!SpecialMove(newPosition) && !ValidMove(newPosition))
                return false;

            if (_infoRookToCasttling.Count > 0)
            {
                var rookToCastling = _infoRookToCasttling.Keys.FirstOrDefault();
                var newPositionRook = _infoRookToCasttling[rookToCastling];
                rookToCastling.Move(newPositionRook);
            }

            QuantityMove++;
            Position = newPosition;
            return true;
        }

        protected override bool SpecialMove(Position newPosition)
        {
            _infoRookToCasttling.Clear();
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
                if (newPosition.DifferenceColumn(Position) > 0)
                {
                    var rookToCastling = _board.Pieces.Where(p => p is Rook && p.QuantityMove == 0 && p.Position.DifferenceColumn(newPosition) > 0).Select(p => (Rook)p).FirstOrDefault();
                    if (rookToCastling != null)
                    {
                        _infoRookToCasttling.Add(rookToCastling, new Position(EColumn.F, rookToCastling.Position.Line));
                        return true;
                    }
                }
                else
                {
                    var rookToCastling = _board.Pieces.Where(p => p is Rook && p.QuantityMove == 0 && p.Position.DifferenceColumn(newPosition) < 0).Select(p => (Rook)p).FirstOrDefault();
                    if (rookToCastling != null)
                    {
                        _infoRookToCasttling.Add(rookToCastling, new Position(EColumn.D, rookToCastling.Position.Line));
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
                if (newPosition.DifferenceColumn(Position) < 0 && pieceOnWay.Position.DifferenceColumn(Position) < 0)
                    return true;

                if (newPosition.DifferenceColumn(Position) > 0 && pieceOnWay.Position.DifferenceColumn(Position) > 0)
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
