using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerBUS
    {
        private CustomerDAO CustomerDAO { get; set; }

        public CustomerBUS()
        {
            CustomerDAO = new CustomerDAO();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return CustomerDAO.GetCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return CustomerDAO.GetCustomerById(id);
        }
    }
}
