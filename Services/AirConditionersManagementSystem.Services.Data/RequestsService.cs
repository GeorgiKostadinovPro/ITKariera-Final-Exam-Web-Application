using AirConditionersManagementSystem.Data;
using AirConditionersManagementSystem.Data.Models;
using AirConditionersManagementSystem.Data.Models.Enums;
using AirConditionersManagementSystem.Web.ViewModels.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Services.Data
{
    public class RequestsService : IRequestsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        private ApplicationUser currentUser;

        public RequestsService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.currentUser = this.dbContext.Users.Where(user => user.Id == httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefault();
        }
        public async Task CreateRequest(InputRequestModel requestModel)
        {
            Request request = new Request
            {
                Name = requestModel.Name,
                Description = requestModel.Description,
                Image = requestModel.Image,
                Address = requestModel.Address,
                Status = (RequestStatus)Enum.Parse(typeof(RequestStatus), requestModel.Status),
                User = currentUser,
                UserId = currentUser.Id,
            };

            this.dbContext.Requests.AddAsync(request);
            this.dbContext.SaveChanges();
        }

        public async Task DeleteRequest(string requestId)
        {
            Request request = this.dbContext.Requests
                .FirstOrDefault(u => u.Id.Equals(requestId));

            this.dbContext.Requests.Remove(request);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<RequestViewModel> GetAllRequests()
        {
            return this.dbContext.Requests
                .Select(r => new RequestViewModel
                {
                   Id = r.Id,
                   Name = r.Name,
                   Status = r.Status.ToString(),
                })
                .ToList();
        }

        public InputRequestModel GetRequestById(string requestId)
        {
            Request request = this.dbContext.Requests
                .FirstOrDefault(r => r.Id.Equals(requestId));

            InputRequestModel inputRequestModel = new InputRequestModel
            {
                Id = requestId,
                Name = request.Name,
                Address = request.Address,
                Image = request.Image,
                Description = request.Description,
                Status = request.Status.ToString(),
            };

            return inputRequestModel;
        }

        public async Task UpdateRequest(string requestId, InputRequestModel inputRequestModel)
        {
            Request request = this.dbContext.Requests
                .FirstOrDefault(r => r.Id.Equals(requestId));

            request.Id = inputRequestModel.Id;
            request.Name = inputRequestModel.Name;
            request.Address = inputRequestModel.Address;
            request.Description = inputRequestModel.Description;
            request.Image = inputRequestModel.Image;
            request.Status = (RequestStatus)Enum.Parse(typeof(RequestStatus), inputRequestModel.Status);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
