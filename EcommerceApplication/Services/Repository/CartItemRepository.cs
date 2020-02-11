using EcommerceApplication.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApplication.Models;
using EcommerceApplication.DataContext;

namespace EcommerceApplication.Services.Repository
{
    public class CartItemRepository : ICartItem
    {
        private readonly MyContext _db;

        public CartItemRepository(MyContext db)
        {
            _db = db;
        }

        public int Count()
        {
            return _db.CartItem.Count();
        }

        public void Delete(int id)
        {
            var cartItem = GetById(id);
            if (cartItem != null)
            {
                _db.CartItem.Remove(cartItem);
            }
        }

        public IEnumerable<CartItem> GetAll()
        {
            return _db.CartItem.Select(ci => ci);
        }

        public CartItem GetById(int id)
        {
            return _db.CartItem.FirstOrDefault(ci => ci.CartItemId == id);
        }

        public void Insert(CartItem cart)
        {
            _db.CartItem.Add(cart);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CartItem cart)
        {
            _db.CartItem.Update(cart);
        }
    }
}
