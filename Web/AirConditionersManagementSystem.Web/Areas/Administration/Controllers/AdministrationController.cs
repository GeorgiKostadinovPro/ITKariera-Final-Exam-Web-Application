namespace AirConditionersManagementSystem.Web.Areas.Administration.Controllers
{
    using AirConditionersManagementSystem.Common;
    using AirConditionersManagementSystem.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
