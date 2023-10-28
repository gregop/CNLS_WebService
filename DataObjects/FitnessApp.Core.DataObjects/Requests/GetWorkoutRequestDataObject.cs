using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.DataObjects.Requests
{
    public class GetWorkoutRequestDataObject
    {
        [Required]
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }
    }
}
