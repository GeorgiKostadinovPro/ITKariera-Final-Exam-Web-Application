using AirConditionersManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Web.ViewModels.ApplicationUsers
{
    public class AllUsersViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<UserViewModel> Users { get; set; }
    }
}
