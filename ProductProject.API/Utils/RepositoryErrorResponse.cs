namespace ProductProject.API.Utils
{
    public class RepositoryErrorResponse : RepositoryResponse
    {
        public RepositoryErrorResponse(RepositoryError error) : base(null)
        {
            Error = error;
            Success = false;
            HasError = true;
        }
    }
}
