﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPGD.Models;
using SPGD.DAL;

namespace SPGD.Controllers
{
    public class RendezVousController : Controller
    {
        //private H15_PROJET_E09Entities1 db = new H15_PROJET_E09Entities1();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: RendezVous
        public ActionResult Index()
        {
            //var rendezVous = db.RendezVous.Include(r => r.Seance);
            return View(unitOfWork.RendezVousRepository.GetRendezVous());
        }

        // GET: RendezVous/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendezVou rendezVou = unitOfWork.RendezVousRepository.GetByID(id);
            if (rendezVou == null)
            {
                return HttpNotFound();
            }
            return View(rendezVou);
        }

        // GET: RendezVous/Create
        public ActionResult Create(int? id)
        {
            DateTime dateCourante = DateTime.Now;
            string format = "yyyy-MM-dd hh:mm:ss";
            ViewBag.Datecourante = dateCourante.AddDays(1).ToString(format);
            var photographequery = unitOfWork.PhotographeRepository.GetPhotographes();
            ViewBag.PhotographeID = new SelectList(photographequery, "PhotographeID", "Nom");
            //ViewBag.SeanceID = new SelectList(db.Seances, "SeanceID", "SeanceID");
            ViewBag.SeanceID = id; 
            return View();
        }

        // POST: RendezVous/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateHeureRendezVous,Commentaire, RendezVouID")] RendezVou rendezVou, int PhotographeID)    // IL FAUT RÉSOUDRE ICI LE PROBLÈMEDU FAIT QUE rendezVous RECOIT TOUJOURS UN ID DE 0
        {
            ModelState.Remove("NbPhotoReel");
            ModelState.Remove("DureeRendezVousReel");
            if (ModelState.IsValid)
            {
                unitOfWork.SeanceRepository.GetSeanceByID(rendezVou.RendezVouID).PhotographeID = PhotographeID;
                unitOfWork.RendezVousRepository.InsertRendezVous(rendezVou);
                unitOfWork.Save();
                return RedirectToAction("Index", "Seances");
            }

            return Create(rendezVou.RendezVouID); ;
        }

        // GET: RendezVous/Reporter/5
        public ActionResult Reporter(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendezVou rendezVou = unitOfWork.RendezVousRepository.GetByID(id);
            if (rendezVou == null)
            {
                return HttpNotFound();
            }
            //ViewBag.RendezVouID = new SelectList(db.Seances, "SeanceID", "StatusSeance", rendezVou.RendezVouID);
            return View(rendezVou);
        }

        // POST: RendezVous/Reporter/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reporter([Bind(Include = "DateHeureRendezVous,Commentaire,RendezVouID")] RendezVou rendezVou)
        {
            ModelState.Remove("NbPhotoReel");
            ModelState.Remove("DureeRendezVousReel");

            if (ModelState.IsValid)
            {               

                unitOfWork.RendezVousRepository.UpdateRendezVou(rendezVou);
                unitOfWork.Save();
                return RedirectToAction("Index", "Seances");
            }
            return View(rendezVou);
        }

        // GET: RendezVous/Terminer/5
        public ActionResult Suivi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendezVou rendezVou = unitOfWork.RendezVousRepository.GetByID(id);
            if (rendezVou == null)
            {
                return HttpNotFound();
            }
            return View(rendezVou);
        }

        // POST: RendezVous/Terminer/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Suivi([Bind(Include = "NbPhotoReel,DureeRendezVousReel,Commentaire,RendezVouID, DateHeureRendezVous")] RendezVou rendezVou)
        {
            ModelState.Remove("DateHeureRendezVous");
            if (ModelState.IsValid)
            {
                rendezVou.Completee = true;
                
                unitOfWork.RendezVousRepository.UpdateRendezVou(rendezVou);
                unitOfWork.Save();
                return RedirectToAction("Index", "Seances");
            }
            return View(rendezVou);
        }

        // GET: RendezVous/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RendezVou rendezVou = unitOfWork.RendezVousRepository.GetByID(id);
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
            RendezVou rendezVou = unitOfWork.RendezVousRepository.GetByID(id);
            unitOfWork.RendezVousRepository.DeleteRendezVou(id);
            return RedirectToAction("Index", "Seances");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
