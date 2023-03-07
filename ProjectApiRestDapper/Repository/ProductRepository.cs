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

        public async Task<Product> GetByIdAsync(int id) =>
            await _context.Connection.QueryFirstOrDefaultAsync<Product>(Queries.ProductQueries.OBTER, new { id });

        public async Task CreateAsync(Product product)
        {
            _param.Add("@Name", product.Name);
            _param.Add("@Price", product.Price);
            _param.Add("@Quantity", product.Quantity);

            await _context.Connection.ExecuteScalarAsync(Queries.ProductQueries.INSERIR, _param);
        }

        public async Task UpdateAsync(Product product)
        {
            _param.Add("@Id", product.Id);
            _param.Add("@Name", product.Name);
            _param.Add("@Price", product.Price);
            _param.Add("@Quantity", product.Quantity);

            await _context.Connection.ExecuteScalarAsync(Queries.ProductQueries.ATUALIZAR, _param);
        }

        public async Task DeleteAsync(int id) =>
            await _context.Connection.ExecuteAsync(Queries.ProductQueries.APAGAR, new { id });
    }
}
