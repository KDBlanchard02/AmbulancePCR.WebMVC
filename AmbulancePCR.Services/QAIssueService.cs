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
                    AuthorID = _userId,
                    IncidentNumber = model.IncidentNumber,
                    DateCreated = DateTimeOffset.Now,
                    Note = model.Note,
                    SupervisorName = model.SupervisorName,
                    IsResolved = false
                };

            using (ctx)
            {
                ctx.Issues.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<QAIssueListItem> GetQAIssues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Issues
                    .Where(e => e.AuthorID == _userId)
                    .Select(
                        e =>
                        new QAIssueListItem
                        {
                            IncidentNumber = e.IncidentNumber,
                            IsResolved = e.IsResolved,
                            DateCreated = e.DateCreated,
                            SupervisorName = e.SupervisorName
                        }
                        );
                return query.ToArray();
            }
        }

        public QAIssueDetail GetQAIssueById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Issues
                        .Single(e => e.IssueID == id && e.AuthorID == _userId);
                var incident =
                    ctx
                    .Incidents
                    .First(i => i.IncidentNumber == entity.IncidentNumber);

                var patient =
                    ctx
                    .PatientInformation
                    .First(p => p.IncidentNumber == entity.IncidentNumber);

                return
                    new QAIssueDetail
                    {
                        IssueID = entity.IssueID,
                        IncidentNumber = entity.IncidentNumber,
                        Note = entity.Note,
                        PrimaryCareProvider = incident.PrimaryCareProvider,
                        PtLastName = patient.PtLastName,
                        IsResolved = entity.IsResolved,
                        SupervisorName = entity.SupervisorName,
                        DateCreated = entity.DateCreated,
                        DateModified = entity.DateModified
                    };
            }
        }

        public bool UpdateQAIssue(QAIssueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Issues.Single(e => e.IssueID == model.IssueID && e.AuthorID == _userId);
                entity.Note = model.Note;
                entity.IsResolved = model.IsResolved;
                entity.DateModified = DateTime.Now;
                return ctx.SaveChanges() == 1;
            };
        }

        public bool DeleteIncident(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Issues
                        .Single(e => e.IssueID == id && e.AuthorID == _userId);

                ctx.Issues.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
        