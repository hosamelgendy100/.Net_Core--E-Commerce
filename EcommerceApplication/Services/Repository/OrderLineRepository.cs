using EcommerceApplication.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApplication.Models;
using EcommerceApplication.DataContext;


namespace EcommerceApplication.Services.Repository
{
    public class OrderLineRepository : IOrderLine
    {
        private readonly MyContext _db;

        public OrderLineRepository(MyContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.OrderLine.Count();
        }

        public IEnumerable<OrderLine> GetAll()
        {
            return _db.OrderLine.Select(ol => ol);
        }

        public OrderLine GetById(int id)
        {
            return _db.OrderLine.FirstOrDefault(ol => ol.OrderLineId == id);
        }

        public void Insert(OrderLine orderLine)
        {
            _db.OrderLine.Add(orderLine);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderLine orderLine)
        {
            _db.OrderLine.Update(orderLine);
        }
    }
}
