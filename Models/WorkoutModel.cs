using CNSL_WepService.Models.Validators.WorkoutModelValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Models
{
    public class WorkoutModel : IApiResponses
    {
        [StrictlyPositiveProperty("Id")]
        public int ?Id { get; set; }

        [StrictlyPositiveProperty("calories")]
        public int ?Calories { get; set; }
        
        [Required]
        [StrictlyPositiveProperty("duration")]
        public int Duration { get; set; }

        [Required]
        [StrictlyPositiveProperty("distance")]
        public double ?Distance { get; set; }

        //public string DistanceMetricUnit { get; set; }

        public DateTime ?Date { get; set; }

    }

    // registerWorkout Response Model if OKAY
    public  class WorkoutOk : IApiResponses
    {
        private readonly string _status = "Success";
        public string Status
        {
            get
            {
                return _status;
            }
        }
        private readonly string _message = "Success";
        public string Message { 
            get 
            { 
                return _message; 
            } 
        }
    }

    // registerWorkout Response Model if NOK
    public class WorkoutNOk : IApiResponses
    {
        private readonly string _status = "Error";
        public string Status
        {
            get
            {
                return _status;
            }
        }
        
        private string _message = "Workout Model is Invalid";
        public string Message
        {
            get
            {
                return _message;
            }
            set 
            {
                _message = value;
            }
            
        }
    }

    public class GetItem
    {
        [Required]
        [StrictlyPositiveProperty("id")]
        public int? Id { get; set; }
    }

    public interface IApiResponses
    {
        // common properties and logic yet to be defined

    }
}
