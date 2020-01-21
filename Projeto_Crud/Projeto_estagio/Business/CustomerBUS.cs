using Entity;
using Repository;
using System.Collections.Generic;

namespace Business
{
    public class CustomerBUS
    {
        //Métado que instancia o objeto CustomerDAO
        public CustomerBUS()
        {
            CustomerDAO = new CustomerDAO();
        }
        //Coleção de Customer
        public IEnumerable<Customer> GetCustomers()
        {
            return CustomerDAO.GetCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return CustomerDAO.GetCustomerById(id);
        }
        private CustomerDAO CustomerDAO { get; set; }
    }
}
