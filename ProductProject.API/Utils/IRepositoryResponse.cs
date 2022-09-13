namespace ProductProject.API.Utils
{
    public interface IRepositoryResponse
    {
        IRepositoryError Error { get; set; }
        bool HasError { get; }
        bool Success { get; }
        object Message { get; }
    }
}