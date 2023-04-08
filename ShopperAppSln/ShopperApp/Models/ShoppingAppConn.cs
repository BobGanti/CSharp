using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopperApp.Models
{
    public class ShoppingAppConn : DbContext
    {
        public ShoppingAppConn() : base("ShoppingAppConn")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopperList> ShopperLists { get; set; }

    }
}