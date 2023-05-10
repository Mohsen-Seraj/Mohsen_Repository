using datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace cms.Controllers
{
    public class accountController : Controller
    {

        mycmscontext db = new mycmscontext();

        private iloginrepositories loginrepositories;

        public accountController()
        {

            loginrepositories = new loginrepositories(db);


        }

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(loginviewmodel login , string returnurl="/")
        {
            if (ModelState.IsValid)
            {
                if (loginrepositories.isexistuser(login.username, login.password))
                {

                    FormsAuthentication.SetAuthCookie(login.username, login.rememberme);

                    return Redirect (returnurl);

                }

                else
                {

                    ModelState.AddModelError("username", " کاربری یافت نشد");

                }
            }
            return View(login);
        }

        public ActionResult signout()
        {

            FormsAuthentication.SignOut();

            return Redirect("/");
        }

    }
}