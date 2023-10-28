using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;
using FitnessApp.Core.DataObjects;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Core.ResourceAccess.Mappers;
using FitnessApp.Core.ResourceAccess.Interfaces;

namespace FitnessApp.Core.ResourceAccess
{
    public class WorkoutItemResourceAccess : IWorkoutItemResourceAccess
    {
        private readonly WorkoutItemDbContext _dbContext;

        public WorkoutItemResourceAccess(WorkoutItemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationalResult<WorkoutItemDataObject>> LogWorkoutItemAsync(WorkoutItemDataObject dataObject)
        {
            try
            {
                WorkoutItemModel? model = null;

                // retrieve from DB:WORKOUITEM all instances with the id = dataObject.Id
                IQueryable<WorkoutItemModel> queryResult = (from s in _dbContext.WorkoutItem select s)
                    .Where(a => a.WorkoutId == dataObject.Id);
                model = await queryResult.FirstOrDefaultAsync();

                if (model != null)
                {
                    model = await queryResult.FirstAsync();

                    model.Duration = dataObject.Duration;
                    model.Distance = dataObject.Distance;
                    model.Calories = dataObject.Calories;
                    model.Date = dataObject.Date;
                    model.Cardio = dataObject.Cardio;
                    model.Description = dataObject.Description;
                    model.UserId = dataObject.UserId;

                    _dbContext.Entry(model).State = EntityState.Modified;


                }
                else
                {

                    model = WorkoutItemModelMapper.MapWorkoutItemDataObjectToModel(dataObject);
                    if (model != null)
                    {
                        _dbContext.Add(model);
                    }

                }

                await _dbContext.SaveChangesAsync();

                return OperationalResult<WorkoutItemDataObject>.SuccessResult(WorkoutItemModelMapper.MapWorkoutItemModelToDataObject(model));

            }
            catch (Exception ex)
            {
                return OperationalResult<WorkoutItemDataObject>.FailureResult(ex);
            }

        }

        public async Task<OperationalResult<WorkoutItemDataObject>> GetWorkoutItemAsync(WorkoutItemDataObject dataObject)
        {

            try
            {
                WorkoutItemModel? model = null;

                IQueryable<WorkoutItemModel> queryResult = (from s in _dbContext.WorkoutItem select s)
                    .Where(a => a.WorkoutId == dataObject.WorkoutId);

                model = await queryResult.FirstOrDefaultAsync();


                if (model != null)
                {
                    return OperationalResult<WorkoutItemDataObject>.SuccessResult(WorkoutItemModelMapper.MapWorkoutItemModelToDataObject(model));

                }
                else
                {
                    return OperationalResult<WorkoutItemDataObject>.FailureResult($"Item with Id = {dataObject.WorkoutId} not found");
                }



            }
            catch (Exception ex)
            {
                return OperationalResult<WorkoutItemDataObject>.FailureResult(ex);
            }

        }



    }
}
