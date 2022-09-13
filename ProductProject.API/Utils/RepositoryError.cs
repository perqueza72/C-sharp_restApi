namespace ProductProject.API.Utils
{
    public class RepositoryError : IRepositoryError
    {
        public RepositoryError(string message = null, string field = null, string type = null)
        {
            Message = message;
            Field = field;
            Type = type;
        }

        public string Message { get; protected set; }
        public string Field { get; protected set; }
        public string Type { get; protected set; }
    }
}
