using ProjectApiRestDapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApiRestDapper.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer, int id);
        Task DeleteAsync(int id);
    }
}
