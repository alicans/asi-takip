using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Son.Models;
using MVC_Son.CustomFilters;

namespace MVC_Son.Controllers
{
    [Authorize]
    public class AsiStokController : Controller
    {
        private AsiTakipDBEntities db = new AsiTakipDBEntities();

        // GET: AsiStok
        [AuthLog(Roles = "Yetkili")]
        public ActionResult Index()
        {
            var asiStoks = db.AsiStoks.Include(a => a.Asi);
            return View(asiStoks.ToList());
        }

        // GET: AsiStok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsiStok asiStok = db.AsiStoks.Find(id);
            if (asiStok == null)
            {
                return HttpNotFound();
            }
            return View(asiStok);
        }

        // GET: AsiStok/Create
        public ActionResult Create()
        {
            ViewBag.AsiId = new SelectList(db.Asis, "AsiId", "AsiAdi");
            return View();
        }

        // POST: AsiStok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsiStokId,AsiId,Stok")] AsiStok asiStok)
        {
            if (ModelState.IsValid)
            {
                db.AsiStoks.Add(asiStok);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsiId = new SelectList(db.Asis, "AsiId", "AsiAdi", asiStok.AsiId);
            return View(asiStok);
        }

        // GET: AsiStok/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsiStok asiStok = db.AsiStoks.Find(id);
            if (asiStok == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsiId = new SelectList(db.Asis, "AsiId", "AsiAdi", asiStok.AsiId);
            return View(asiStok);
        }

        // POST: AsiStok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsiStokId,AsiId,Stok")] AsiStok asiStok)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiStok).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsiId = new SelectList(db.Asis, "AsiId", "AsiAdi", asiStok.AsiId);
            return View(asiStok);
        }

        // GET: AsiStok/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsiStok asiStok = db.AsiStoks.Find(id);
            if (asiStok == null)
            {
                return HttpNotFound();
            }
            return View(asiStok);
        }

        // POST: AsiStok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsiStok asiStok = db.AsiStoks.Find(id);
            db.AsiStoks.Remove(asiStok);
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
