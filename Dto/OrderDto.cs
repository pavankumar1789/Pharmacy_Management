namespace Pharmacy_Management1.Dto
{
    public class OrderDto
    {
        public int? DrugId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? OrderPrice { get; set; }
    }
}