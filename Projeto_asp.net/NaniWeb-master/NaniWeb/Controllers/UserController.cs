using System;
using Microsoft.AspNetCore.Mvc;

namespace NaniWeb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult YourProfile()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            throw new NotImplementedException();
        }

        public IActionResult EditUser()
        {
            throw new NotImplementedException();
        }

        public IActionResult UserList()
        {
            throw new NotImplementedException();
        }
    }
}