using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartmentServices
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentServices(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Department>> FindAll()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<Department> FindById(int? id)
        {
            return await _context.Department.FindAsync(id);
        }

        public bool FindAny(int? id)
        {
            return _context.Department.Any(d => d.ID == id);
        }

        public async Task<int> Add(Department department)
        {
            _context.Department.Add(department);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Department department)
        {
            _context.Department.Update(department);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Remove(int id)
        {
            var department = await FindById(id);
            _context.Department.Remove(department);
            return await _context.SaveChangesAsync();
        }
    }
}
