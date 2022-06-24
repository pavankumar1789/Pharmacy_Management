using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmacy_Management1.Models
{
    public partial class SupplierDetail
    {
        public SupplierDetail()
        {
            DrugDetails = new HashSet<DrugDetail>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }
        public string SupplierEmail { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Admin";
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "Admin";

        public virtual ICollection<DrugDetail> DrugDetails { get; set; }
    }
}
