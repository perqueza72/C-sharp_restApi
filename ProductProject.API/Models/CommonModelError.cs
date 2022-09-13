namespace ProductProject.API.Models
{
    public static class CommonModelError
    {
        public static string MustBeNotNull(string objName) => string.Format("{0} must not be null", objName);
        public static string SelectInernally(string field) => string.Format("{0} is selected internally", field);
        public static string MustBePositive(string field) => string.Format("{0} must be positive", field);
        public static string InvalidField(string field) => string.Format("{0} is invalid", field);
        public static string NotDefined(string field) => string.Format("{0} is not defined.", field);
    }
}
