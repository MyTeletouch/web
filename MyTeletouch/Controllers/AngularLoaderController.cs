using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTeletouch.Controllers
{
    public class AngularLoaderController : BaseController
    {
        // Route: /{culture}/angular/usershippingaddress

        /// <summary>
        /// Load angularjs form, which user should to fill.
        /// Route: /{culture}/angular/usershippingaddress
        /// </summary>
        /// <returns></returns>
        public ActionResult ApplicationUserShippingAddressPageCtrl()
        {
            return View();
        }
    }
}