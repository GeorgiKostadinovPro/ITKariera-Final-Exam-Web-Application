using AirConditionersManagementSystem.Services.Data;
using AirConditionersManagementSystem.Web.ViewModels.ApplicationUsers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace AirConditionersManagementSystem.Web.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IApplicationUsersService usersService;

        public UsersController(IApplicationUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputApplicationUserModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.usersService.CreateUser(inputModel);
            return this.RedirectToAction("UsersCRUD", "Users");
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var inputModel = this.usersService.GetUserById(id);
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, EditUserInputModel user)
        {
            if (!this.ModelState.IsValid)
            {
                user.Id = id;
                return this.View(user);
            }

            await this.usersService.UpdateUser(id, user);

            return this.RedirectToAction("UsersCRUD", "Users");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.usersService.DeleteUser(id);

            return this.RedirectToAction("UsersCRUD", "Users");
        }
        public IActionResult UsersCRUD()
        {
            AllUsersViewModel users = new AllUsersViewModel
            {
                Users = this.usersService.GetAllUsers(),
            };

            return View(users);
        }
    }
}
