﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPGD;
using SPGD.DAL;
using SPGD.Models;

namespace SPGD.Controllers
{
    public class SeancesController : Controller
    {
        //private H15_PROJET_E09Entities db = new H15_PROJET_E09Entities();
        
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Seances
        public ActionResult Index()
        {
            //return View(db.Seances.ToList());
            return View(unitOfWork.SeanceRepository.GetSeances());
        }

        // GET: Seances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Seance seance = db.Seances.Find(id);
            Seance seance = unitOfWork.SeanceRepository.GetSeanceByID(id);


            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        // GET: Seances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seances/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeanceID,AgentID,MaisonID,StatusSeance,TypeForfaitDeBaseVoulu,NbPanoramasVoulu,VisiteImmersive,Commentaire")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                seance.DateDebutDeSeance = DateTime.Now;

                //db.Seances.Add(seance);
                unitOfWork.SeanceRepository.InsertSeance(seance);

                //db.SaveChanges();
                unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(seance);
        }

        // GET: Seances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Seance seance = db.Seances.Find(id);
            Seance seance = unitOfWork.SeanceRepository.GetSeanceByID(id);

            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        // POST: Seances/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeanceID,MaisonID,StatusSeance,TypeForfaitDeBaseVoulu,NbPanoramasVoulu,VisiteImmersive,Commentaire")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                //**********************
                //db.Entry(seance).State = EntityState.Modified;
                unitOfWork.SeanceRepository.UpdateSeance(seance);


                //db.SaveChanges();
                unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(seance);
        }

        // GET: Seances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Seance seance = db.Seances.Find(id);
            Seance seance = unitOfWork.SeanceRepository.GetSeanceByID(id);

            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        // POST: Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Seance seance = db.Seances.Find(id);
            //Seance seance = unitOfWork.SeanceRepository.GetSeanceByID(id);

            //**Pas besoin de get la seanceByID avant
            //db.Seances.Remove(seance);
            unitOfWork.SeanceRepository.DeleteSeance(id);

            //unitOfWork.SeanceRepository.Delete(seance);

            //db.SaveChanges();
            unitOfWork.Save();

            return RedirectToAction("Index");
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