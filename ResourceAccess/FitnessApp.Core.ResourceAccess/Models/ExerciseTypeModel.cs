using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess.Models
{
    public class ExerciseTypeModel
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; } = 1;

        [Required]
        public string TypeName { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
