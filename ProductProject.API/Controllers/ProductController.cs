using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ProductProject.API.Models.ProductModel;
using System.Linq;
using ProductProject.API.Utils;
using ProductProject.API.Repositories;

namespace ProductProject.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, 
            IMapper mapper)
        {
            _productRepository = productRepository ?? 
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetProducts(int? id = null, string description = null)
        {
            if (id != null && description != null)
                return BadRequest("Send product id or description but not both");
            if (id != null)
                return GetProduct((int)id);
            if (description != null)
                return GetProduct(description);
            
            
            var productEntities = _productRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<Entities.Product>>(productEntities));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (product.Id != null && product.Id != id)
                return BadRequest(CommonErrorMessage<Product>.IdRequestDiffFromObjId);
            
            product.Id = id;
            var productDB = _mapper.Map<Entities.Product>(product);

            var response = _productRepository.Update(id, productDB);
            if (response.HasError)
                return BadRequest(response.Error.Message);

            return Ok(_mapper.Map<Entities.Product>(response.Message));
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] Product product)
        {
            if (!ProductModelValidator.Instance.IsValidModel(product, out var err))
                return BadRequest(err);

            var productDB = _mapper.Map<Entities.Product>(product);
            var response = _productRepository.Insert(productDB);

            if(response.HasError) 
                return BadRequest(response.Error);

            product.Id = productDB.Id;
            return CreatedAtRoute(this.RouteData, product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var response = _productRepository.Delete(id);
            if(response.HasError)
                return NotFound(response.Error.Message);
            return NoContent();
        }
    private IActionResult GetProduct(int id)
    {
        var product = _productRepository.Get(id);

        if (product == null)
            return NotFound();

        return Ok(_mapper.Map<Entities.Product>(product));
    }

    private IActionResult GetProduct(string description)
    {
        var products = _productRepository.Get(description);

       if (products.FirstOrDefault() == null)
            return NotFound();

        return Ok(_mapper.Map<IEnumerable<Entities.Product>>(products));
    }

    }

}
