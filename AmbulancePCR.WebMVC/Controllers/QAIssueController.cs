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
        private readonly IQAIssueService _service;

        public QAIssueController(IQAIssueService service)
        {
            _service = service;
        }
        // GET: QAIssue
        public ActionResult Index()
        {
            var model = _service.GetQAIssues(User.Identity.GetUserId());
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QAIssueCreate model)
        {
            try
            {
                if (!ModelState.IsValid) { return View(model); }
                model.UserId = User.Identity.GetUserId();

                if (_service.CreateQAIssue(model))
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
            var model = _service.GetQAIssueById(id, User.Identity.GetUserId());

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = _service.GetQAIssueById(id, User.Identity.GetUserId());
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

                model.UserId = User.Identity.GetUserId();
                model.IssueID = id;

                if (_service.UpdateQAIssue(model))
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
            var model = _service.GetQAIssueById(id, User.Identity.GetUserId());

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIssue(int id)
        {
            _service.DeleteQAIssue(id, User.Identity.GetUserId());

            TempData["SaveResult"] = "Issue was deleted.";
            return RedirectToAction("Index");
        }
    }
}