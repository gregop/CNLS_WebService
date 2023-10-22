using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.DataObjects.Interfaces
{
    public interface IRegisterWorkoutApiRes
    {
        string? Status { get; }

        string? Message { get; }
        int WorkoutId { get;  }
        void StatusOK(int WorkoutId);

        void StatusNOK();

        void SetMessage(string message);
    }
}
