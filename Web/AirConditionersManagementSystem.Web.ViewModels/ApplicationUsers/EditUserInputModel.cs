using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Web.ViewModels.ApplicationUsers
{
    public class EditUserInputModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
