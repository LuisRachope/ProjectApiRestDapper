using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApiRestDapper.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Product Products { get; set; }

        public Customer()
        {
        }

        public Customer(int id, string name, string email, Product products)
        {
            Id = id;
            Name = name;
            Email = email;
            Products = products;
        }

        public Customer(string name, string email, Product products)
        {
            Name = name;
            Email = email;
            Products = products;
        }
    }
}
