using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Engines.Interfaces;
using FitnessApp.Core.ResourceAccess;
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
        private readonly WorkoutItemResourceAccess _workoutItemResourceAccess;

        public WorkoutItemEngine(WorkoutItemResourceAccess workoutItemResourceAccess)
        {
            _workoutItemResourceAccess = workoutItemResourceAccess;

        }

        public Task<OperationalResult<WorkoutItemDataObject>> HandleWorkoutCreationAsync(WorkoutItemDataObject workoutItemDataObject)
        {
            throw new NotImplementedException();
        }


    }
}
