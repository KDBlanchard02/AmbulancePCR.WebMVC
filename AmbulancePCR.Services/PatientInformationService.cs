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

        
    }
}
