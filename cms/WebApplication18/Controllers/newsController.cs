using datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cms.Controllers
{
    public class newsController : Controller
    {
        mycmscontext db = new mycmscontext();

        private ipagegroupreposirories pagegroupreposirories;
        private ipagerepositories pagerepositories;
        private ipagecommentrepositories pagecommentrepositories;
        public newsController()
        {


            pagegroupreposirories = new pagegrouprepositories(db);

            pagerepositories = new pagerepositories(db);

            pagecommentrepositories = new pagecommentrepositories(db);
        }



        public ActionResult showgroups()
        {
            return PartialView(pagegroupreposirories.getgroupsforview());
        }
        
        
        public ActionResult showgroupinmenu()
        {
            return PartialView(pagegroupreposirories.Getallgroups());
        }

        public ActionResult topnews()
        {
            return PartialView(pagerepositories.top());
        }

        public ActionResult lastnews()
        {
            return PartialView(pagerepositories.lastnews());
        }

        [Route("archive")]
        public ActionResult archivenews()
        {

            return View(pagerepositories.getallpage());

        }

        [Route("group/{id}/{title}")]
        public ActionResult shownewsbygroupid(int id , string title)
        {

            ViewBag.name = title;

            return View(pagerepositories.showgroupbyid(id));


        }


        [Route("news/{id}")]
        public ActionResult shownews(int id)
        {
            var news = pagerepositories.getpagebyid(id);

            if (news == null)
            {
               return HttpNotFound();


            }

            news.visit += 1;      
            pagerepositories.updatetpage(news);
            pagerepositories.save();

            return View(news);


        }

        public ActionResult addcomment(int id , string name , string email , string comment)
        {
            pagecomment addcomment = new pagecomment()
            {
                createdate = DateTime.Now,
                pageid = id,
                comment = comment,
                email = email,
                name = name,
                website="mycms"


            };

            pagecommentrepositories.addcomment(addcomment);

            return PartialView("showcomment", pagecommentrepositories.getcommentbynewsid(id));


        }


        public ActionResult showcomment(int id)
        {


            return PartialView(pagecommentrepositories.getcommentbynewsid(id));

        }
    }
}