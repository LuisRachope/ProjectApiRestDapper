﻿using ProjectApiRestDapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApiRestDapper.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer, int id);
        Task<bool> DeleteAsync(int id);
    }
}
