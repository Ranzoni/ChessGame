using ChessGame.Domain.Enums;

namespace ChessGame.Domain.Structs
{
    public struct Position
    {
        private readonly ELine _line;
        private readonly EColumn _column;

        public Position(ELine line, EColumn column)
        {
            _line = line;
            _column = column;
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
