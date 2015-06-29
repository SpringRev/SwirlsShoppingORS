using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BootstrapMVC.Models;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using log4net;
using System.Transactions;


namespace BootstrapMVC.Controllers
{
    public class TitlesController : Controller
    {

        private StoresEntities db = new StoresEntities();

        // GET: Titles
        public ActionResult Index()
        {

            var titles = db.Titles.Include(t => t.CATEGORY);
            return View(titles.ToList());

        }

        // GET: Titles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        // GET: Titles/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CATEGORies, "ID", "Name");
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CategoryID")] Title title)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        db.Titles.Add(title);
                        db.SaveChanges();
                        FileStream fs = new FileStream(@"D:\\RE", FileMode.Append);

                    }

                    ViewBag.CategoryID = new SelectList(db.CATEGORies, "ID", "Name", title.CategoryID);
                    transactionScope.Complete();
                    return RedirectToAction("Index");
                }
                catch
                {
                    transactionScope.Dispose();
                }
                finally
                {
                    // transactionScope.Dispose();

                }
                return View(title);

            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Name,CategoryID")] Title title)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.Titles.Add(title);
        //        db.SaveChanges();
        //        FileStream fs = new FileStream(@"D:\\RE", FileMode.Append);
        //        ViewBag.CategoryID = new SelectList(db.CATEGORies, "ID", "Name", title.CategoryID);
        //        return RedirectToAction("Index");

        //    }



        //    return View(title);

        //}

        // GET: Titles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CATEGORies, "ID", "Name", title.CategoryID);
            return View(title);
        }

        // POST: Titles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CategoryID")] Title title)
        {
            if (ModelState.IsValid)
            {
                db.Entry(title).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CATEGORies, "ID", "Name", title.CategoryID);
            return View(title);
        }

        // GET: Titles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Title title = db.Titles.Find(id);
            db.Titles.Remove(title);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
