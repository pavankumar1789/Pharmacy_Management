using Microsoft.EntityFrameworkCore;
using Pharmacy_Management1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy_Management1.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly pharmacy_managementContext _context;
        public OrderRepository(pharmacy_managementContext context)
        {
            _context = context;
        }

        public OrderDetail Create(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();

            return orderDetail;
        }

        public void DeleteOrder(int id)
        {
            OrderDetail drugs = GetOrder(id);
            _context.Remove(drugs);
            _context.SaveChanges();


        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _context.OrderDetails.Include(ordr => ordr.Drug).ToList();
            //return _context.SupplierDetails.Include(drug => drug.DrugDetails).ToList();
        }


        public OrderDetail GetOrder(int id)
        {
            var supplier = _context.OrderDetails.Where(u => u.OrderId == id).Include(c => c.Drug).FirstOrDefault();
            return supplier;
        }

        public void UpdateOrder(OrderDetail orderDetail)
        {
            _context.Entry(orderDetail).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}