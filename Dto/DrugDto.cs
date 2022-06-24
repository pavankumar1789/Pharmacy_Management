using System;

namespace Pharmacy_Management1.Dto
{
    public class DrugDto
    {
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? SupplierId { get; set; }
        public int DrugId { get; set; }
        public DateTime? ExpiryDate { get; internal set; } = DateTime.Now;
    }
}