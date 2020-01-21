using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using PastaWeb.Models;

namespace WebUI.Controllers
{
    public class CustomersController : Controller
    {
        private readonly string baseUrl = ConfigurationManager.AppSettings["apiBaseUrl"] + "Customers/";

        // GET: Customers
        [HttpGet]
        public ActionResult Index()
        {
            return View(new List<CustomerModel>());
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            using (var client = new HttpClient())
            {
                var url = baseUrl + id;
                using (var response = await client.GetAsync(url))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return View("Error", new Error(response.ReasonPhrase));
                    }

                    var responseJson = await response.Content.ReadAsStringAsync();
                    var requestData = JsonConvert.DeserializeObject<CustomerRequestData>(responseJson);
                    return View(requestData.Data.First());
                }
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetCustomers()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(baseUrl))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception(response.ReasonPhrase);
                        }

                        var responseJson = await response.Content.ReadAsStringAsync();
                        var requestData = JsonConvert.DeserializeObject<CustomerRequestData>(responseJson);
                        return Json(requestData, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new CustomerRequestData(e.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}