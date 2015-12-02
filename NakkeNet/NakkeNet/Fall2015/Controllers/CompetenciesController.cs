using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NakkeNet.Models;
using NakkeNet.Repositories;

namespace NakkeNet.Controllers
{
    public class CompetenciesController : Controller
    {
        private readonly ICompetenciesRepository competenciesRepository;
        private readonly ICompetencyHeadersRepository competencyHeadersRepository;

        public CompetenciesController(ICompetenciesRepository competenciesRepository,
            ICompetencyHeadersRepository competencyHeadersRepository)
        {
            this.competenciesRepository = competenciesRepository;
            this.competencyHeadersRepository = competencyHeadersRepository; 
        }
        // GET: Competencies
        public ActionResult Index()
        {
            var competencies = competenciesRepository.All.Include(c => c.CompetencyHeader);
            return View(competencies.ToList());
        }

        // GET: Competencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = competenciesRepository.Find(id.Value);
            if (competency == null)
            {
                return HttpNotFound();
            }
            return View(competency);
        }

        // GET: Competencies/Create
        public ActionResult Create()
        {
            ViewBag.CompetencyHeaderId = new SelectList(competencyHeadersRepository.All, "CompetencyHeaderId", "Name");
            return View();
        }

        // POST: Competencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Competency competency)
        {
            if (ModelState.IsValid)
            {
                competenciesRepository.InsertOrUpdate(competency);
                competenciesRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
            /*var competencyName = competencyHeadersRepository.All.FirstOrDefault(x => x.Name == competencyHeaderName);
            
            Competency competency = new Competency {Name = name , CompetencyHeaderId = competencyName.CompetencyHeaderId};
            ViewBag.CompetencyHeaderId = new SelectList(competenciesRepository.All, "CompetencyHeaderId", "Name", competency);
            return Json(competency);
            */
          
        }

        // GET: Competencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = competenciesRepository.Find(id.Value);
            if (competency == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetencyHeaderId =
                new SelectList(competencyHeadersRepository.All,
                "CompetencyHeaderId", "Name",
                competency.CompetencyHeaderId);

            return View(competency);
        }

        // POST: Competencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyId,Name,CompetencyHeaderId")] Competency competency)
        {
            if (ModelState.IsValid)
            {
                competenciesRepository.InsertOrUpdate(competency);
                competenciesRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CompetencyHeaderId = new SelectList(competencyHeadersRepository.All, "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);
            return View(competency);
        }

        // GET: Competencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = competenciesRepository.Find(id.Value);
            if (competency == null)
            {
                return HttpNotFound();
            }
            return View(competency);
        }

        // POST: Competencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Competency competency = competenciesRepository.Find(id);
            competenciesRepository.Delete(id);
            competenciesRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
