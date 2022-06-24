using Pharmacy_Management1.Models;
using System.Collections.Generic;

namespace Pharmacy_Management1.Repository
{
    public interface IOrdersRepostiory
    {
        IEnumerable<Order> GetAll();
        Order Create(Order order);

        IEnumerable<Order> GetOrders(int id);
    }
}