using SalesWebMvc.Models.Enums;
namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public required int Id { get; init; }
        public required DateTime Date { get; set; }
        public required decimal Amount { get; set; }
        public required SaleStatus Status { get; set; }
        public Seller? Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, decimal amount, SaleStatus status, Seller? seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }



}
