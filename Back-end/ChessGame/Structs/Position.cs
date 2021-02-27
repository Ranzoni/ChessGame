using ChessGame.Domain.Enums;

namespace ChessGame.Domain.Structs
{
    public struct Position
    {
        private readonly EColumn _column;
        private readonly ELine _line;

        public Position(EColumn column, ELine line)
        {
            _column = column;
            _line = line;
        }

        public bool Equals(Position position)
        {
            return _line == position._line && _column == position._column;
        }

        public bool LineLowerOrEquals(Position position)
        {
            return _line <= position._line;
        }

        public bool LineGreaterOrEquals(Position position)
        {
            return _line >= position._line;
        }

        public int DifferenceLine(Position position)
        {
            return _line - position._line;
        }

        public int DifferenceColumn(Position position)
        {
            return _column - position._column;
        }
    }
}
