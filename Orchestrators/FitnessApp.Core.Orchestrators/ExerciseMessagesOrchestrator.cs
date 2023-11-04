using FitnessApp.Core.DataObjects;
using FitnessApp.Core.DataObjects.Interfaces;
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

        public async Task<OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>> HandleExerciseCreationMessagesAsync(string payload)
        {
            return null;
        }

        public async Task<OperationalResult<ResponseContext<ExerciseItemDataObject>>> HandleExerciseUpdateMessagesAsync(string payload)
        {
            return null;
        }

    }
}
