namespace ProductProject.API.Utils
{
    public class RepositoryResponse : IRepositoryResponse
    {
        public object Message { get; }
        public RepositoryResponse(object message = null)
        {
            Message = message;
        }

        private bool _success;
        public bool Success
        {
            get
            {
                return _success;
            }
            protected set
            {
                _success = _error == null;
            }
        }
        private bool _hasError;
        public bool HasError
        {
            get
            {
                return _hasError;
            }
            protected set
            {
                _hasError = !_success;
            }
        }
        private IRepositoryError _error = null;
        public IRepositoryError Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
            }
        }
    }
}
