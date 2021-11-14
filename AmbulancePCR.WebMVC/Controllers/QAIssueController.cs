using AmbulancePCR.Data;
using AmbulancePCR.Models;
using AmbulancePCR.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmbulancePCR.WebMVC.Controllers
{
    [Authorize]
    public class QAIssueController : Controller
    {
        // GET: QAIssue
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new QAIssueService(userID);
            var model = service.GetQAIssues();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        private QAIssueService CreateQAIssueService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new QAIssueService(userId);
            return service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QAIssueCreate model)
        {
            try
            {
                if (!ModelState.IsValid) { return View(model); }

                var service = CreateQAIssueService();

                if (service.CreateQAIssue(model))
                {
                    TempData["SaveResult"] = "Q/A Issue was created.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Q/A Issue could not be created.");

                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "Missing required values.");
                return View(model);
            }
        }

        public ActionResult Details(int id)
        {
            var svc = CreateQAIssueService();
            var model = svc.GetQAIssueById(id);

            return View(model);
        }
    }
}