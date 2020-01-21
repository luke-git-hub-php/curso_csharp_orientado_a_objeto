using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var customerServices = new CustomerServices();
            try
            {
                var requestData = await customerServices.GetCustomers();
                return View(requestData.Data);
            }
            catch (Exception e)
            {
                return View("Error", new Error(e.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(Index));
            }

            var customerServices = new CustomerServices();
            try
            {
                var requestData = await customerServices.GetCustomerById(id.Value);
                return View(requestData.Data.First());
            }
            catch (Exception e)
            {
                return View("Error", new Error(e.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(Index));
            }

            var customerServices = new CustomerServices();
            try
            {
                var requestData = await customerServices.GetCustomerById(id.Value);
                return View(requestData.Data.First());
            }
            catch (Exception e)
            {
                return View("Error", new Error(e.Message));
            }
        }

    }
}