using AmbulancePCR.Data;
using AmbulancePCR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Services
{
    public class VitalsService
    {
        private readonly Guid _userId;

        public VitalsService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateVitals(VitalsCreate model)
        {
            var entity =
                new Vitals()
                {
                    IncidentNumber = model.Incident.IncidentNumber,
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
                ctx.Vitals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
