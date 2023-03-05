using Dapper;
using ProjectApiRestDapper.Context;
using ProjectApiRestDapper.Model;
using ProjectApiRestDapper.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApiRestDapper.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;
        private readonly DynamicParameters _param;

        public ProductRepository(DbContext context)
        {
            _context = context;
            _param = new DynamicParameters();
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.Connection.QueryAsync<Product>(Queries.ProductQueries.LISTAR);

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product, int id)
        {
            throw new NotImplementedException();
        }
    }
}
