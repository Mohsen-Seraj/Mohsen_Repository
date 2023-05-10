using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using datalayer;

namespace cms.Controllers
{
    [Authorize]

    public class pagesController : Controller
    {
        private mycmscontext db = new mycmscontext(); 

        private ipagerepositories pagerepositories;
        private ipagegroupreposirories pagegroupreposirories;

      
        public pagesController()
        {

            pagerepositories = new pagerepositories(db);
            pagegroupreposirories = new pagegrouprepositories(db);


        }


        // GET: pages
        public ActionResult Index()
        {

            return View(pagerepositories.getallpage());
        }

        // GET: pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            page page = pagerepositories.getpagebyid(id.Value);

            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: pages/Create
        public ActionResult Create()
        {

            ViewBag.groupid = new SelectList(pagegroupreposirories.Getallgroups(), "groupid", "grouptitle");
            return View();

        }

        // POST: pages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pageid,groupid,title,shortdescription,text,visit,imagename,showinslider,createdate")] page page , HttpPostedFileBase imgup)
        {
            if (ModelState.IsValid)
            {
                page.visit = 0;
                page.createdate = DateTime.Now;

                if (imgup != null)
                {

                    page.imagename = Guid.NewGuid() + Path.GetExtension(imgup.FileName);

                    imgup.SaveAs(Server.MapPath("/images/" + page.imagename));


                }


                pagerepositories.insertpage(page);
                pagerepositories.save();
                return RedirectToAction("Index");
            }

            ViewBag.groupid = new SelectList(pagegroupreposirories.Getallgroups(), "groupid", "grouptitle", page.groupid);
            return View(page);
        }

        // GET: pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            page page = pagerepositories.getpagebyid(id.Value);

            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.groupid = new SelectList(pagegroupreposirories.Getallgroups(), "groupid", "grouptitle", page.groupid);
            return View(page);
        }

        // POST: pages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pageid,groupid,title,shortdescription,text,visit,imagename,showinslider,createdate")] page page , HttpPostedFileBase imgup)
        {
            if (ModelState.IsValid)
            {
                if (imgup != null)
                {

                    if (page.imagename != null)
                    {

                        System.IO.File.Delete(Server.MapPath("/images/" + page.imagename));

                    }




                    page.imagename = Guid.NewGuid() + Path.GetExtension(imgup.FileName);

                    imgup.SaveAs(Server.MapPath("/images/" + page.imagename));


                }
                pagerepositories.updatetpage(page);
                pagerepositories.save();

             
                return RedirectToAction("Index");
            }
            ViewBag.groupid = new SelectList(pagegroupreposirories.Getallgroups(), "groupid", "grouptitle", page.groupid);
            return View(page);
        }

        // GET: pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            page page = pagerepositories.getpagebyid(id.Value);

            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = pagerepositories.getpagebyid(id);


            if (page.imagename != null)
            {

                System.IO.File.Delete(Server.MapPath("/images/" + page.imagename));

            }
            pagerepositories.deletepage(page);
            pagerepositories.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pagerepositories.Dispose();
                pagegroupreposirories.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
