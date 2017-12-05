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
    public class HastalarController : Controller
    {
        private AsiTakipDBEntities db = new AsiTakipDBEntities();

        // GET: Hastalar
        public ActionResult Index()
        {
            return View(db.Hastalars.ToList());
        }

        // GET: Hastalar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hastalar hastalar = db.Hastalars.Find(id);
            if (hastalar == null)
            {
                return HttpNotFound();
            }
            return View(hastalar);
        }

        // GET: Hastalar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hastalar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HastaId,TCNO,HastaAdi,HastaSoyadi,HastaDtar,HastaBoy,HastaKilo")] Hastalar hastalar)
        {
            if (ModelState.IsValid)
            {
                db.Hastalars.Add(hastalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hastalar);
        }

        // GET: Hastalar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hastalar hastalar = db.Hastalars.Find(id);
            if (hastalar == null)
            {
                return HttpNotFound();
            }
            return View(hastalar);
        }

        // POST: Hastalar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HastaId,TCNO,HastaAdi,HastaSoyadi,HastaDtar,HastaBoy,HastaKilo")] Hastalar hastalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hastalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hastalar);
        }

        // GET: Hastalar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hastalar hastalar = db.Hastalars.Find(id);
            if (hastalar == null)
            {
                return HttpNotFound();
            }
            return View(hastalar);
        }

        // POST: Hastalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hastalar hastalar = db.Hastalars.Find(id);
            db.Hastalars.Remove(hastalar);
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
