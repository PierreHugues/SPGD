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
using SPGD.ViewModel;

namespace SPGD.Controllers
{
    public class SeancesController : Controller
    {
        //private H15_PROJET_E09Entities1 db = new H15_PROJET_E09Entities1();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Seances
        public ActionResult Index()
        {
<<<<<<< HEAD

            var viewModel = new SeanceData();

                viewModel.seancesSansRDV = unitOfWork.SeanceRepository.GetSeancesSansRDV();
                viewModel.seancesAvecRDV = unitOfWork.SeanceRepository.GetSeancesRDV();
=======
            var viewModel = new SeanceData();

            viewModel.seancesSansRDV = unitOfWork.SeanceRepository.GetSeancesSansRDV();
            viewModel.seancesAvecRDV = unitOfWork.SeanceRepository.GetSeancesRDV();
>>>>>>> origin/master

            return View(viewModel);
        }

        // GET: Seances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            DateTime dateCourante = DateTime.Now;
            string format = "yyyy-MM-dd hh:mm:ss";
            ViewBag.Datecourante = dateCourante.ToString(format);
            //ViewBag.SeanceID = new SelectList(db.RendezVous, "RendezVouID", "Commentaire");


            //ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "LastName");
            var agentquery = unitOfWork.AgentRepository.GetAgents();
            ViewBag.AgentID = new SelectList(agentquery, "AgentID", "Nom");

            return View();
        }

        // POST: Seances/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeanceID,AgentID,MaisonID,StatusSeance,TypeForfaitDeBaseVoulu,NbPanoramasVoulu,VisiteImmersive,FraisDeBaseReel,FraisDeDeplacement,Commentaire,FraisAdditionnel,DateDebutDeSeance,DateRemisePhoto,DateRemisePanoramas,DateDePaymentRecu,FraisPanoramas,FraisVisiteImmersive,FraisSeanceTotal")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SeanceRepository.InsertSeance(seance);

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
        public ActionResult Edit([Bind(Include = "SeanceID,AgentID,MaisonID,StatusSeance,TypeForfaitDeBaseVoulu,NbPanoramasVoulu,VisiteImmersive,FraisDeBaseReel,FraisDeDeplacement,Commentaire,FraisAdditionnel,DateDebutDeSeance,DateRemisePhoto,DateRemisePanoramas,DateDePaymentRecu,FraisPanoramas,FraisVisiteImmersive,FraisSeanceTotal")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SeanceRepository.UpdateSeance(seance);

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

            unitOfWork.SeanceRepository.DeleteSeance(id);

            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
