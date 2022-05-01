using AirConditionersManagementSystem.Data.Common.Models;
using AirConditionersManagementSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Data.Models
{
    public class Request : BaseDeletableModel<string>
    {
        public Request()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public string Image { get; set; }

        public RequestStatus Status { get; set; }

        public DateTime VisitedOn { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string TechnicianId { get; set; }

        public ApplicationUser Technician { get; set; }
    }
}
