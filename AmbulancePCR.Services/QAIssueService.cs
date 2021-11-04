using AmbulancePCR.Data;
using AmbulancePCR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Services
{
    public class QAIssueService
    {
        private readonly Guid _userId;

        public QAIssueService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateQAIssue(QAIssueCreate model)
        {
            var ctx = new ApplicationDbContext();

           

            var entity =
                new QAIssue()
                {
                    IncidentNumber = model.IncidentNumber,
                    DateCreated = DateTimeOffset.Now,
                    Note = model.Note,
                    //PtLastName = pt,
                    PrimaryCareProvider = model.Incident.PrimaryCareProvider
                };

            using (ctx)
            {
                ctx.Issues.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
