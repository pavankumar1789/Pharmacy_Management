using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmacy_Management1.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderId { get; set; }
        public int? DrugId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = "Admin";
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "Admin";
        public decimal? OrderPrice { get; set; }
        public DateTime OrderPickedUp { get; set; } = DateTime.Now;

        public virtual DrugDetail Drug { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
