using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopperApp.Models.ViewModels
{
    public class ShopperListVM
    {
        public int ListId { get; set; }
        public int UserId { get; set; }
        public string ShopName { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}