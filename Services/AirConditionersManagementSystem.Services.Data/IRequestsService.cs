using AirConditionersManagementSystem.Web.ViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Services.Data
{
    public interface IRequestsService
    {
        Task CreateRequest(InputRequestModel requestModel);

        Task DeleteRequest(string requestId);

        Task UpdateRequest(string requestId, InputRequestModel inputRequestModel);

        InputRequestModel GetRequestById(string requestId);
        ICollection<RequestViewModel> GetAllRequests();
    }
}
