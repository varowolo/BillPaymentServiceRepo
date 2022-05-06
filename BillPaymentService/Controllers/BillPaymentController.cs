using BillPaymentService.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BillPaymentService.Controllers
{
    public class BillPaymentController : ApiController
    {
        private string Baseurl = System.Configuration.ConfigurationManager.AppSettings["Baseurl"];
        private string authCode = System.Configuration.ConfigurationManager.AppSettings["AuthCode"];
        //private string APIkey = System.Configuration.ConfigurationManager.AppSettings["Apikey"];
        private string patnerId = System.Configuration.ConfigurationManager.AppSettings["patnerId"];
        private string categoryId = System.Configuration.ConfigurationManager.AppSettings["categoryId"];
        private string billerId = System.Configuration.ConfigurationManager.AppSettings["billerId"];
        private string productCode = System.Configuration.ConfigurationManager.AppSettings["productCode"];
        private string customerNumber = System.Configuration.ConfigurationManager.AppSettings["customerNumber"];
        private string amount = System.Configuration.ConfigurationManager.AppSettings["amount"];
        private string transactionReference = System.Configuration.ConfigurationManager.AppSettings["transactionReference"];
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // public string generateBCrypthash()
        //{
        //    var stringtohash = authCode + APIkey;
        //    var hash = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(stringtohash, DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt(12));
        //    return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(hash));
        //}

        //[BasicAuthentication]
        [Route("api/BillPayment/BillerCategories")]
        public async Task<object> getBillerCategories(BillpaymenService bs)
        {
            object PaymentInf = new object();
            BillpaymenService bip = bs;
            BillpaymenService bill = new BillpaymenService();
            Error errors = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage rep = await client.GetAsync("api/getBillerCategories/" + patnerId  + "/"+ authCode + "");
                var billResponse = rep.Content.ReadAsStringAsync().Result;                try
                {
                    logger.Info("Response: " + billResponse + Environment.NewLine + DateTime.Now);
                    if (rep.IsSuccessStatusCode)
                    {
                        PaymentInf = JsonConvert.DeserializeObject<object>(billResponse.ToString());
                        BillpaymenService bl = new BillpaymenService();    
                       // PaymentInf.Add(bl);

                    }
                    else if(rep.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";

                    }

                    else if (rep.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";
                    
                    }

                    else if (rep.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";

                    }
                    else if (rep.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";

                    }

                    else if (rep.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";
                    }

                    else if (rep.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";

                    }


                    else if (rep.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";

                    }

                    else if (rep.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";

                    }

                    else if (rep.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";

                    }

                    else if (rep.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(billResponse);
                        errors.status = "false";

                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Something went wrong!.--" + ex.Message);
                   // errors.code = "00";
                   // errors.message = "something went wrong";

                }                return (PaymentInf);
            }
        }


       //[BasicAuthentication]
        [Route("api/BillPayment/Categoriesid")]
        public async Task<object> getCategoryid(BillpaymenService bs)
        {
            object catInfo = new object();
            BillpaymenService bip = bs;
            BillpaymenService bill = new BillpaymenService();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage bet = await client.GetAsync("api/getBillers/" + patnerId + "/"+ authCode + "/" + categoryId + "");
                var catResponse = bet.Content.ReadAsStringAsync().Result;                try
                {
                    logger.Info("Response: " + catResponse + Environment.NewLine + DateTime.Now);
                    if (bet.IsSuccessStatusCode)
                    {
                        catInfo = JsonConvert.DeserializeObject<object>(catResponse);
                        BillpaymenService bl = new BillpaymenService();
                       
                    }

                    else if (bet.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";

                    }

                    else if (bet.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";

                    }

                    else if (bet.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";

                    }
                    else if (bet.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";

                    }

                    else if (bet.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";
                    }

                    else if (bet.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";

                    }


                    else if (bet.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";

                    }

                    else if (bet.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";

                    }

                    else if (bet.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";

                    }

                    else if (bet.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        errors.status = "false";

                    }
                }
                catch (Exception ex)
                {
                    //errors.code = "00";
                    //errors.message = "something went wrong";
                    logger.Error(ex, "Something went wrong!.--" + ex.Message);
                }
                return (catInfo);

            }
        }

      // [BasicAuthentication]
        [Route("api/BillPayment/Billerid")]
        public async Task<object> getBillerid(BillpaymenService bs)
        {
            object bilInfo = new object();
            BillpaymenService bip = bs;
            BillpaymenService bill = new BillpaymenService();
            Error errors = null;
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage bel = await client.GetAsync("api/getBiller/" + patnerId + "/" + authCode + "/" + billerId + "");
                var bilResponse = bel.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + bilResponse + Environment.NewLine + DateTime.Now);
                    if (bel.IsSuccessStatusCode)
                    {
                        bilInfo = JsonConvert.DeserializeObject<object>(bilResponse);
                        BillpaymenService bl = new BillpaymenService();
                    }

                    else if (bel.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";

                    }

                    else if (bel.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";

                    }

                    else if (bel.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";

                    }
                    else if (bel.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";

                    }

                    else if (bel.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";
                    }

                    else if (bel.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";

                    }


                    else if (bel.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";

                    }

                    else if (bel.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";

                    }

                    else if (bel.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";

                    }

                    else if (bel.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(bilResponse);
                        errors.status = "false";

                    }

                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Something went wrong!.--" + ex.Message);
                }
                return (bilInfo);
            }
        }

       // [BasicAuthentication]
        [Route("api/BillPayment/Transactionref")]
        public async Task<object> gettransactionref(BillpaymenService bs)
        {
            object trfInfo = new object();
            BillpaymenService bip = bs;
            BillpaymenService bill = new BillpaymenService();
            Error errors = null;
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage trf = await client.GetAsync(" api/query/" + patnerId + "/" + authCode + "/" + transactionReference + "");
                var datResponse = trf.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + datResponse + Environment.NewLine + DateTime.Now);
                    if (trf.IsSuccessStatusCode)
                    {
                        trfInfo = JsonConvert.DeserializeObject<object>(datResponse);
                        BillpaymenService bl = new BillpaymenService();
                    }

                    else if (trf.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";

                    }

                    else if (trf.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";

                    }

                    else if (trf.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";

                    }
                    else if (trf.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";

                    }

                    else if (trf.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";
                    }

                    else if (trf.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";

                    }


                    else if (trf.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";

                    }

                    else if (trf.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";

                    }

                    else if (trf.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";

                    }

                    else if (trf.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(datResponse);
                        errors.status = "false";

                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Something went wrong!.--" + ex.Message);

                }
                return (trfInfo);
            }

        }

        [BasicAuthentication]
        [HttpPost]
        [Route("api/BillPayment/PostPayment")]
        public async Task<object> PostPayments(Payment pt)
        {
            object ptInfo = null;
            Payment pyt = pt;
            errors Errors = null;
            Boolean status = true;

            if (String.IsNullOrEmpty(pyt.billerId))
            {
                Errors.message = "Invalid billerId";
                Errors.status = false;
            }

            if (String.IsNullOrEmpty(pyt.productCode))
            {
                Errors.message = "Invalid productCode";
                Errors.status = false;
            }

            if (String.IsNullOrEmpty(pyt.customerNumber))
            {
                Errors.message = "Invalid customerNumber";
                Errors.status = false;
            }

            if (String.IsNullOrEmpty(pyt.amount))
            {
                Errors.message = "Invalid amount";
                Errors.status = false;
            }

            if (String.IsNullOrEmpty(pyt.transactionReference))
            {
                Errors.message = "Invalid trxnReference";
                Errors.status = false;
            }

            else
            {
                status = true;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage rf = await client.PostAsJsonAsync("api/payBill/" + "" + "/" + authCode + "", pt);
                    var rfResponse = rf.Content.ReadAsStringAsync().Result;
                    try
                    {
                        logger.Info("Response: " + rfResponse + Environment.NewLine + DateTime.Now);
                        if (rf.IsSuccessStatusCode)
                        {
                            ptInfo = JsonConvert.DeserializeObject<object>(rfResponse);
                        }

                        else if (rf.StatusCode == HttpStatusCode.BadRequest)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.NoContent)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }
                        else if (rf.StatusCode == HttpStatusCode.BadGateway)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.NotImplemented)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;
                        }

                        else if (rf.StatusCode == HttpStatusCode.Conflict)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }


                        else if (rf.StatusCode == HttpStatusCode.NotFound)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.ServiceUnavailable)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.InternalServerError)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.Forbidden)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "Something went wrong!.--" + ex.Message);
                    }
                    if (Errors != null) return Errors;
                    else return ptInfo;

                }
            }
            if (status)
                return ptInfo;
            else return Errors;
        }


        // [BasicAuthentication]
        [HttpPost]
        [Route("api/BillPayment/PostBills")]
        public async Task<object> PostBillsName(Payment pyt)
        {
            object ptInfo = null;
            Payment pt = pyt;
            errors Errors = null;
            Boolean status = true;

            if (String.IsNullOrEmpty(pyt.billerId))
            {
                Errors.message = "Invalid billerId";
                Errors.status = false;
            }

            if (String.IsNullOrEmpty(pyt.productCode))
            {
                Errors.message = "Invalid productCode";
                Errors.status = false;
            }

            if (String.IsNullOrEmpty(pyt.customerNumber))
            {
                Errors.message = "Invalid customerNumber";
                Errors.status = false;
            }

            else
            {
                status = true;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage rf = await client.PostAsJsonAsync("api/nameLookup/" + patnerId + "/" + authCode + "/" + billerId+ "/" + productCode + "/" + customerNumber + "", pyt);
                    var rfResponse = rf.Content.ReadAsStringAsync().Result;
                    try
                    {
                        logger.Info("Response: " + rfResponse + Environment.NewLine + DateTime.Now);
                        if (rf.IsSuccessStatusCode)
                        {
                            ptInfo = JsonConvert.DeserializeObject<object>(rfResponse);
                        }

                        else if (rf.StatusCode == HttpStatusCode.BadRequest)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.NoContent)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }
                        else if (rf.StatusCode == HttpStatusCode.BadGateway)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.NotImplemented)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;
                        }

                        else if (rf.StatusCode == HttpStatusCode.Conflict)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }


                        else if (rf.StatusCode == HttpStatusCode.NotFound)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.ServiceUnavailable)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.InternalServerError)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }

                        else if (rf.StatusCode == HttpStatusCode.Forbidden)
                        {
                            Errors = JsonConvert.DeserializeObject<errors>(rfResponse);
                            Errors.status = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "Something went wrong!.--" + ex.Message);
                    }
                    if (Errors != null) return Errors;
                    else return ptInfo;
                }
            }
            if (status)
                return ptInfo;
            else return Errors;
        }
    }
}
