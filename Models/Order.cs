using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmacy_Management1.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Admin";
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "Admin";

        public virtual OrderDetail OrderNavigation { get; set; }
        public virtual UserDetail User { get; set; }
    }
}
