using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using datalayer;

namespace cms.Controllers
{
    [Authorize]
    public class pagegroupsController : Controller
    {
        private ipagegroupreposirories pagegroupreposirories;
        private mycmscontext db = new mycmscontext();

        public pagegroupsController()
        {

            pagegroupreposirories = new pagegrouprepositories(db);


        }



        // GET: pagegroups
        public ActionResult Index()
        {
            return View(pagegroupreposirories.Getallgroups());
        }

        // GET: pagegroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            pagegroup pagegroup = pagegroupreposirories.getgroupid(id.Value);

            if (pagegroup == null)
            {
                return HttpNotFound();
            }
            return View(pagegroup);
        }

        // GET: pagegroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pagegroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "groupid,grouptitle")] pagegroup pagegroup)
        {
            if (ModelState.IsValid)
            {
                pagegroupreposirories.insertgroup(pagegroup);
                pagegroupreposirories.save();
                return RedirectToAction("Index");
            }

            return View(pagegroup);
        }

        // GET: pagegroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            pagegroup pagegroup = pagegroupreposirories.getgroupid(id.Value);

            if (pagegroup == null)
            {
                return HttpNotFound();
            }
            return View(pagegroup);
        }

        // POST: pagegroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "groupid,grouptitle")] pagegroup pagegroup)
        {
            if (ModelState.IsValid)
            {
                pagegroupreposirories.updategroup(pagegroup);
                pagegroupreposirories.save();
                return RedirectToAction("Index");
            }
            return View(pagegroup);
        }

        // GET: pagegroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pagegroup pagegroup = pagegroupreposirories.getgroupid(id.Value);
            if (pagegroup == null)
            {
                return HttpNotFound();
            }
            return View(pagegroup);
        }

        // POST: pagegroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           pagegroupreposirories.deletegroup(id);
            pagegroupreposirories.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pagegroupreposirories.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
