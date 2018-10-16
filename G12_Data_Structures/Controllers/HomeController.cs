using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures.Controllers
{
    public class HomeController : Controller
    {
        //Home Action to show homepage
        public ActionResult Index()
        {
            return View();
        }

        //Exit to BYU page
        public ActionResult Exit()
        {
            return Redirect("https://www.byu.edu/");
        }
    }
}
