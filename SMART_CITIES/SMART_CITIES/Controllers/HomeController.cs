using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMART_CITIES.Models;
using SMART_CITIES.Models.Repository;

namespace SMART_CITIES.Controllers
{
   

    public class HomeController : Controller
    {
        /// <summary>
        /// Action about home page
        /// </summary>
        /// <returns>home page view(index view)</returns>
        public ActionResult Index()
        {
            return View();
        }


    }
}