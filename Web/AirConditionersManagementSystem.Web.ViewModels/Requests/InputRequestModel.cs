using AirConditionersManagementSystem.Data.Models;
using AirConditionersManagementSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionersManagementSystem.Web.ViewModels.Requests
{
    public class InputRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
