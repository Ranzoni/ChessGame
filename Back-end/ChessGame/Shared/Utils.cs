using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Structs;

namespace ChessGame.Domain.Shared
{
    public static class Utils
    {
        public static Piece GetBuildedPieceFromAnother(Piece piece, Position position, EColor color, Board board)
        {
            if (piece is Rook)
                return new Rook(position, color, board);
            else if (piece is Knight)
                return new Knight(position, color, board);
            else if (piece is Bishop)
                return new Bishop(position, color, board);
            else if (piece is Queen)
                return new Queen(position, color, board);
            else if (piece is King)
                return new King(position, color, board);

            return null;
        }
    }
}
