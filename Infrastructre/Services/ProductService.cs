using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructre.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public List<ProductDto> GetProducts()
        {
            return _context.Products.Select(x => new ProductDto(x.Id, x.Name, x.Price)).ToList();
        } 
            public ProductDto GetProductById(int id)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id.Equals(id));
                if (product == null) return null;
                var productDto = new ProductDto
                {
                    Id= product.Id,
                    Name = product.Name,
                    Price = product.Price, 
                };
                return productDto;
            }
            public List<ProductDto> GetProductByName(string name)
            {
                var products = _context.Products.Where(x => x.Name == name).ToList();
                if (products.Count == 0) return new List<ProductDto>();
                var productsDto = products.Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,

                   
                }).ToList();
                return productsDto;
            }
            public ProductDto AddProducts(ProductDto productDto)
            {
                var product = new Product(productDto.Id, productDto.Name, productDto.Price);
                _context.Products.Add(product);
                var x = _context.SaveChanges();
                if (x == 0) return null;
                return productDto;
            }

            public ProductDto Update(ProductDto productDto)
            {
                var product = _context.Products.Find(productDto.Id);
                if (product == null) return null;
            product.Id = productDto.Id;
            product.Name = productDto.Name;
            product.Price = productDto.Price;  
                var x = _context.SaveChanges();
                if (x == 0) return null;
                return productDto;
            }
            public bool Delete(int id)
            {
                var product = _context.Products.Find(id);
                if (product == null) return false;
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
        }
    }
