using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Data.Models.Enums
{
    public enum RequestStatus
    {
        Waiting = 1,
        ExpectingAVisit = 2,
        InProgess = 3,
        Finished = 4,
    }
}
