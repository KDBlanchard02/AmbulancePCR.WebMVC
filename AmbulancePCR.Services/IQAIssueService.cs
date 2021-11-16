using AmbulancePCR.Models;
using System.Collections.Generic;

namespace AmbulancePCR.Services
{
    public interface IQAIssueService
    {
        bool CreateQAIssue(QAIssueCreate model);
        bool DeleteQAIssue(int id, string userId);
        QAIssueDetail GetQAIssueById(int id, string userId);
        IEnumerable<QAIssueListItem> GetQAIssues(string userId);
        bool UpdateQAIssue(QAIssueEdit model);
    }
}