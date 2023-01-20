using Domain.Dtos;
using Domain.Entities;
using Infrastructre.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetProduct")]
    public List<ProductDto> Get()
    {
        return _productService.GetProducts();
    }
    

    [HttpGet("GetById")]
    public ProductDto GetById(int id) => _productService.GetProductById(id);
    [HttpGet("GetProductsByName")]
    public List<ProductDto> GetCustomersByName(string name)
    {
        return _productService.GetProductByName(name);
    }

    [HttpPost("Add")]
    public ProductDto AddProduct([FromBody] ProductDto productDto)
    {
        return _productService.AddProducts(productDto);
    }

    [HttpPut("Update")]
    public ProductDto Put([FromBody] ProductDto productDto) => _productService.Update(productDto);

    [HttpDelete("Delete")]
    public bool Delete(int id) => _productService.Delete(id);
}
