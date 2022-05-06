﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BillPaymentService
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string token = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));

                string username = decodedToken.Split(':')[0];
                string password = decodedToken.Split(':')[1];

                if (BillPaymentSecurity.IsAuthorizedUser(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
        }

        //private bool IsAuthorizedUser(string Username, string Password)
        //{
        //    return Username && Password();
        //}
    }
}










            //public override void OnAuthorization(HttpActionContext actionContext)
            //{
            //    if (actionContext.Request.Headers.Authorization == null)
            //    {
            //        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            //    }
            //    else
            //    {
            //        string token = actionContext.Request.Headers.Authorization.Parameter;
            //        string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));

//        string username = decodedToken.Split(':')[0];
//        string password = decodedToken.Split(':')[1];

//        if (PlayerSecurity.Login(username, password))
//        {
//            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
//        }
//        else
//        {
//            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
//        }

//    }
//}


