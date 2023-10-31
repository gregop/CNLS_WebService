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

        int SystemWorkoutId { get; }

        WorkoutItemDataObject WorkoutObject { get; }

        void StatusOK(int WorkoutId, WorkoutItemDataObject WorkoutObject);

        void StatusNOK();

        void SetMessage(string message);
    }
}
