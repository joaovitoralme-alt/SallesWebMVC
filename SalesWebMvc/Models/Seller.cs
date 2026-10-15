using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public required int Id { get; init; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public required DateTime BirtDate { get; set; }
        public required decimal BaseSalary { get; set; }
        public Departments? Departments { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birtDate, decimal baseSalary, Departments? departments)
        {
            Id = id;
            Name = name;
            Email = email;
            BirtDate = birtDate;
            BaseSalary = baseSalary;
            Departments = departments;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public decimal TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
