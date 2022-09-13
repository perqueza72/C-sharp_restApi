namespace ProductProject.API.Utils
{
    public interface IRepositoryError
    {
        string Field { get; }
        string Message { get; }
        string Type { get; }
    }
}