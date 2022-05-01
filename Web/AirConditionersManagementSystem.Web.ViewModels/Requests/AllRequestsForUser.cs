using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Web.ViewModels.Requests
{
    public class AllRequestsForUser
    {
        public string Name { get; set; }
        public string Status { get; set; }

        public ICollection<RequestViewModel> Requests { get; set; }
    }
}
