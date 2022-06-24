using Pharmacy_Management1.Models;
using System.Collections.Generic;

namespace Pharmacy_Management1.Repository
{
    public interface IOrderRepository
    {
        OrderDetail Create(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetAll();

        OrderDetail GetOrder(int id);
        void DeleteOrder(int id);
        void UpdateOrder(OrderDetail orderDetail);
    }
}