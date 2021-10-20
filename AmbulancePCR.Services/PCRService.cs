using AmbulancePCR.Data;
using AmbulancePCR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Services
{
    public class PCRService
    {
        private readonly Guid _userId;

        public PCRService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePCR(PCRCreate model)
        {
            var entity =
                new PatientCareReport()
                {
                    AuthorID = _userId,
                    IncidentNumber = model.IncidentNumber,
                    Disposition = model.Disposition,
                    SceneAddress = model.SceneAddress,
                    CmsLevel = model.CmsLevel,
                    VehicleNumber = model.VehicleNumber,
                    IncidentDate = model.IncidentDate,
                    UnitNotified = model.UnitNotified,
                    EnRoute = model.EnRoute,
                    OnScene = model.OnScene,
                    Transporting = model.Transporting,
                    Destination = model.Destination,
                    InService = model.InService,
                    LoadMileage = model.LoadMileage,
                    //PrimaryCareProvider = model.PrimaryCareProvider,
                    //AmbulanceDriver = model.AmbulanceDriver,

                    PtFirstName = model.PtFirstName,
                    PtLastName = model.PtLastName,
                    PtAge = model.PtAge,
                    PtDateOfBirth = model.PtDateOfBirth,
                    PtGender = model.PtGender,
                    PtWeight = model.PtWeight,
                    PatientAddress = model.PatientAddress,
                    PtPhoneNumber = model.PtPhoneNumber,
                    PtSSN = model.PtSSN,
                    PtHistory = model.PtHistory,
                    PtAdvanceDirectives = model.PtAdvanceDirectives,
                    PtAllergiesMeds = model.PtAllergiesMeds,
                    PtAllergiesOther = model.PtAllergiesOther,
                    PtMedications = model.PtMedications,

                    PCRNarrative = model.PCRNarrative,
                    //ReportingCrewMember = model.PrimaryCareProvider,

                    DestinationAddress = model.DestinationAddress,
                    Reason = model.Reason,
                    Type = model.Type,
                    PtPosition = model.PtPosition,

                    SystolicBloodPressure = model.SystolicBloodPressure,
                    DiastolicBloodPressure = model.DiastolicBloodPressure,
                    MeanPressure = ((model.SystolicBloodPressure + model.DiastolicBloodPressure)/2),
                    HeartRate = model.HeartRate,
                    RespiratoryRate = model.RespiratoryRate,
                    RespEffort = model.RespEffort,
                    Rhythm = model.Rhythm, 
                    BPMethod = model.BPMethod,
                    HRType = model.HRType,
                    Oximetry = model.Oximetry,
                    GCSVerbal = model.GCSVerbal,
                    GCSMotor = model.GCSMotor,
                    GCSEyes = model.GCSEyes,
                    GCSTotal = (model.GCSEyes + model.GCSMotor + model.GCSVerbal),
                    BloodGlucose = model.BloodGlucose,
                    Temperature = model.Temperature,
                    VitalSignsTime = model.VitalSignsTime,

                    PrimarySymptom = model.PrimarySymptom,
                    PrimaryImpression = model.PrimaryImpression,
                    SecondaryImpression = model.SecondaryImpression,
                    AlcDrugUse = model.AlcDrugUse
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PtCareReports.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PCRListItem> GetPCRs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .PtCareReports
                    .Where(e => e.AuthorID == _userId)
                    .Select(
                        e =>
                        new PCRListItem
                        {
                            IncidentNumber = e.IncidentNumber,
                            AuthorID = e.AuthorID,
                            IncidentDate = e.IncidentDate,
                            PtLastName = e.PtLastName,
                            //PrimaryCareProvider = e.PrimaryCareProvider
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
