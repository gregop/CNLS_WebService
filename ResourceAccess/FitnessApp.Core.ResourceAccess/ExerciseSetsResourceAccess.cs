using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Interfaces;
using FitnessApp.Core.ResourceAccess.Mappers;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Core.ResourceAccess
{
    public class ExerciseSetsResourceAccess : IExerciseSetsResourceAccess
    {
        private readonly ExerciseItemDbContext _dbContext;

        public ExerciseSetsResourceAccess(ExerciseItemDbContext exerciseItemDbContext)
        {
            _dbContext = exerciseItemDbContext;
        }

        public async Task<OperationalResult<ExerciseSetDataObject>> LogExerciseSetAsync(ExerciseSetDataObject dataObject)
        {

            try
            {
                ExerciseSetModel model = new ExerciseSetModel();

                model.WorkoutExerciseHistoryId = dataObject.WorkoutExerciseHistoryId;
                model.WorkoutId = dataObject.WorkoutId;
                model.ExerciseId = dataObject.ExerciseId;
                model.Reps = dataObject.Reps;
                model.Kg = dataObject.Kg;
                model.DateCreated = dataObject.DateCreated.ToUniversalTime();

                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();

                return OperationalResult<ExerciseSetDataObject>.SuccessResult(ExerciseSetModelMapper.MapExerciseSetModelToDataObject(model));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ExerciseSetDataObject>.FailureResult(ex);
            }
        }

        public async Task<OperationalResult<ExerciseSetDataObject>> UpdateExerciseSetAsync(ExerciseSetDataObject dataObject)
        {

            try
            {
                ExerciseSetModel model = new ExerciseSetModel();

                IQueryable<ExerciseSetModel> query = (from s in _dbContext.ExerciseSets select s)
                    .Where(a => a.Id == dataObject.Id);

                model = await query.FirstOrDefaultAsync();

                if (model == null)
                {
                    return OperationalResult<ExerciseSetDataObject>.FailureResult("Exercise Set does not exist");
                }
                else
                {
                    model = await query.FirstAsync();

                    model.Reps = dataObject.Reps;
                    model.Kg = dataObject.Kg;

                    _dbContext.Update(model).State = EntityState.Modified;
                }

                await _dbContext.SaveChangesAsync();

                return OperationalResult<ExerciseSetDataObject>.SuccessResult(ExerciseSetModelMapper.MapExerciseSetModelToDataObject(model));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ExerciseSetDataObject>.FailureResult(ex);
            }
        }

    }
}
