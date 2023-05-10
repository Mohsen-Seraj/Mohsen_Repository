using datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cms.Controllers
{
    public class HomeController : Controller
    {
        mycmscontext db = new mycmscontext();

        ipagerepositories pagerepositories;

        public HomeController()
        {

            pagerepositories = new pagerepositories(db);



        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult slider()
        {


            return PartialView(pagerepositories.pageinslider());

        }


    }
}