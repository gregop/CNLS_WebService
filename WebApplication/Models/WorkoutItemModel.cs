using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNSL_WepService.Interfaces;
using Microsoft.Identity.Client;

namespace CNSL_WepService.Models
{

    public class GetWorkoutById
    {
        [Required]
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }
    }


}
