using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Mappers;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess
{
    public class WorkoutExercisesHistoryResourceAccess
    {
        private readonly WorkoutItemDbContext _dbContext;

        public WorkoutExercisesHistoryResourceAccess(WorkoutItemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationalResult<WorkoutExercisesHistoryDataObject>> LogWorkoutExerciseAsync(WorkoutExercisesHistoryDataObject dataObject)
        {
            try
            {
                if (dataObject == null)
                {
                    return OperationalResult<WorkoutExercisesHistoryDataObject>.FailureResult("null Workout Excersise");
                }

                WorkoutExercisesHistoryModel? model = new WorkoutExercisesHistoryModel();

                IQueryable<WorkoutExercisesHistoryModel> query = (from s in _dbContext.WorkoutExercisesHistory select s)
                    .Where(a => a.WorkoutId == dataObject.WorkoutId && a.UserId == dataObject.UserId && a.ExerciseId == a.UserId);

                model = await query.FirstOrDefaultAsync();

                if (model != null)
                {
                    return OperationalResult<WorkoutExercisesHistoryDataObject>.FailureResult("Exercise already exists for that workout");
                } 
                else
                {
                    model.WorkoutId = dataObject.WorkoutId;
                    model.UserId = dataObject.UserId;
                    model.ExerciseId = dataObject.ExerciseId;
                    model.DateCreated = model.DateCreated.ToUniversalTime();

                    _dbContext.Add(model);
                }

                await _dbContext.SaveChangesAsync();

                return OperationalResult<WorkoutExercisesHistoryDataObject>.SuccessResult(WorkoutExercisesHistoryModelMapper.MapWWorkoutExercisesHistoryModelToDataObject(model));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<WorkoutExercisesHistoryDataObject>.FailureResult(ex);
            }

        }

        public async Task<OperationalResult<List<WorkoutExercisesHistoryDataObject>>> GetWorkoutExercisesAsync(WorkoutItemDataObject dataObject)
        {
            try
            {
                if (dataObject == null)
                {
                    return OperationalResult<List<WorkoutExercisesHistoryDataObject>>.FailureResult("null workout Item");
                }

                List<WorkoutExercisesHistoryDataObject> results = new List<WorkoutExercisesHistoryDataObject>();

                IQueryable<WorkoutExercisesHistoryModel> query = (from s in _dbContext.WorkoutExercisesHistory select s)
                    .Where(a => a.WorkoutId == dataObject.WorkoutId && a.UserId == dataObject.UserId);

                List<WorkoutExercisesHistoryModel>  queryResults = await query.ToListAsync();

                if (!queryResults.Any())
                {
                    return OperationalResult<List<WorkoutExercisesHistoryDataObject>>.FailureResult("No exercises for workoutId and UserId");
                }
                else
                {
                    foreach(WorkoutExercisesHistoryModel workoutExercise in queryResults)
                    {
                        results.Add(WorkoutExercisesHistoryModelMapper.MapWWorkoutExercisesHistoryModelToDataObject(workoutExercise));
                    }

                }

                return OperationalResult<List<WorkoutExercisesHistoryDataObject>>.SuccessResult(results); 

            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<List<WorkoutExercisesHistoryDataObject>>.FailureResult(ex);
            }
        }

    }
}
