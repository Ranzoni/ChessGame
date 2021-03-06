using ChessGame.Domain.Enums;

namespace ChessGame.Domain.Entities
{
    public class Player
    {
        public string Name { get; private set; }
        public EColor Color { get; private set; }

        public Player(string name, EColor color)
        {
            Name = name;
            Color = color;
        }
    }
}
