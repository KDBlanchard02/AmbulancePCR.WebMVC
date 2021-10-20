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


    }
}
