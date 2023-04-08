using ShopperApp.Models;
using ShopperApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopperApp.Controllers
{
    public class AdminController : Controller
    {
        private ShoppingAppConn db;
        public AdminController()
        {
            db = new ShoppingAppConn();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        #region Products
        // GET: Admin
        public ActionResult Index()
        {
            var products = db.Products.ToList();

            return View(products);
        }

        // GET: Admin/AddProduct
        public ActionResult AddProduct()
        {
            var product = new Product();
            return View(product);
        }

        // POST: Admin/AddProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(Product model)
        {
            var product = new Product();
            product.Name = $"{model.Name}-{model.ShopName}";
            product.Price = model.Price;
            product.ShopName = model.ShopName;
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region ShopperLists
        // GET: Admin/ShopperLists
        public ActionResult ShopperLists()
        {
            List<ShopperListVM> list = new List<ShopperListVM>();
            var items = db.ShopperLists.ToList();
            foreach(var item in items)
            {
                var model = new ShopperListVM();
                model.FullName = db.Users.SingleOrDefault(u => u.Id == item.UserId).FullName;
                model.ListId = item.ListId;
                model.ShopName = db.Shops.Find(item.ShopId).Name;
                list.Add(model);               
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateList()
        {
            var model = new CreateListVM();
            model.Shops = new SelectList(db.Shops.ToList(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateList(CreateListVM model)
        {
            var list = new ShopperList()
            {
                UserId = model.UserId,
                ShopId = model.ShopId,
                CreatedDate = DateTime.Now
            };
            db.ShopperLists.Add(list);
            db.SaveChanges();
            int id = list.ListId;
            return RedirectToAction("ShopperListDetails", new { id = id });
        }
        // GET: Admin/ShopperListDetails/id
        [HttpGet]
        public ActionResult ShopperListDetails(int id)
        {
            var list = db.ShopperLists.Find(id);
            TempData["shopname"] = db.Shops.SingleOrDefault(s => s.Id == list.ShopId).Name;
            return View(list);
        }

       // GET: Admin/EditShopperList/id
       [HttpGet]
        public ActionResult EditShopperList(int id)
        {
            var list = db.ShopperLists.SingleOrDefault(l => l.ListId == id);
            return View(list);
        }

        #endregion


        #region All Shops
        // GET: Admin/Shops
        [HttpGet]
        public ActionResult Shops()
        {
            var shops = db.Shops.ToList();
            return View(shops);
        }

        // GET: Admin/AddShop
        [HttpGet]
        public ActionResult AddShop()
        {
            var shop = new Shop();
            return View(shop);
        }

        // GET: Admin/AddShop
        [HttpPost]
        public ActionResult AddShop(Shop model)
        {
            var shop = new Shop();
            shop.Name = model.Name;
            shop.Address = model.Address;
            db.Shops.Add(shop);
            db.SaveChanges();
            return RedirectToAction("Shops");
        }

        #endregion 

        #region Users
        // GET: Admin/Users
        [HttpGet]
        public ActionResult Users()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        // GET: Admin/AddUser
        [HttpGet]
        public ActionResult AddUser()
        {
            var user = new User();
            return View(user);
        }

        // POST: Admin/AddUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(User model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("OOPs, ", "Error!");
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone
            };
            db.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction("Users");
        }

        // GET: Admin/EditUser/1
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var userInDb = db.Users.Find(id);
            return View(userInDb);
        }

        // POST: Admin/EditUser/
        [HttpPost]
        public ActionResult EditUser(User model)
        {
            var userInDb = db.Users.Find(model.Id);
            userInDb.FirstName = model.FirstName;
            userInDb.LastName = model.LastName;
            userInDb.Email = model.Email;
            userInDb.Phone = model.Phone;
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        // GET: Admin/UserDetails/1
        [HttpGet]
        public ActionResult UserDetails(int id)
        {
            var userInDb = db.Users.Find(id);
            return View(userInDb);
        }

        // GET: Admin/DeleteUser/1
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            var userInDb = db.Users.Find(id);
            db.Users.Remove(userInDb);
            db.SaveChanges();
            return RedirectToAction("Users");
        }
        #endregion

      
    }
}