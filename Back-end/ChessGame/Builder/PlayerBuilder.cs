using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;

namespace ChessGame.Domain.Builder
{
    public class PlayerBuilder : IBuilder<Player>
    {
        private string _name = "Jogador um";
        private EColor _color = EColor.White;

        public static PlayerBuilder New()
        {
            return new PlayerBuilder();
        }

        public PlayerBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public PlayerBuilder WithColor(EColor color)
        {
            _color = color;
            return this;
        }

        public Player Build()
        {
            return new Player(_name, _color);
        }
    }
}
