using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProjectApiRestDapper.Context;
using ProjectApiRestDapper.Model;
using ProjectApiRestDapper.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectApiRestDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly IProductRepository _repository;

        public ProductController(DbContext context, IProductRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        private ICollection<Product> _ListProducts = new List<Product>
        {
            new Product(1, "Tv", 874.85, 2),
            new Product(2, "PlayStation 5", 489.99, 8)
        };

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());

        // GET api/<ProductController>/5

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _ListProducts.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public Product Create([FromBody] Product product)
        {
            _ListProducts.Add(product);
            return product;
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public Product Update([FromBody] Product product, int id)
        {
            Product obj = GetById(id);
            _ListProducts.Add(new Product(
                   id,
                   obj.Name,
                   obj.Price,
                   obj.Quantity
                ));
            return obj;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            Product obj = GetById(id);
            _ListProducts.Remove(obj);
            return id;
        }
    }
}