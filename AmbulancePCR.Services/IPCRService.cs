using AmbulancePCR.Data;
using AmbulancePCR.Models;
using System.Collections.Generic;

namespace AmbulancePCR.Services
{
    public interface IPCRService
    {
        bool CreatePCR(PCRCreate model);
        bool DeleteIncident(int id, string userId);
        PCRDetail GetPCRById(int id, string userId);
        IEnumerable<PCRListItem> GetPCRs(string userId);
        bool UpdatePCR(PCREdit model);
    }
}