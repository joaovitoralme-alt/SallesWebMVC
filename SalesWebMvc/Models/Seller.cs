namespace SalesWebMvc.Models
{
    public class Seller
    {
        public required int Id { get; init; }
        public required string Name { get; set; }
        public required string Email { get; set; }
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
    }
}
