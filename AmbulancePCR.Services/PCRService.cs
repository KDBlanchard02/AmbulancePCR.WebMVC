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
                new Incident()
                {
                    DateCreated = DateTime.Now,
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
                    PrimaryCareProvider = model.PrimaryCareProvider,
                    AmbulanceDriver = model.AmbulanceDriver,

                    PCRNarrative = model.PCRNarrative,
                    ReportingCrewMember = model.PrimaryCareProvider,

                    DestinationAddress = model.DestinationAddress,
                    Reason = model.Reason,
                    Type = model.Type,
                    PtPosition = model.PtPosition,

                    PrimarySymptom = model.PrimarySymptom,
                    PrimaryImpression = model.PrimaryImpression,
                    SecondaryImpression = model.SecondaryImpression,
                    AlcDrugUse = model.AlcDrugUse
                };

            var ptinfo =
                new PatientInformation()
                {
                    IncidentNumber = model.IncidentNumber,
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
                    PtAllergiesMeds = model.PtAllergiesMeds,
                    PtAllergiesOther = model.PtAllergiesOther,
                    PtAdvanceDirectives = model.PtAdvanceDirectives,
                    PtMedications = model.PtMedications
                };

            var vitals =
                new Vitals()
                {
                    IncidentNumber = model.IncidentNumber,
                    SystolicBloodPressure = model.SystolicBloodPressure,
                    DiastolicBloodPressure = model.DiastolicBloodPressure,
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
                    BloodGlucose = model.BloodGlucose,
                    Temperature = model.Temperature,
                    VitalSignsTime = model.VitalSignsTime
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Incidents.Add(entity);
                ctx.PatientInformation.Add(ptinfo);
                ctx.Vitals.Add(vitals);
                return ctx.SaveChanges() == 3;
            }
        }

        public IEnumerable<PCRListItem> GetPCRs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Incidents
                    .Where(e => e.AuthorID == _userId)
                    .Select(
                        e =>
                        new PCRListItem
                        {
                            IncidentNumber = e.IncidentNumber,
                            IncidentDate = e.IncidentDate,
                            PatientCareReportId = e.PatientCareReportId,
                            PrimaryCareProvider = e.PrimaryCareProvider
                        }
                        );
                return query.ToArray();
            }
        }

        public PCRDetail GetPCRById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Incidents
                        .Single(e => e.PatientCareReportId == id && e.AuthorID == _userId);

                var ptinfo =
                    ctx
                        .PatientInformation
                        .First(p => p.IncidentNumber == entity.IncidentNumber);

                var vitals =
                    ctx
                        .Vitals
                        .First(v => v.IncidentNumber == entity.IncidentNumber);

                return
                    new PCRDetail
                    {
                        DateCreated = entity.DateCreated,
                        DateModified = entity.DateModified,
                        IncidentNumber = entity.IncidentNumber,
                        Disposition = entity.Disposition,
                        SceneAddress = entity.SceneAddress,
                        CmsLevel = entity.CmsLevel,
                        VehicleNumber = entity.VehicleNumber,
                        IncidentDate = entity.IncidentDate,

                        UnitNotified = entity.UnitNotified,
                        EnRoute = entity.EnRoute,
                        OnScene = entity.OnScene,
                        Transporting = entity.Transporting,
                        Destination = entity.Destination,
                        InService = entity.InService,

                        LoadMileage = entity.LoadMileage,
                        PrimaryCareProvider = entity.PrimaryCareProvider,
                        AmbulanceDriver = entity.AmbulanceDriver,

                        PCRNarrative = entity.PCRNarrative,
                        ReportingCrewMember = entity.PrimaryCareProvider,

                        DestinationAddress = entity.DestinationAddress,
                        Reason = entity.Reason,
                        Type = entity.Type,
                        PtPosition = entity.PtPosition,

                        PrimarySymptom = entity.PrimarySymptom,
                        PrimaryImpression = entity.PrimaryImpression,
                        SecondaryImpression = entity.SecondaryImpression,
                        AlcDrugUse = entity.AlcDrugUse,

                        PtFirstName = ptinfo.PtFirstName,
                        PtLastName = ptinfo.PtLastName,
                        PtAge = ptinfo.PtAge,
                        PtDateOfBirth = ptinfo.PtDateOfBirth,
                        PtGender = ptinfo.PtGender,
                        PtWeight = ptinfo.PtWeight,
                        PatientAddress = ptinfo.PatientAddress,
                        PtPhoneNumber = ptinfo.PtPhoneNumber,
                        PtSSN = ptinfo.PtSSN,
                        PtHistory = ptinfo.PtHistory,
                        PtAllergiesMeds = ptinfo.PtAllergiesMeds,
                        PtAllergiesOther = ptinfo.PtAllergiesOther,
                        PtAdvanceDirectives = ptinfo.PtAdvanceDirectives,
                        PtMedications = ptinfo.PtMedications,

                        SystolicBloodPressure = vitals.SystolicBloodPressure,
                        DiastolicBloodPressure = vitals.DiastolicBloodPressure,
                        MeanPressure = vitals.MeanPressure,
                        HeartRate = vitals.HeartRate,
                        RespiratoryRate = vitals.RespiratoryRate,
                        RespEffort = vitals.RespEffort,
                        Rhythm = vitals.Rhythm,
                        BPMethod = vitals.BPMethod,
                        HRType = vitals.HRType,
                        Oximetry = vitals.Oximetry,
                        GCSVerbal = vitals.GCSVerbal,
                        GCSMotor = vitals.GCSMotor,
                        GCSEyes = vitals.GCSEyes,
                        GCSTotal = vitals.GCSTotal,
                        BloodGlucose = vitals.BloodGlucose,
                        Temperature = vitals.Temperature,
                        VitalSignsTime = vitals.VitalSignsTime,
                    };
            }
        }

        public bool UpdatePCR(PCREdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Incidents.Single(e => e.PatientCareReportId == model.PatientCareReportId && e.AuthorID == _userId);

                var ptinfo =
                    ctx
                        .PatientInformation
                        .FirstOrDefault(p => p.IncidentNumber == entity.IncidentNumber);

                var vitals =
                    ctx
                        .Vitals
                        .FirstOrDefault(v => v.IncidentNumber == entity.IncidentNumber);

                entity.DateModified = DateTime.Now;
                entity.IncidentNumber = model.IncidentNumber;
                entity.Disposition = model.Disposition;
                entity.SceneAddress = model.SceneAddress;
                entity.CmsLevel = model.CmsLevel;
                entity.VehicleNumber = model.VehicleNumber;
                entity.IncidentDate = model.IncidentDate;
                entity.UnitNotified = model.UnitNotified;
                entity.EnRoute = model.EnRoute;
                entity.OnScene = model.OnScene;
                entity.Transporting = model.Transporting;
                entity.Destination = model.Destination;
                entity.InService = model.InService;
                entity.PrimaryCareProvider = model.PrimaryCareProvider;
                entity.AmbulanceDriver = model.AmbulanceDriver;
                entity.LoadMileage = model.LoadMileage;
                entity.DestinationAddress = model.DestinationAddress;
                entity.Reason = model.Reason;
                entity.Type = model.Type;
                entity.PtPosition = model.PtPosition;
                entity.PrimarySymptom = model.PrimarySymptom;
                entity.PrimaryImpression = model.PrimaryImpression;
                entity.SecondaryImpression = model.SecondaryImpression;
                entity.AlcDrugUse = model.AlcDrugUse;
                entity.PCRNarrative = model.PCRNarrative;
                entity.ReportingCrewMember = model.PrimaryCareProvider;

                ptinfo.IncidentNumber = model.IncidentNumber;
                ptinfo.PtFirstName = model.PtFirstName;
                ptinfo.PtLastName = model.PtLastName;
                ptinfo.PtAge = model.PtAge;
                ptinfo.PtDateOfBirth = model.PtDateOfBirth;
                ptinfo.PtGender = model.PtGender;
                ptinfo.PtWeight = model.PtWeight;
                ptinfo.PatientAddress = model.PatientAddress;
                ptinfo.PtPhoneNumber = model.PtPhoneNumber;
                ptinfo.PtSSN = model.PtSSN;
                ptinfo.PtHistory = model.PtHistory;
                ptinfo.PtAllergiesMeds = model.PtAllergiesMeds;
                ptinfo.PtAllergiesOther = model.PtAllergiesOther;
                ptinfo.PtAdvanceDirectives = model.PtAdvanceDirectives;
                ptinfo.PtMedications = model.PtMedications;

                vitals.IncidentNumber = model.IncidentNumber;
                vitals.SystolicBloodPressure = model.SystolicBloodPressure;
                vitals.DiastolicBloodPressure = model.DiastolicBloodPressure;
                vitals.HeartRate = model.HeartRate;
                vitals.RespiratoryRate = model.RespiratoryRate;
                vitals.RespEffort = model.RespEffort;
                vitals.Rhythm = model.Rhythm;
                vitals.BPMethod = model.BPMethod;
                vitals.HRType = model.HRType;
                vitals.Oximetry = model.Oximetry;
                vitals.GCSVerbal = model.GCSVerbal;
                vitals.GCSMotor = model.GCSMotor;
                vitals.GCSEyes = model.GCSEyes;
                vitals.BloodGlucose = model.BloodGlucose;
                vitals.Temperature = model.Temperature;
                vitals.VitalSignsTime = model.VitalSignsTime;

                return ctx.SaveChanges() == 3;
            }
        }

        public bool DeleteIncident(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Incidents
                        .Single(e => e.PatientCareReportId == id && e.AuthorID == _userId);
                
                var vitals =
                    ctx
                    .Vitals
                    .FirstOrDefault(v => v.IncidentNumber == entity.IncidentNumber);

                var pt =
                    ctx
                    .PatientInformation
                    .FirstOrDefault(p => p.IncidentNumber == entity.IncidentNumber);

                ctx.Incidents.Remove(entity);
                ctx.Vitals.Remove(vitals);
                ctx.PatientInformation.Remove(pt);

                return ctx.SaveChanges() == 3;
            }
        }
    }
}
