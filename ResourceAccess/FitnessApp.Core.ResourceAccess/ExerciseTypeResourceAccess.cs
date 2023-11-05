using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Interfaces;
using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess
{
    internal class ExerciseTypeResourceAccess : IExerciseTypeResourceAccess
    {

        private readonly ExerciseItemDbContext _dbContext;

        public ExerciseTypeResourceAccess(ExerciseItemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationalResult<List<ExerciseTypeDataObject>>> GetAllExerciseItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<OperationalResult<ExerciseTypeDataObject>> LogExerciseItemAsync(ExerciseTypeDataObject dataObject)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationalResult<ExerciseTypeDataObject>> UpdateExerciseItemAsync(ExerciseTypeDataObject dataObject)
        {
            throw new NotImplementedException();
        }
    }
}
