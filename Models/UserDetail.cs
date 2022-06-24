using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmacy_Management1.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Contact { get; set; }
        public string UserAddress { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "Admin";
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; } = "Admin";
       // public string PhotoFileName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
