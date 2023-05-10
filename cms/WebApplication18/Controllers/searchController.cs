using datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cms.Controllers
{
    public class searchController : Controller
    {


        mycmscontext db = new mycmscontext();

        ipagerepositories pagerepositories;

        public searchController()
        {

            pagerepositories = new pagerepositories(db);

        }


        public ActionResult Index(string id)
        {

            ViewBag.name = id;
            return View(pagerepositories.searchpage(id));

            }
    }
}