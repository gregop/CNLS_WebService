using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Orchestrators.Interfaces;
using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Orchestrators
{
    public class ExerciseMessagesOrchestrator : IExerciseMessagesOrchestrator
    {
        public ExerciseMessagesOrchestrator()
        {

        }

        public async Task<OperationalResult<ExerciseItemDataObject>> HandleExerciseCreationMessagesAsync(string payload)
        {
            return null;
        }

        public async Task<OperationalResult<ExerciseItemDataObject>> HandleExerciseUpdateMessagesAsync(string payload)
        {
            return null;
        }

    }
}
