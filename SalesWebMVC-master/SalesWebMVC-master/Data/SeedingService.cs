using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingServices
    {
        private SalesWebMvcContext _context;

        public SeedingServices(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SaleRecord.Any())
            {
                return;
            }

            var departments = new List<Department>()
            {
                new Department(1, "Computers"),
                new Department(2, "Electronics"),
                new Department(3, "Fashion"),
                new Department(4, "Books")
            };
            var sellers = new List<Seller>()
            {
                new Seller(1, "Bob", new DateTime(1990, 4, 20), "bob@marley.com", 1000, departments[0]),
                new Seller(2, "John", new DateTime(1980, 1, 18), "john@john.com", 1000, departments[0]),
                new Seller(3, "Eduard", new DateTime(1992, 10, 16), "ed@snow.com", 900, departments[1]),
                new Seller(4, "Jannet", new DateTime(1989, 5, 12), "jan@net.com", 1100, departments[1]),
                new Seller(5, "Pepe", new DateTime(1988, 7, 10), "pepe@dfrog.com", 1100, departments[2]),
                new Seller(6, "Alice", new DateTime(1994, 7, 30), "alice@inchains.com", 800, departments[3]),
            };
            var sales = new List<SaleRecord>()
            {
                new SaleRecord(1, new DateTime(2019, 12, 1), 600, SaleStatus.PENDING, sellers[0]),
                new SaleRecord(2, new DateTime(2019, 12, 3), 499, SaleStatus.PENDING, sellers[0]),
                new SaleRecord(3, new DateTime(2019, 12, 4), 875, SaleStatus.PENDING, sellers[0]),
                new SaleRecord(4, new DateTime(2019, 12, 9), 400, SaleStatus.PENDING, sellers[0]),
                new SaleRecord(5, new DateTime(2019, 10, 2), 209, SaleStatus.PENDING, sellers[1]),
                new SaleRecord(6, new DateTime(2019, 10, 6), 706, SaleStatus.PENDING, sellers[1]),
                new SaleRecord(7, new DateTime(2019, 10, 7), 942, SaleStatus.PENDING, sellers[1]),
                new SaleRecord(8, new DateTime(2019, 12, 4), 199, SaleStatus.PENDING, sellers[2]),
                new SaleRecord(9, new DateTime(2019, 12, 5), 235, SaleStatus.PENDING, sellers[2]),
                new SaleRecord(11, new DateTime(2019, 12, 6), 1200, SaleStatus.PENDING, sellers[2]),
                new SaleRecord(12, new DateTime(2019, 11, 1), 132, SaleStatus.PENDING, sellers[3]),
                new SaleRecord(13, new DateTime(2019, 11, 2), 987, SaleStatus.PENDING, sellers[3]),
                new SaleRecord(14, new DateTime(2019, 11, 2), 340, SaleStatus.PENDING, sellers[4]),
                new SaleRecord(15, new DateTime(2019, 11, 3), 290, SaleStatus.PENDING, sellers[5])
            };

            _context.Department.AddRange(departments);
            _context.Seller.AddRange(sellers[0], sellers[1], sellers[2], sellers[3], sellers[4], sellers[5]);
            _context.SaleRecord.AddRange(sales[0], sales[1], sales[2], sales[3], sales[4], sales[5], sales[6], sales[7], sales[8], sales[9], sales[10], sales[11], sales[12], sales[13]);
            _context.SaveChanges();
        }
    }
}
