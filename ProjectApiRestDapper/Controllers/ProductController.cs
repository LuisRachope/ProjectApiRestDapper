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

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());

        // GET api/<ProductController>/5

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest($"O Id: {id} não está correto.");
            }

            Product obj = await _repository.GetByIdAsync(id);

            if (obj is null)
            {
                return BadRequest($"O Id: {id} não existe na base de dados.");
            }

            return Ok(await _repository.GetByIdAsync(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            if (product is null)
            {
                return BadRequest($"Produto: {product.Name} não foi preenchido corretamente.");
            }

            await _repository.CreateAsync(product);

            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, [FromBody] Product product)
        {
            if (product is null)
            {
                return BadRequest($"Produto: {product.Name} não foi preenchido corretamente.");
            }

            Product obj = new Product(id, product.Name, product.Price, product.Quantity);

            await _repository.UpdateAsync(obj);

            return Ok(obj);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAsync(int id)
        {
            Product obj = await _repository.GetByIdAsync(id);

            if (obj is null)
            {
                return BadRequest($"O Id: {id} não existe na base de dados.");
            }

            await _repository.DeleteAsync(id);

            return Ok(id);
        }
    }
}