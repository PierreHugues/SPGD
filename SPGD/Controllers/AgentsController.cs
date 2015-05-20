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
using PagedList;

namespace SPGD.Controllers
{
    public class AgentsController : Controller
    {
        //private H15_PROJET_E09Entities1 db = new H15_PROJET_E09Entities1();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Agents
        public ActionResult Index(int? page)
        {
<<<<<<< HEAD
            var viewModel = new AgentData();

            viewModel.Agents = unitOfWork.AgentRepository.GetAgents();

            if(id != null)
            {
                ViewBag.SelectedAgentNom = unitOfWork.AgentRepository.GetAgentByID(id).Prenom;
                ViewBag.SelectedAgentNom = unitOfWork.AgentRepository.GetAgentByID(id).Nom;
            }

            return View(viewModel);
=======
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(unitOfWork.AgentRepository.GetAgents().ToPagedList(pageNumber, pageSize));
>>>>>>> origin/master
        }

        // GET: Agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = unitOfWork.AgentRepository.GetAgentByID(id);


            var viewModel = new SeanceData();

            if (id != null)
            {
                ViewBag.SelectedAgentPrenom = unitOfWork.AgentRepository.GetAgentByID(id).Prenom;
                ViewBag.SelectedAgentNom = unitOfWork.AgentRepository.GetAgentByID(id).Nom;

                //Obtenir les seances de l'agent selectionné
                viewModel.seancesSansRDV = unitOfWork.AgentRepository.GetSeancesDerniereAnnéeSelonAgent(id.Value).Where(s=>s.RendezVou == null);
                viewModel.seancesAvecRDV = unitOfWork.AgentRepository.GetSeancesDerniereAnnéeSelonAgent(id.Value).Where(s=>s.RendezVou != null);
            }


            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
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
                unitOfWork.AgentRepository.InsertAgent(agent);
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
                unitOfWork.AgentRepository.UpdateAgent(agent);
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
            unitOfWork.AgentRepository.DeleteAgent(id);
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
