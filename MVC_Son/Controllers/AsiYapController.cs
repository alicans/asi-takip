using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Son.Models;

namespace MVC_Son.Controllers
{
    [Authorize]
    public class AsiYapController : Controller
    {
        private AsiTakipDBEntities db = new AsiTakipDBEntities();

        // GET: AsiYap
        public ActionResult Index()
        {
            var hastaAsis = db.HastaAsis.Include(h => h.Asi).Include(h => h.Hastalar);
            return View(hastaAsis.ToList());
        }

        // GET: AsiYap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HastaAsi hastaAsi = db.HastaAsis.Find(id);
            if (hastaAsi == null)
            {
                return HttpNotFound();
            }
            return View(hastaAsi);
        }

        // GET: AsiYap/Create
        public ActionResult Create()
        {
            ViewBag.AsiId = new SelectList(db.Asis, "AsiId", "AsiAdi");
            ViewBag.HastaId = new SelectList(db.Hastalars, "HastaId", "TCNO");
            return View();
        }

        // POST: AsiYap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HastaAsiId,HastaId,AsiId")] HastaAsi hastaAsi)
        {
            if (ModelState.IsValid)
            {
                db.HastaAsis.Add(hastaAsi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsiId = new SelectList(db.Asis, "AsiId", "AsiAdi", hastaAsi.AsiId);
            ViewBag.HastaId = new SelectList(db.Hastalars, "HastaId", "TCNO", hastaAsi.HastaId);
            return View(hastaAsi);
        }

        // GET: AsiYap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HastaAsi hastaAsi = db.HastaAsis.Find(id);
            if (hastaAsi == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsiId = new SelectList(db.Asis, "AsiId", "AsiAdi", hastaAsi.AsiId);
            ViewBag.HastaId = new SelectList(db.Hastalars, "HastaId", "TCNO", hastaAsi.HastaId);
            return View(hastaAsi);
        }

        // POST: AsiYap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HastaAsiId,HastaId,AsiId")] HastaAsi hastaAsi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hastaAsi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsiId = new SelectList(db.Asis, "AsiId", "AsiAdi", hastaAsi.AsiId);
            ViewBag.HastaId = new SelectList(db.Hastalars, "HastaId", "TCNO", hastaAsi.HastaId);
            return View(hastaAsi);
        }

        // GET: AsiYap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HastaAsi hastaAsi = db.HastaAsis.Find(id);
            if (hastaAsi == null)
            {
                return HttpNotFound();
            }
            return View(hastaAsi);
        }

        // POST: AsiYap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HastaAsi hastaAsi = db.HastaAsis.Find(id);
            db.HastaAsis.Remove(hastaAsi);
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
