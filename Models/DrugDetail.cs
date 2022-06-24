using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmacy_Management1.Models
{
    public partial class DrugDetail
    {
        public DrugDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; } = DateTime.Now;
        public decimal? Price { get; set; }
        public int? SupplierId { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Admin";
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "Admin";

        public virtual SupplierDetail Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
