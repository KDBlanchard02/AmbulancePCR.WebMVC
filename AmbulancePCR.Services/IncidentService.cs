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
    }
}
