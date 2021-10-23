using AmbulancePCR.Data;
using AmbulancePCR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Services
{
    public class PatientInformationService
    {
        private readonly Guid _userId;

        public PatientInformationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePtInformation(PtInformationCreate model)
        {
            var entity =
                new PatientInformation()
                {
                    IncidentNumber = model.Incident.IncidentNumber,
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

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PatientInformation.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdatePtInformation(PtInformationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PatientInformation
                        .Single(e => e.IncidentNumber == model.IncidentNumber);

                entity.IncidentNumber = model.Incident.IncidentNumber;
                entity.PtFirstName = model.PtFirstName;
                entity.PtLastName = model.PtLastName;
                entity.PtAge = model.PtAge;
                entity.PtDateOfBirth = model.PtDateOfBirth;
                entity.PtGender = model.PtGender;
                entity.PtWeight = model.PtWeight;
                entity.PatientAddress = model.PatientAddress;
                entity.PtPhoneNumber = model.PtPhoneNumber;
                entity.PtSSN = model.PtSSN;
                entity.PtHistory = model.PtHistory;
                entity.PtAllergiesMeds = model.PtAllergiesMeds;
                entity.PtAllergiesOther = model.PtAllergiesOther;
                entity.PtAdvanceDirectives = model.PtAdvanceDirectives;
                entity.PtMedications = model.PtMedications;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePtInformation(int incidentNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PatientInformation
                        .Single(e => e.IncidentNumber == incidentNumber);


                ctx.PatientInformation.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
