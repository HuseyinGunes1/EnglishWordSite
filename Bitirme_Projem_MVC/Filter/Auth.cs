using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bitirme_Projem_MVC.Filter
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var ctx = filterContext.HttpContext;

           
            if (ctx.Session["user_id"] == null)
            {
                filterContext.Result = new RedirectResult("~/Anasayfa/Anasayfa");

            }

            
        }
    }
}