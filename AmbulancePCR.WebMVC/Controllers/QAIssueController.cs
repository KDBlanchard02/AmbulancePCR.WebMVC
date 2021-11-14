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

        public ActionResult Edit(int id)
        {
            var service = CreateQAIssueService();
            var detail = service.GetQAIssueById(id);
            var model =
                new QAIssueEdit
                {
                    Note = detail.Note,
                    IsResolved = detail.IsResolved,
                    IssueID = detail.IssueID
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, QAIssueEdit model)
        {
            try
            {
                if (!ModelState.IsValid) { return View(model); }

                model.IssueID = id;

                var service = CreateQAIssueService();

                if (service.UpdateQAIssue(model))
                {
                    TempData["SaveResult"] = "Issue has been updated.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Issue could not be updated.");
                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "Missing required values.");
                return View(model);
            }
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateQAIssueService();
            var model = svc.GetQAIssueById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIssue(int id)
        {
            var service = CreateQAIssueService();

            service.DeleteQAIssue(id);

            TempData["SaveResult"] = "Issue was deleted.";
            return RedirectToAction("Index");
        }
    }
}