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

using System.Security.AccessControl; //pour le controle des accès
using System.IO; //traitement des fichiers
using System.Configuration; //utiliser le Web.config

namespace SPGD.Controllers
{
    public class PhotosController : Controller
    {
        private H15_PROJET_E09Entities1 db = new H15_PROJET_E09Entities1();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Photos
        public ActionResult Index()
        {
            var photos = db.Photos.Include(p => p.Seance);
            return View(photos.ToList());
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Photo photo = db.Photos.Find(id);
            Photo photo = unitOfWork.PhotoRepository.GetPhotoByID(id);

            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create(int? id)
        {
            //ViewBag.SeanceID = new SelectList(db.Seances, "SeanceID", "StatusSeance");
            ViewBag.SeanceID = id;
            return View();
        }

        // POST: Photos/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PhotoID,SeanceID,PhotoPathName")] Photo photo)
        public ActionResult Create([Bind(Include = "SeanceID")] Photo photo, IEnumerable<HttpPostedFileBase> imageFile)
        {
            if (ModelState.IsValid)
            {
                //db.Photos.Add(photo);
                //unitOfWork.PhotoRepository.InsertPhoto(photo);

                //db.SaveChanges();
                unitOfWork.Save();

                return RedirectToAction("Index");
            }

            //ViewBag.SeanceID = new SelectList(db.Seances, "SeanceID", "StatusSeance", photo.SeanceID);
            return View(imageFile);
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Photo photo = db.Photos.Find(id);
            Photo photo = unitOfWork.PhotoRepository.GetPhotoByID(id);

            if (photo == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeanceID = new SelectList(db.Seances, "SeanceID", "StatusSeance", photo.SeanceID);
            return View(photo);
        }

        // POST: Photos/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoID,SeanceID,PhotoPathName")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(photo).State = EntityState.Modified;
                unitOfWork.PhotoRepository.UpdatePhoto(photo);

                //db.SaveChanges();
                unitOfWork.Save();

                return RedirectToAction("Index");
            }
            ViewBag.SeanceID = new SelectList(db.Seances, "SeanceID", "StatusSeance", photo.SeanceID);
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Photo photo = db.Photos.Find(id);
            Photo photo = unitOfWork.PhotoRepository.GetPhotoByID(id);

            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Photo photo = db.Photos.Find(id);
            //db.Photos.Remove(photo);
            unitOfWork.PhotoRepository.DeletePhoto(id);

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
