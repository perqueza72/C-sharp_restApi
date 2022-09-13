using Microsoft.AspNetCore.Mvc;
using System;

namespace ProductProject.API.Models.ProductModel
{
    public sealed class ProductModelValidator : IModelValidator<Product>
    {
        private readonly static ProductModelValidator _instance = new ProductModelValidator();
        private ProductModelValidator() {}

        public static ProductModelValidator Instance
        {
            get
            {
                return _instance;
            }
        }

        public bool IsValidModel(Product product, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (product == null)
            {
                errorMessage = CommonModelError.MustBeNotNull("Product");
                return false;
            }
            if(product.Id != null)
            {
                errorMessage = CommonModelError.SelectInernally("ID");
                return false;
            }
            if (product.Value <= 0)
            {
                errorMessage = CommonModelError.MustBePositive("Value");
                return false;
            }
            if (product.Date == null)
            {
                errorMessage = CommonModelError.InvalidField("Date");
                return false;
            }
            if (product.ProductType == null)
            {
                errorMessage = CommonModelError.NotDefined("ProductType");
                return false;
            }
            if(!Enum.IsDefined(typeof(ProductType), product.ProductType)){
                errorMessage = CommonModelError.InvalidField("ProductType");
                return false;
            }

            return true;
        }
    }
}
