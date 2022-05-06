using BillPaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillPaymentService
{
    public class BillPaymentSecurity
    {
        public static bool IsAuthorizedUser(string Username, string Password)
        {
            using (DBModel model = new DBModel())
            {
                return model.Users.Any(u => u.Username.Equals(Username, StringComparison.OrdinalIgnoreCase) && u.Password == Password);
            }
        }

    }
}