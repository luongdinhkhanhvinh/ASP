using CDTH17.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CDTH17.Models.BaoMat
{
    public class CustomPrincipal : IPrincipal
    {
        private Account Account;
        public CustomPrincipal(Account account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.UserName);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });

            List<string> dsq = new List<string>();
            foreach (viewQuyen dt in HttpContext.Current.Session["Quyen"] as List<viewQuyen>)
            {
                dsq.Add(dt.RoleName);
            }
            bool kq = roles.Any(r => dsq.Contains(r));
            return kq;
        }
    }
}