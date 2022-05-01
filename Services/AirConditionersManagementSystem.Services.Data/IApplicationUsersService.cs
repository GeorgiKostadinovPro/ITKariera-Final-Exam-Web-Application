using AirConditionersManagementSystem.Web.ViewModels.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Services.Data
{
    public interface IApplicationUsersService
    {
        Task CreateUser(InputApplicationUserModel inputUserModel);

        Task UpdateUser(string userId, EditUserInputModel editInputModel);

        Task DeleteUser(string userId);

        EditUserInputModel GetUserById(string userId);

        ICollection<UserViewModel> GetAllUsers();
    }
}
