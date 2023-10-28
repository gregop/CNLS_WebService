using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Engines.Interfaces;
using FitnessApp.Core.ResourceAccess;
using FitnessApp.Core.ResourceAccess.Interfaces;
using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Engines
{
    public class WorkoutItemEngine : IWorkoutItemEngine
    {
        private readonly IWorkoutItemResourceAccess _workoutItemResourceAccess;

        public WorkoutItemEngine(IWorkoutItemResourceAccess workoutItemResourceAccess)
        {
            _workoutItemResourceAccess = workoutItemResourceAccess;

        }

        public async Task<OperationalResult<WorkoutItemDataObject>> HandleWorkoutCreationAsync(WorkoutItemDataObject workoutItemDataObject)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationalResult<WorkoutItemDataObject>> HandleWorkoutRequestAsync(WorkoutItemDataObject workoutItemDataObject)
        {
            try
            {
               return await _workoutItemResourceAccess.GetWorkoutItemAsync(workoutItemDataObject);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<WorkoutItemDataObject>.FailureResult(ex);
            }
        }
    }
}
