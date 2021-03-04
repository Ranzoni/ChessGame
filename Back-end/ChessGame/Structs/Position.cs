using ChessGame.Domain.Enums;

namespace ChessGame.Domain.Structs
{
    public struct Position
    {
        public readonly EColumn Column;
        public readonly ELine Line;

        public Position(EColumn column, ELine line)
        {
            Column = column;
            Line = line;
        }

        public bool Equals(Position position)
        {
            return Line == position.Line && Column == position.Column;
        }

        public bool EqualsColumn(Position position)
        {
            return Column == position.Column;
        }

        public bool EqualsLine(Position position)
        {
            return Line == position.Line;
        }

        public int DifferenceLine(Position position)
        {
            return Line - position.Line;
        }

        public int DifferenceColumn(Position position)
        {
            return Column - position.Column;
        }

        public bool NotEquals(Position position)
        {
            return Column != position.Column && Line != position.Line;
        }
    }
}
