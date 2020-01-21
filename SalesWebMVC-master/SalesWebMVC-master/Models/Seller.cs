using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SaleRecord> Sales { get; set; } = new List<SaleRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, DateTime birthDate, string email, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Email = email;
            BaseSalary = baseSalary;
            Department = department;
            DepartmentId = department.ID;
        }

        public void AddSale(SaleRecord sale)
        {
            Sales.Add(sale);
        }

        public void RemoveSale(SaleRecord sale)
        {
            Sales.Remove(sale);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return Sales
                .Where(sale => sale.Date >= initialDate && sale.Date <= finalDate)
                .Sum(sale => sale.Ammount);
        }
    }
}
