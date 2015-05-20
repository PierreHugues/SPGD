using System;
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
    public class PhotographesController : Controller
    {
        //private H15_PROJET_E09Entities1 db = new H15_PROJET_E09Entities1();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Photographes
        public ActionResult Index(int? id)
        {
            var viewModel = new PhotographeData();

            viewModel.Photographes = unitOfWork.PhotographeRepository.GetPhotographes();

            if (id != null)
            {
                //Garder le nom prénom du photographe pour l'affichage dans la vue
                ViewBag.SelectedPhotographePrenom = unitOfWork.PhotographeRepository.GetPhotographeByID(id).Prenom;
                ViewBag.SelectedPhotographeNom = unitOfWork.PhotographeRepository.GetPhotographeByID(id).Nom;

                //Obtenir les seances du photographe
                viewModel.Seances = unitOfWork.PhotographeRepository.GetSeancesSelonPhotographe(id.Value);
            }

            return View(viewModel);
        }

        // GET: Photographes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photographe photographe = unitOfWork.PhotographeRepository.GetPhotographeByID(id);

            if (photographe == null)
            {
                return HttpNotFound();
            }
            return View(photographe);
        }

        // GET: Photographes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photographes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhotographeID,Nom,Prenom,Telephone1,Telephone2,Courriel1,Courriel2")] Photographe photographe)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PhotographeRepository.InsertPhotographe(photographe);

                unitOfWork.Save();
                
                return RedirectToAction("Index");
            }

            return View(photographe);
        }

        // GET: Photographes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photographe photographe = unitOfWork.PhotographeRepository.GetPhotographeByID(id);

            if (photographe == null)
            {
                return HttpNotFound();
            }
            return View(photographe);
        }

        // POST: Photographes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotographeID,Nom,Prenom,Telephone1,Telephone2,Courriel1,Courriel2")] Photographe photographe)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(photographe);
        }

        // GET: Photographes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photographe photographe = unitOfWork.PhotographeRepository.GetPhotographeByID(id);

            if (photographe == null)
            {
                return HttpNotFound();
            }
            return View(photographe);
        }

        // POST: Photographes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.PhotographeRepository.DeletePhotographe(id);
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
