namespace ProductProject.API.Models.ProductModel
{
    public interface IModelValidator<T>
    {
        bool IsValidModel(T obj, out string err);
    }
}