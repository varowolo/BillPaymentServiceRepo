using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillPaymentService.Models
{

    public class BillsPaymentInfo
    {
        public Categories[] BillerCategories { get; set; }
    }



    public class BillpaymenService
    {
        public int code { get; set; }
        public string description { get; set; }
        public Categories categories { get; set; }
        public Merchants merchants { get; set; }
        public Biller biller { get; set; }
        public Items items { get; set; }
        public string pin { get; set; }
        public string transactionReference { get; set; }
        public Error errors { get; set; }
    }

    public class Categories
    {
      public int  categoryId { get; set; }
      public string  categoryName { get; set; }
      public int code { get; set; }
      public string description { get; set; }
    }

    public class Merchants
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string billerId { get; set; }
        public string billerName { get; set; }
        public int transactionCharge { get; set; }

    }

    public class Biller
    {
        public string billerId { get; set; }
        public string billerName { get; set; }
        public int transactionCharge { get; set; }
    }

    public class Items
    {
        public string itemId { get; set; }
        public string itemName { get; set; }
        public int amount { get; set; }
        public bool amountFixed { get; set; }
    }

    public class Error
    {
        public string error { get; set; }
        public string message { get; set; }
        public string code { get; set; }
        public string status { get; set; }
    }
}