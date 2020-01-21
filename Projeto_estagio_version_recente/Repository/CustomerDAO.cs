using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerDAO
    {
        private ICollection<Customer> Customers { get; set; }

        public CustomerDAO()
        {
            Customers = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "Leanne Graham", BirthDate = DateTime.Now, Email = "Sincere@april.biz"},
                new Customer() {Id = 2, Name = "Ervin Howell", BirthDate = DateTime.Now, Email = "Shanna@melissa.tv"},
                new Customer() {Id = 3, Name = "Clementine Bauch", BirthDate = DateTime.Now, Email = "Nathan@yesenia.net"},
                new Customer() {Id = 4, Name = "Patricia Lebsack", BirthDate = DateTime.Now, Email = "Julianne.OConner@kory.org"},
            };
        }

        public ICollection<Customer> GetCustomers()
        {
            return Customers;
        }

        public Customer GetCustomerById(int id)
        {
            return Customers.FirstOrDefault(customer => customer.Id == id);
        }
    }
}
