using AmbulancePCR.Data;
using AmbulancePCR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Services
{
    public class IncidentService
    {
        private readonly Guid _userId;

        public IncidentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateIncident(IncidentCreate model)
        {
            var entity =
                new Incident()
                {
                    AuthorID = _userId,
                    IncidentNumber = model.IncidentNumber,
                    Disposition = model.Disposition,
                    SceneAddress = model.SceneAddress,
                    CmsLevel = model.CmsLevel,
                    VehicleNumber = model.VehicleNumber,
                    IncidentDate = model.IncidentDate,

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

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Incidents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IncidentListItem> GetIncidents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var incidentNum = from c in ctx.Incidents select c.IncidentNumber;
                var pt = (from x in ctx.PatientInformation where x.IncidentNumber.Equals(incidentNum) select x.PtLastName).ToString();

                var query =
                    ctx
                    .Incidents
                    .Where(e => e.AuthorID == _userId)
                    .Select(
                        e =>
                        new IncidentListItem
                        {
                            IncidentNumber = e.IncidentNumber,
                            AuthorID = e.AuthorID,
                            IncidentDate = e.IncidentDate,
                            PtLastName = pt,
                            PrimaryCareProvider = e.PrimaryCareProvider
                        }
                        );
                return query.ToArray();
            }
        }

        public IncidentDetail GetIncidentbyNumber(int incidentNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Incidents
                        .Single(e => e.IncidentNumber == incidentNumber && e.AuthorID == _userId);

                return
                    new IncidentDetail
                    {
                        IncidentNumber = entity.IncidentNumber,
                        Disposition = entity.Disposition,
                        SceneAddress = entity.SceneAddress,
                        CmsLevel = entity.CmsLevel,
                        VehicleNumber = entity.VehicleNumber,
                        IncidentDate = entity.IncidentDate,

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
                        AlcDrugUse = entity.AlcDrugUse
                    };
            }
        }

        public bool UpdateIncident(IncidentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Incidents
                        .Single(e => e.IncidentNumber == model.IncidentNumber);

                entity.Disposition = model.Disposition;
                entity.SceneAddress = model.SceneAddress;
                entity.CmsLevel = model.CmsLevel;
                entity.VehicleNumber = model.VehicleNumber;
                entity.IncidentDate = model.IncidentDate;
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

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIncident(int incidentNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Incidents
                        .Single(e => e.IncidentNumber == incidentNumber && e.AuthorID == _userId);
                
                var vitals =
                    ctx
                    .Vitals
                    .Where(v => v.IncidentNumber == incidentNumber);

                var pt =
                    ctx
                    .PatientInformation
                    .Where(p => p.IncidentNumber == incidentNumber);

                ctx.Incidents.Remove(entity);
                ctx.Vitals.Remove((Vitals)vitals);
                ctx.PatientInformation.Remove((PatientInformation)pt);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
