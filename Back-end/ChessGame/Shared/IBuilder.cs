namespace ChessGame.Domain.Shared
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
