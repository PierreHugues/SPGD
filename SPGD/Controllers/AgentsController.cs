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

namespace SPGD.Controllers
{
    public class AgentsController : Controller
    {
        //private H15_PROJET_E09Entities1 db = new H15_PROJET_E09Entities1();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Agents
        public ActionResult Index()
        {
            var agents = unitOfWork.AgentRepository.GetAgents();
            return View(agents);
        }

        // GET: Agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Agent agent = db.Agents.Find(id);
            Agent agent = unitOfWork.AgentRepository.GetAgentByID(id);

            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgentID,Nom,Prenom,Telephone1,Telephone2,Courriel1,Courriel2,AdresseBureau")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                //db.Agents.Add(agent);
                unitOfWork.AgentRepository.InsertAgent(agent);

                //db.SaveChanges();
                unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(agent);
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Agent agent = db.Agents.Find(id);
            Agent agent = unitOfWork.AgentRepository.GetAgentByID(id);

            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgentID,Nom,Prenom,Telephone1,Telephone2,Courriel1,Courriel2,AdresseBureau")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(agent).State = EntityState.Modified;
                unitOfWork.AgentRepository.UpdateAgent(agent);
                //db.SaveChanges();
                unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(agent);
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Agent agent = db.Agents.Find(id);
            Agent agent = unitOfWork.AgentRepository.GetAgentByID(id);

            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Agent agent = db.Agents.Find(id);

            //db.Agents.Remove(agent);
            unitOfWork.AgentRepository.DeleteAgent(id);

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
