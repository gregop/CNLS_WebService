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
        public int ?Id { get; set; }

        public int ?Calories { get; set; }
        
        [Required]
        public int ?Duration { get; set; }

        private double _distance;

        [Required]
        public double Distance { 
            get {
                return _distance;
            }
            set {

                if (value > 0)
                {
                    _distance = value;
                }
                else
                {
                    throw new ArgumentException("Distance must be a positive number");
                }
            }
        }

        //public string DistanceMetricUnit { get; set; }

        public DateTime ?Date { get; set; }

    }

    // registerWorkout Response Model if OKAY
    public  class WorkoutOk : IApiResponses
    {
        public int Id { get;  set; }
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
        public int Id { get; set; }
        private readonly string _message = "Workout Model is Invalid";
        public string Message
        {
            get
            {
                return _message;
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
