using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProjectApiRestDapper.Context;
using ProjectApiRestDapper.Model;
using ProjectApiRestDapper.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApiRestDapper.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContext _context;
        private readonly DynamicParameters _param;

        public CustomerRepository(DbContext context)
        {
            _context = context;
            _param = new DynamicParameters();
        }

        private static Customer mapPropriedades(Customer customer, Product product)
        {
            customer.Products = product;
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync() =>
            await _context.Connection.QueryAsync<Customer, Product, Customer>(Queries.CustomerQueries.LISTAR, map: mapPropriedades, splitOn: "Id");


        public async Task<Customer> GetByIdAsync(int id)
        {
            _param.Add("@Id", id);

            return _context.Connection.Query<Customer, Product, Customer>(Queries.CustomerQueries.BUSCAR,
                map: mapPropriedades, splitOn: "Id", param: _param).FirstOrDefault();
        }


        public async Task CreateAsync(Customer customer)
        {

            _param.Add("@Name");
            _param.Add("@Email");
            _param.Add("@ProductId");

            await _context.Connection.ExecuteScalarAsync(Queries.CustomerQueries.CRIAR, _param);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateAsync(Customer user, int id)
        {
            throw new NotImplementedException();
        }
    }
}
