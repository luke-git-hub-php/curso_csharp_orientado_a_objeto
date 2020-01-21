using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    // Classe que implementa as regras de negócio
    public class SellerServices
    {
        private readonly SalesWebMvcContext _context;

        public SellerServices(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seller>> FindAll()
        {
            return await _context.Seller.Include(s => s.Department).ToListAsync();
        }

        public async Task<Seller> FindById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.Seller.Include(s => s.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        public bool FindAny(int id)
        {
            return _context.Seller.Any(s => s.Id == id);
        }

        public async Task<int> Add(Seller seller)
        {
            _context.Add(seller);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Seller seller)
        {
            _context.Update(seller);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Remove(int id)
        {
            var seller = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(seller);
            return await _context.SaveChangesAsync();
        }
    }
}

