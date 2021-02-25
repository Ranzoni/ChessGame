using ChessGame.Domain.Enums;
using ChessGame.Domain.Shared;
using ChessGame.Domain.Structs;

namespace ChessGame.Domain.Entities
{
    public class Pawn : Piece
    {
        public Pawn(Position position, EColor color) : base(position, color)
        {
        }
    }
}
