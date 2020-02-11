using EcommerceApplication.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApplication.Models;
using EcommerceApplication.DataContext;

namespace EcommerceApplication.Services.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly MyContext _db;

        public CustomerRepository(MyContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.Customer.Count();
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                _db.Customer.Remove(customer);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _db.Customer.Select(cu => cu);
        }

        public Customer GetById(int id)
        {
            return _db.Customer.FirstOrDefault(cu => cu.CustomerId == id);
        }

        public void Insert(Customer cust)
        {
            _db.Customer.Add(cust);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Customer cust)
        {
            _db.Customer.Update(cust);
        }
    }
}
