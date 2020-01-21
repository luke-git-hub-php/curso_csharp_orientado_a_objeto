
using System.Collections.Generic;

namespace WebUI.Models
{
    public class CustomerRequestData
    {
        public bool Success { get; set; }
        public IEnumerable<CustomerModel> Data { get; set; }
        public string Message { get; set; }

        public CustomerRequestData()
        {

        }

        public CustomerRequestData(IEnumerable<CustomerModel> data)
        {
            Success = true;
            Data = data;
        }

        public CustomerRequestData(string message)
        {
            Success = false;
            Message = message;
        }
    }
}