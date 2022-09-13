using ProductProject.API.Models.ProductModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductProject.API.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        [DefaultValue(ProductState.ACTIVE)]
        public ProductState State { get; set; }
    }
}
