using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class CustomerControllers : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            try
            {
                var customerBUS = new CustomerBUS();
                var customers = customerBUS.GetCustomers();
                return Json(new { Success = true, Data = customers });
            }
            catch (Exception e)
            {
                return Json(new { Success = false, e.Message });
            }
        }

        [HttpGet]
        public IHttpActionResult Details(int id)
        {
            try
            {
                var customerBUS = new CustomerBUS();
                var customer = customerBUS.GetCustomerById(id);

                return Json(new { Success = true, Data = new List<Customer>() { customer } });
            }
            catch (Exception e)
            {
                return Json(new { Success = false, e.Message });
            }
        }
    }
}
