using FitnessApp.Core.Validators;
using System.ComponentModel.DataAnnotations;


namespace FitnessApp.Core.DataObjects
{
    public class GetWorkoutByIdDataObject
    {
        [Required]
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }
    }
}
