using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess.Interfaces
{
    public interface IExerciseTypeResourceAccess
    {
        Task<OperationalResult<List<ExerciseTypeDataObject>>> GetAllExerciseItemsAsync();
        Task<OperationalResult<ExerciseTypeDataObject>> LogExerciseItemAsync(ExerciseTypeDataObject dataObject);

        Task<OperationalResult<ExerciseTypeDataObject>> UpdateExerciseItemAsync(ExerciseTypeDataObject dataObject);
    }
}
