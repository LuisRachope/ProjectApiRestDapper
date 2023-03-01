using ProjectApiRestDapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApiRestDapper.Repository.Interfaces
{
    interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product, int id);
        Task<bool> DeleteAsync(int id);
    }
}
