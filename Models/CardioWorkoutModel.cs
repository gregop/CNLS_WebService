using CNSL_WepService.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNSL_WepService.Interfaces;

namespace CNSL_WepService.Models
{
    public class CardioWorkoutModel : IApiResponse
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
    public  class CardioWorkoutOk : IApiResponse
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
    public class CardioWorkoutNOk : IApiResponse
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

    public class GetWorkoutById
    {
        [Required]
        [StrictlyPositiveProperty("id")]
        public int? Id { get; set; }
    }


}
