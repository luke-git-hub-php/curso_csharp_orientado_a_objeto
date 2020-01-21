using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    internal class CustomerServices
    {
        private readonly string baseUrl = ConfigurationManager.AppSettings["apiBaseUrl"] + "Customers/";

        public async Task<CustomerRequestData> GetCustomers()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(baseUrl))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception("Bad request.");
                        }

                        var responseString = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CustomerRequestData>(responseString);
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CustomerRequestData> GetCustomerById(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = baseUrl + id;
                    using (var response = await client.GetAsync(url))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception("Bad request.");
                        }

                        var responseString = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<CustomerRequestData>(responseString);
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}