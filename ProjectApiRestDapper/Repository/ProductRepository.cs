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
        public Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product, int id)
        {
            throw new NotImplementedException();
        }
    }
}
