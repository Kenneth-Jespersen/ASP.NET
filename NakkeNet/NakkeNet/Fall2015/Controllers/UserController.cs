using NakkeNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NakkeNet.Repositories;
using NakkeNet.ViewModels;

namespace NakkeNet.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersRepository usersRepository;
        private readonly ICompetencyHeadersRepository competencyHeadersRepository;
        private readonly IEmailer _emailer; 

        public UsersController(IUsersRepository usersRepository, ICompetencyHeadersRepository competencyHeadersRepository, IEmailer emailer)
        {
            this.usersRepository = usersRepository;
            this.competencyHeadersRepository = competencyHeadersRepository; 
            _emailer = emailer;
        }

        public ActionResult GridExample()
        {
            return View();
        }

        //[AllowAnonymous]
        [Authorize(Roles= "Admin")]
        public ActionResult Index(string search="")
        {

            UserIndexViewModel sivm = new UserIndexViewModel
            {
                Users = usersRepository.All.ToList(),
                CompetencyHeaders = competencyHeadersRepository.AllIncluding(a => a.Competencies).ToList()
            };

            return View(sivm);
        }

        [HttpGet]
        public ActionResult Edit(int userId)
        {
            //look up a user in the db
            User user = usersRepository.Find(userId);
            CreateEditUserViewModel createView = new CreateEditUserViewModel();
            CompetenciesRepository compRepo = new CompetenciesRepository();
            CompetencyHeadersRepository headRepo = new CompetencyHeadersRepository();

            createView.User = user; 

            return View(createView);
        }
        [HttpPost]
        public ActionResult Edit(User user, HttpPostedFileBase image)
        {
            //if you edit user
            if (ModelState.IsValid)
            {
                usersRepository.InsertOrUpdate(user);
                user.SaveImage(image, Server.MapPath("~"), "/ProfileImages/");
                usersRepository.Save(); 
                return RedirectToAction("Index");
            }
            return View();
        }
   
        public ActionResult Details(int userId)
        {
            User user = usersRepository.Find(userId);
            return View(user);
        }

        [HttpGet]
        //[Authorize](Roles="Admin")
        public ActionResult Create()
        {


            CreateEditUserViewModel vm = new CreateEditUserViewModel
                {
                    User = new User(),
                    CompetencyHeaders = 
                    competencyHeadersRepository.AllIncluding(
                        a => a.Competencies).ToList()
                };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(User user,
            HttpPostedFileBase image, IEnumerable<int> compIds)
        {
            if (ModelState.IsValid)
            {
                usersRepository.InsertOrUpdate(user);

                string path = Server != null ? Server.MapPath("~") : "";

                user.SaveImage(image, path, "/ProfileImages/");
                usersRepository.Save();
                _emailer.Send("Welcome to our website...");
                return View("Thanks");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(User user1, int userId)
        {
            User user = usersRepository.Find(userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int userId)
        {

            usersRepository.Delete(userId);
            return RedirectToAction("Index"); 
        }
    }
}
















