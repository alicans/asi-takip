using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Son.Models;
using System.Web.Security;
using MVC_Son.CustomFilters;

namespace MVC_Son.Controllers
{
    [Authorize]
    public class AsilarController : Controller
    {
        private AsiTakipDBEntities db = new AsiTakipDBEntities();

        // GET: Asilar
        [AuthLog(Roles = "Yetkili")]
        public ActionResult Index()
        {
            return View(db.Asis.ToList());
        }

        // GET: Asilar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asi asi = db.Asis.Find(id);
            if (asi == null)
            {
                return HttpNotFound();
            }
            return View(asi);
        }

        // GET: Asilar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asilar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsiId,AsiAdi")] Asi asi)
        {
            if (ModelState.IsValid)
            {
                db.Asis.Add(asi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asi);
        }

        // GET: Asilar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asi asi = db.Asis.Find(id);
            if (asi == null)
            {
                return HttpNotFound();
            }
            return View(asi);
        }

        // POST: Asilar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsiId,AsiAdi")] Asi asi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asi);
        }

        // GET: Asilar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asi asi = db.Asis.Find(id);
            if (asi == null)
            {
                return HttpNotFound();
            }
            return View(asi);
        }

        // POST: Asilar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asi asi = db.Asis.Find(id);
            db.Asis.Remove(asi);
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
