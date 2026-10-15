namespace SalesWebMvc.Models
{
    public class Departments
    {
        public int Id { get; init; }
        public required string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departments()
        {
        }

        public Departments(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public void AddSeller(Seller sr)
        {
            Sellers.Add(sr);
        }

        public decimal TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}