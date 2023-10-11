using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.DataObjects.Users
{
    public class UserLoginActivityDataObject
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [StrictlyPositiveProperty("Id")]
        public int UserId { get; set; }

        public DateTime LoginDateTime { get; set; }
    }
}
