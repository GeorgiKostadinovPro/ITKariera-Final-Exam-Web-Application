using AirConditionersManagementSystem.Services.Data;
using AirConditionersManagementSystem.Web.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace AirConditionersManagementSystem.Web.Controllers
{
    public class RequestsController : BaseController
    {
        private readonly IRequestsService requestsService;

        public RequestsController(IRequestsService requestsService)
        {
            this.requestsService = requestsService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputRequestModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.requestsService.CreateRequest(inputModel);
            return this.RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(string id)
        { 
            await this.requestsService.DeleteRequest(id);
            return this.RedirectToAction("GetAllRequestsForUser", "Requests");
        }


        [HttpGet]
        public IActionResult Update(string id)
        {
            var inputModel = this.requestsService.GetRequestById(id);
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, InputRequestModel requestModel)
        {
            if (!this.ModelState.IsValid)
            {
                requestModel.Id = id;
                return this.View(requestModel);
            }

            await this.requestsService.UpdateRequest(id, requestModel);

            return this.RedirectToAction("GetAllRequestsForUser", "Requests");
        }

        public IActionResult GetAllRequestsForUser()
        {
            AllRequestsForUser allRequests = new AllRequestsForUser
            {
                Requests = this.requestsService.GetAllRequests(),
            };

            return this.View(allRequests);
        }
    }
}
