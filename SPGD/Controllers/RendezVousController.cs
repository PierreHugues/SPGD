﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPGD.Models;

namespace SPGD.Controllers
{
    public class RendezVousController : Controller
    {
        private H15_PROJET_E09Entities1 db = new H15_PROJET_E09Entities1();

        // GET: RendezVous
        public ActionResult Index()
        {
            var rendezVous = db.RendezVous.Include(r => r.Seance);
            return View(rendezVous.ToList());
        }

        // GET: RendezVous/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendezVou rendezVou = db.RendezVous.Find(id);
            if (rendezVou == null)
            {
                return HttpNotFound();
            }
            return View(rendezVou);
        }

        // GET: RendezVous/Create
        public ActionResult Create()
        {
            ViewBag.RendezVousID = new SelectList(db.Seances, "SeanceID", "StatusSeance");
            return View();
        }

        // POST: RendezVous/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Completee,DateHeureRendezVous,DureeRendezVousReel,NbPhotoReel,VisiteVirtuelleNbPanoramas,VisiteImmersiveEstFaite,Commentaire,RendezVousID")] RendezVou rendezVou)
        {
            if (ModelState.IsValid)
            {
                db.RendezVous.Add(rendezVou);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RendezVousID = new SelectList(db.Seances, "SeanceID", "StatusSeance", rendezVou.RendezVousID);
            return View(rendezVou);
        }

        // GET: RendezVous/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendezVou rendezVou = db.RendezVous.Find(id);
            if (rendezVou == null)
            {
                return HttpNotFound();
            }
            ViewBag.RendezVousID = new SelectList(db.Seances, "SeanceID", "StatusSeance", rendezVou.RendezVousID);
            return View(rendezVou);
        }

        // POST: RendezVous/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Completee,DateHeureRendezVous,DureeRendezVousReel,NbPhotoReel,VisiteVirtuelleNbPanoramas,VisiteImmersiveEstFaite,Commentaire,RendezVousID")] RendezVou rendezVou)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rendezVou).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RendezVousID = new SelectList(db.Seances, "SeanceID", "StatusSeance", rendezVou.RendezVousID);
            return View(rendezVou);
        }

        // GET: RendezVous/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendezVou rendezVou = db.RendezVous.Find(id);
            if (rendezVou == null)
            {
                return HttpNotFound();
            }
            return View(rendezVou);
        }

        // POST: RendezVous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RendezVou rendezVou = db.RendezVous.Find(id);
            db.RendezVous.Remove(rendezVou);
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
