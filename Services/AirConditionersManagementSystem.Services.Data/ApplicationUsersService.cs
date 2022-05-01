using AirConditionersManagementSystem.Common;
using AirConditionersManagementSystem.Data;
using AirConditionersManagementSystem.Data.Common.Repositories;
using AirConditionersManagementSystem.Data.Models;
using AirConditionersManagementSystem.Web.ViewModels.ApplicationUsers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Services.Data
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
      
        public ApplicationUsersService(ApplicationDbContext dbContext, UserManager<ApplicationUser> _userManager)
        {
            this.dbContext = dbContext;
            this._userManager = _userManager;
        }
        public async Task CreateUser(InputApplicationUserModel inputUserModel)
        {
            if (this.dbContext.Users
                .Any(u => u.UserName.Equals(inputUserModel.Username) && u.Email.Equals(inputUserModel.Email)))
            {
                throw new ArgumentException("This user already exists!");
            }

            ApplicationUser user = new ApplicationUser
            {
                UserName = inputUserModel.Username,
                Email = inputUserModel.Email,
            };

            await this._userManager.CreateAsync(user, inputUserModel.Password);
            await this._userManager.AddToRoleAsync(user, inputUserModel.Role);
        }

        public async Task DeleteUser(string userId)
        {
            ApplicationUser user = this.dbContext.Users
                .FirstOrDefault(u => u.Id.Equals(userId));

            var userRole = this.dbContext.UserRoles
                .FirstOrDefault(ur => ur.UserId.Equals(userId));

            if (userRole != null)
            {
                this.dbContext.UserRoles.Remove(userRole);
            }

            await this._userManager.DeleteAsync(user);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<UserViewModel> GetAllUsers()
        {
            var allUsers = this.dbContext.Users
                .Select(u => new UserViewModel
                { 
                   UserName = u.UserName,
                   Id = u.Id,
                   Email = u.Email,
                   Role = this.dbContext.Roles.FirstOrDefault(r => r.Id == u.Roles.Single().RoleId).Name,
                })
                .ToList();

            return allUsers;
        }

        public EditUserInputModel GetUserById(string userId)
        {
            ApplicationUser user = this.dbContext.Users
                .FirstOrDefault(u => u.Id.Equals(userId));

            var userRole = this.dbContext.UserRoles
                .FirstOrDefault(ur => ur.UserId.Equals(userId));

            var role = this.dbContext.Roles.FirstOrDefault(r => r.Id.Equals(userRole.RoleId));

            EditUserInputModel userViewModel = new EditUserInputModel
            {
                Id = userId,
                UserName = user.UserName,
                Email = user.Email,
                OldPassword = user.PasswordHash,
                Role = role.Name,
            };

            return userViewModel;
        }

        public async Task UpdateUser(string userId, EditUserInputModel editInputModel)
        {
            var user = await this._userManager.FindByIdAsync(editInputModel.Id);

            if (user == null)
            {
                throw new InvalidOperationException("This user doesn't exist!");
            }

            user.UserName = editInputModel.UserName;
            user.Email = editInputModel.Email;

            if (editInputModel.Role != "Administrator" && editInputModel.Role != "Technician" && editInputModel.Role != "Customer")
            {
                throw new InvalidOperationException("Invalid role!");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var userRole = userRoles.FirstOrDefault();

            await this._userManager.RemoveFromRoleAsync(user, userRole);
            await this._userManager.AddToRoleAsync(user, editInputModel.Role);

            await this._userManager.ChangePasswordAsync(user, editInputModel.OldPassword, editInputModel.NewPassword);
        }
    }
}
