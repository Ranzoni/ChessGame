using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Domain.Shared
{
    public abstract class Piece
    {
        protected readonly Board _board;
        private Position _lastPosition;

        public Position Position { get; protected set; }
        public EColor Color { get; private set; }
        public int QuantityMove { get; protected set; }

        public Piece(Position position, EColor color, Board board)
        {
            Position = position;
            Color = color;
            _board = board;
            _lastPosition = position;
        }

        public virtual bool Move(Position newPosition)
        {
            if (!SpecialMove(newPosition) && !ValidMove(newPosition))
                return false;

            QuantityMove++;
            _lastPosition = Position;
            Position = newPosition;
            return true;
        }

        public bool UndoMove()
        {
            QuantityMove--;
            Position = _lastPosition;
            return true;
        }

        protected virtual bool ValidMove(Position newPosition)
        {
            if (newPosition.Equals(Position))
                return false;

            if (_board.Pieces.Any(p => p.Color == Color && p.Position.Equals(newPosition)))
                return false;

            return true;
        }

        protected virtual bool SpecialMove(Position newPosition)
        {
            return false;
        }

        protected virtual bool PositionWillJumpPiece(Position newPosition)
        {
            return false;
        }

        public IEnumerable<Position> AvailableMovements()
        {
            var listAvaiblePosition = new List<Position>();
            foreach (var column in Enum.GetValues(typeof(EColumn)).Cast<EColumn>())
                foreach (var line in Enum.GetValues(typeof(ELine)).Cast<ELine>())
                {
                    var position = new Position(column, line);
                    var move = MoveIsValid(position);
                    if (move)
                        listAvaiblePosition.Add(position);
                }

            return listAvaiblePosition;
        }

        public bool MoveIsValid(Position position)
        {
            return SpecialMove(position) || ValidMove(position);
        }
    }
}
