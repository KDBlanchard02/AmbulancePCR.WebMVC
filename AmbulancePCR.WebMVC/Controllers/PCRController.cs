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
    public class PCRController : Controller
    {
        // GET: PCR
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PCRService(userID);
            var model = service.GetPCRs();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PCRCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePCRService();

            if (service.CreatePCR(model))
            {
                TempData["SaveResult"] = "Your PCR was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "PCR could not be created.");

            return View(model);
        }

        private PCRService CreatePCRService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PCRService(userId);
            return service;
        }
    }
}