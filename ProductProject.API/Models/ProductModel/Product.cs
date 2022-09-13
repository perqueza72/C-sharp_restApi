using System;

namespace ProductProject.API.Models.ProductModel
{
    public class Product
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public ProductType? ProductType { get; set; }
        public decimal Value { get; set; }
        public DateTime? Date { get; set; }
        public ProductState State { get; set; }
    }
}