using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CustomerDAO
    {
        private ICollection<Customer> Customers { get; set; }

        public CustomerDAO()
        {
            Customers = new List<Customer>()
            {
                new Customer() {
                    Id = 1, Name = "Luke", BirthDate = DateTime.Now, Email = "luke@gmail.com"
                },
                new Customer() {
                    Id = 2, Name = "Michael", BirthDate = DateTime.Now, Email = "michael.@gmail.com" 
                },
            };
        }
        public Customer GetCustomerById(int id)
        {
            return Customers.FirstOrDefault(customer => customer.Id == id);
        }

        public ICollection<Customer> GetCustomers()
        {
            return Customers;
        }
    }
}
