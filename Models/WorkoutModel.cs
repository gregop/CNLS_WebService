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
        public int Id { get; set; }

        public int ?Calories { get; set; }
        
        [Required]
        public int Duration { get; set; }

        [Required]
        public double Distance { get; set; }

        public DateTime Date { get; set; }

    }

    public class GetItem
    {
        public int Id { get; set; }
    }
}
