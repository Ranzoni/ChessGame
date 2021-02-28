﻿using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;
using System;
using System.Linq;

namespace ChessGame.Domain.Entities
{
    public class Pawn : Piece
    {
        public int QuantityMove { get; private set; }

        public Pawn(Position position, EColor color, Board board) : base(position, color, board)
        {
        }

        public override bool Move(Position newPosition)
        {
            var moved = base.Move(newPosition);
            if (moved)
                QuantityMove++;

            return moved;
        }

        protected override bool SpecialMove(Position newPosition)
        {
            if (_board.Pieces.Any(p => p.Position.Equals(newPosition)))
                return false;

            if (QuantityMove == 0 && Position.EqualsColumn(newPosition) && Math.Abs(Position.DifferenceLine(newPosition)) == 2 && !PositionWillJumpPiece(newPosition))
                return true;

            //Implementar movimento En Passant

            return false;
        }

        protected override bool ValidMove(Position newPosition)
        {
            if (!base.ValidMove(newPosition))
                return false;

            if (Color == EColor.White && newPosition.DifferenceLine(Position) == 1 && Math.Abs(newPosition.DifferenceColumn(Position)) == 1)
                if (_board.Pieces.Any(p => p.Color != Color && p.Position.Equals(newPosition)))
                    return true;
                else
                    return false;

            if (Color == EColor.Black && newPosition.DifferenceLine(Position) == -1 && Math.Abs(newPosition.DifferenceColumn(Position)) == 1)
                if (_board.Pieces.Any(p => p.Color != Color && p.Position.Equals(newPosition)))
                    return true;
                else
                    return false;

            if (_board.Pieces.Any(p => p.Position.Equals(newPosition)))
                return false;

            if (newPosition.DifferenceColumn(Position) != 0)
                return false;

            if (Color == EColor.White && newPosition.DifferenceLine(Position) != 1)
                return false;

            if (Color == EColor.Black && newPosition.DifferenceLine(Position) != -1)
                return false;

            return true;
        }

        private bool PositionWillJumpPiece(Position position)
        {
            var piecesOnWay = _board.Pieces.Where(p => p.Position.EqualsColumn(Position) && p != this);
            foreach (var pieceOnWay in piecesOnWay)
            {
                if (Color == EColor.White && position.DifferenceLine(pieceOnWay.Position) >= 0)
                    return true;

                if (Color == EColor.Black && position.DifferenceLine(pieceOnWay.Position) <= 0)
                    return true;
            }

            return false;
        }
    }
}
