using Microsoft.AspNetCore.Mvc;
using ProjectApiRestDapper.Context;
using ProjectApiRestDapper.Model;
using ProjectApiRestDapper.Model.Form;
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
    public class CustomerController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CustomerController(DbContext context, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Customer> list = await _customerRepository.GetAllAsync();

            if (list is null)
            {
                BadRequest("Não existem clientes cadastrados na base de dados");
            }

            return Ok(list);
        }


        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"O Id: {id} não está correto.");
            }

            Customer cr = await _customerRepository.GetByIdAsync(id);

            if (cr is null)
            {
                return BadRequest($"O Id: {id} não existe na base de dados.");
            }

            return Ok(cr);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Create(CustomerModelForm model)
        {
            Product p = await _productRepository.GetByIdAsync(model.ProductId);

            if (p is null)
            {
                return BadRequest($"O Produto Id: {model.ProductId} não existe na base de dados.");
            }

            Customer cr = new Customer(model.CustomerName, model.CustomerEmail, p);

            await _customerRepository.CreateAsync(cr);

            return Ok(cr);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
