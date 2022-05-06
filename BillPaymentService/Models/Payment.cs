using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace BillPaymentService.Models
//{

public class Payment
{
   // public string patnerId { get; set; }
    public string authCode { get; set; }
    public string billerId { get; set; }
    public string productCode { get; set; }
    public string customerNumber { get; set; }
    public string amount { get; set; }
    public string transactionReference { get; set; }
}

public class errors
{
    public string error { get; set; }
    public string message { get; set; }
    public string statuscode { get; set; }
    public bool status { get; set; }
}
//}