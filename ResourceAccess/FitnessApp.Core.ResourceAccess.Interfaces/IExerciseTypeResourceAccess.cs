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
        Task<OperationalResult<List<ExerciseTypeDataObject>>> GetAllExerciseTypesAsync();
        Task<OperationalResult<ExerciseTypeDataObject>> LogExerciseTypeAsync(ExerciseTypeDataObject dataObject);

        Task<OperationalResult<ExerciseTypeDataObject>> UpdateExerciseTypeAsync(ExerciseTypeDataObject dataObject);
    }
}
