using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopperApp.Models.ViewModels
{
    public class CreateListVM
    {
        public CreateListVM()
        {

        }
        public CreateListVM(ShopperList list)
        {
            ListId = list.ListId;
            UserId = list.UserId;
            ShopId = list.ShopId;
        }

        public int ListId { get; set; }
        public int UserId { get; set; }
        public int ShopId { get; set; }
   
        public IEnumerable<SelectListItem> Shops { get; set; }
    }
}