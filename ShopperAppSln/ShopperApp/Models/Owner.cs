using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopperApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShoppingListId { get; set; }

    }
}