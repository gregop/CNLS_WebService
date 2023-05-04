using CNSL_WepService.Models.Validators.WorkoutModelValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Models
{
    public class WorkoutModel
    {
        [StrictlyPositivePropery("Id")]
        public int ?Id { get; set; }

        [StrictlyPositivePropery("calories")]
        public int ?Calories { get; set; }
        
        [Required]
        [StrictlyPositivePropery("duration")]
        public int ?Duration { get; set; }

        [Required]
        [StrictlyPositivePropery("distance")]
        public double Distance { get; set; }

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
        public int Id { get; set; }
    }

    public interface IApiResponses
    {
        // common properties and logic yet to be defined

    }
}
