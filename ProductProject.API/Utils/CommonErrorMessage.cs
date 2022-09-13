namespace ProductProject.API.Utils
{
    public static class CommonErrorMessage<T>
    {
        public static string ObjExist = string.Format("Object {0} already exist.", typeof(T));
        public static string ObjNotExist = string.Format("Object {0} does not exist.", typeof(T));
        public static string IdRequestDiffFromObjId = "Request ID is different from object ID";
    }
}
