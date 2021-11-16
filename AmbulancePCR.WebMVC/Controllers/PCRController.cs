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
    public class PCRController : Controller
    {
        private readonly IPCRService _service;

        public PCRController(IPCRService service)
        {
            _service = service;
        }
        // GET: PCR
        public ActionResult Index()
        {
            var model = _service.GetPCRs(User.Identity.GetUserId());
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
            try
            {
                if (!ModelState.IsValid) { return View(model); }

                model.UserId = User.Identity.GetUserId();

                if (_service.CreatePCR(model))
                {
                    TempData["SaveResult"] = "Your PCR was created.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "PCR could not be created.");

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
            var model = _service.GetPCRById(id, User.Identity.GetUserId());

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = _service.GetPCRById(id, User.Identity.GetUserId());
            var model =
                new PCREdit
                {
                    IncidentNumber = detail.IncidentNumber,
                    Disposition = detail.Disposition,
                    SceneAddress = detail.SceneAddress,
                    CmsLevel = detail.CmsLevel,
                    VehicleNumber = detail.VehicleNumber,
                    IncidentDate = detail.IncidentDate,

                    UnitNotified = detail.UnitNotified,
                    EnRoute = detail.EnRoute,
                    OnScene = detail.OnScene,
                    Transporting = detail.Transporting,
                    Destination = detail.Destination,
                    InService = detail.InService,

                    LoadMileage = detail.LoadMileage,
                    PrimaryCareProvider = detail.PrimaryCareProvider,
                    AmbulanceDriver = detail.AmbulanceDriver,

                    PCRNarrative = detail.PCRNarrative,
                    ReportingCrewMember = detail.PrimaryCareProvider,

                    DestinationAddress = detail.DestinationAddress,
                    Reason = detail.Reason,
                    Type = detail.Type,
                    PtPosition = detail.PtPosition,

                    PrimarySymptom = detail.PrimarySymptom,
                    PrimaryImpression = detail.PrimaryImpression,
                    SecondaryImpression = detail.SecondaryImpression,
                    AlcDrugUse = detail.AlcDrugUse,

                    PtFirstName = detail.PtFirstName,
                    PtLastName = detail.PtLastName,
                    PtAge = detail.PtAge,
                    PtDateOfBirth = detail.PtDateOfBirth,
                    PtGender = detail.PtGender,
                    PtWeight = detail.PtWeight,
                    PatientAddress = detail.PatientAddress,
                    PtPhoneNumber = detail.PtPhoneNumber,
                    PtSSN = detail.PtSSN,
                    PtHistory = detail.PtHistory,
                    PtAllergiesMeds = detail.PtAllergiesMeds,
                    PtAllergiesOther = detail.PtAllergiesOther,
                    PtAdvanceDirectives = detail.PtAdvanceDirectives,
                    PtMedications = detail.PtMedications,

                    SystolicBloodPressure = detail.SystolicBloodPressure,
                    DiastolicBloodPressure = detail.DiastolicBloodPressure,
                    HeartRate = detail.HeartRate,
                    RespiratoryRate = detail.RespiratoryRate,
                    RespEffort = detail.RespEffort,
                    Rhythm = detail.Rhythm,
                    BPMethod = detail.BPMethod,
                    HRType = detail.HRType,
                    Oximetry = detail.Oximetry,
                    GCSVerbal = detail.GCSVerbal,
                    GCSMotor = detail.GCSMotor,
                    GCSEyes = detail.GCSEyes,
                    BloodGlucose = detail.BloodGlucose,
                    Temperature = detail.Temperature,
                    VitalSignsTime = detail.VitalSignsTime,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PCREdit model)
        {
            try
            {
                if (!ModelState.IsValid) { return View(model); }

                model.PatientCareReportId = id;
                model.UserId = User.Identity.GetUserId();

                if (_service.UpdatePCR(model))
                {
                    TempData["SaveResult"] = "Your PCR was updated.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Your PCR could not be updated.");
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
            var model = _service.GetPCRById(id, User.Identity.GetUserId());

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePCR(int id)
        {

            _service.DeleteIncident(id, User.Identity.GetUserId());

            TempData["SaveResult"] = "Your PCR was deleted.";
            return RedirectToAction("Index");
        }
    }
}