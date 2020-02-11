using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EcommerceApplication.Models;
using EcommerceApplication.ViewModels;
using EcommerceApplication.DataContext;
using EcommerceApplication.Services.Infrastructure;
using EcommerceApplication.ViewModels.Card;

namespace EcommerceApplication.Controllers
{
    public class CardController : Controller
    {
        private readonly MyContext _db;
        private readonly UserManager<Customer> _userManager;
        private readonly ICartItem _cartItemRepository;

        public CardController (MyContext db, UserManager<Customer> userManager, ICartItem cartItemRepository)
        {
            _db = db;
            _userManager = userManager;
            _cartItemRepository = cartItemRepository;
        }

        #region Card Index Page

        //public IActionResult Index()
        //{
        //    var userId = _userManager.GetUserId(HttpContext.User);

        //    var query = from p in _db.CartItem where p.CustomerId.ToString() == userId
        //                group p by new {p.Product.ProductName, p.Product.UnitPrice} into g 
        //                select new
        //                {
        //                    Name = g.Key.ProductName,
        //                    Count = g.Count(),
        //                    Price = g.UnitPrice
        //                };

        //    CardIndexViewModel cardVM = new CardIndexViewModel();
        //    foreach (var item in query)
        //    {
        //        CardProductViewModel cProd = new CardProductViewModel();

        //        cProd.ProductName = item.Name;
        //        cProd.Quantity = item.Count();
        //        cProd.Price = item.Price;
        //        cProd.ProductTotal = item.Price * item.Count;
                
        //        cardVM.CardProductViewModelList.Add(cProd);
        //    }

        //    cardVM.CardTotalPrice = cardVM.CardProductViewModelList.Sum(c => c.ProductTotal);
        //    return View(cardVM);
        //}

        #endregion

        #region Add to Card

        [HttpPost]
        public IActionResult Add([FromForm] int? id)
        {
            //if (id != null)
            //{
            //    var userId = _userManager.GetUserId(HttpContext.User);
            //    CartItem cartItem = new CartItem()
            //    {
            //        CustomerId = userId,
            //        AddedDate = DateTime.Now,
            //        ProductId = Convert.ToInt32(id)
            //    };
            //_db.CartItem.Add(cartItem);
            //_db.SaveChanges();
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Product not found");
            //    return NotFound();
            //}

            return RedirectToAction("Index", "Product");
        }

        #endregion
    }
}
