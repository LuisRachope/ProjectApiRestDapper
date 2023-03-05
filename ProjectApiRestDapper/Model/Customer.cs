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
        public ICollection<Product> Products { get; set; }

        public Customer(int id, string name, string email, ICollection<Product> products)
        {
            Id = id;
            Name = name;
            Email = email;
            Products = products;
        }
    }
}
