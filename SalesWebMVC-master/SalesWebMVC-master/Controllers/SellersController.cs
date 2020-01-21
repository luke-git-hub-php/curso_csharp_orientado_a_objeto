using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerServices;
        private DepartmentServices _departmentServices;

        public SellersController(SellerServices sellerServices, DepartmentServices departmentServices)
        {
            _sellerServices = sellerServices;
            _departmentServices = departmentServices;
        }

        // GET: Sellers
        public async Task<IActionResult> Index()
        {
            return View(await _sellerServices.FindAll());
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var seller = await _sellerServices.FindById(id);
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = String.Format("No seller found with id of {0}.", id) });
            }

            return View(seller);
        }

        // GET: Sellers/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(await _departmentServices.FindAll(), "ID", "Name");
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDate,Email,BaseSalary,DepartmentId")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                await _sellerServices.Add(seller);
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(await _departmentServices.FindAll(), "ID", "Name", seller.DepartmentId);
            return View(seller);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var seller = await _sellerServices.FindById(id);
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = String.Format("{0} is an invalid id.", id) });
            }

            ViewData["DepartmentId"] = new SelectList(await _departmentServices.FindAll(), "ID", "Name", seller.DepartmentId);
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDate,Email,BaseSalary,DepartmentId")] Seller seller)
        {
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = String.Format("No seller found with id of {0}.", id) });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _sellerServices.Update(seller);
                }
                catch (Exception e)
                {
                    if (e is DbUpdateConcurrencyException || e is DBConcurrencyException)
                    {
                        return View(seller);
                    }

                    throw;
                }
            }

            ViewData["DepartmentId"] = new SelectList(await _departmentServices.FindAll(), "ID", "ID", seller.DepartmentId);
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var seller = await _sellerServices.FindById(id);
            if (seller == null)
            {
                return RedirectToAction(nameof(Error), new { message = String.Format("No seller found with id of {0}.", id) });
            }

            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sellerServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SellerExists(int id)
        {
            return _sellerServices.FindAny(id);
        }

        public IActionResult Error(string message)
        {
            var errorViewModel = new ErrorViewModel()
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(errorViewModel);
        }
    }
}
