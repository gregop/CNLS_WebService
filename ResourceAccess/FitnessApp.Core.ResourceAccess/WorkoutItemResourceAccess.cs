using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;
using FitnessApp.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Core.ResourceAccess
{
    public class WorkoutItemResourceAccess
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
                    .Where(a =>  a.WorkoutId == dataObject.Id);
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


                } else {

                    model = MapWorkoutItemDataObjectToModel(dataObject);
                    _dbContext.Add(model);
                }

                await _dbContext.SaveChangesAsync();

                return OperationalResult<WorkoutItemDataObject>.SuccessResult(MapWorkoutItemModelToDataObject(model));

            } catch (Exception ex)
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
                    .Where(a => a.WorkoutId == dataObject.Id);

                model = await queryResult.FirstOrDefaultAsync();


                if (model != null)
                {
                    return OperationalResult<WorkoutItemDataObject>.SuccessResult(MapWorkoutItemModelToDataObject(model));

                } 
                else
                {
                    return OperationalResult<WorkoutItemDataObject>.FailureResult($"Item with Id = {dataObject.Id} not found");
                }

                

            } catch (Exception ex)
            {
                return OperationalResult<WorkoutItemDataObject>.FailureResult(ex);
            }

        }

        private static WorkoutItemModel MapWorkoutItemDataObjectToModel(WorkoutItemDataObject dataObject)
        {
            WorkoutItemModel model = new WorkoutItemModel();

            model.WorkoutId = dataObject.Id;
            model.UserId = dataObject.Id;
            model.Duration = dataObject.Duration;
            model.Distance = dataObject.Distance;
            model.Calories = dataObject.Calories;
            model.Date = dataObject.Date;
            model.Cardio = dataObject.Cardio;
            model.Description = dataObject.Description;

            return model;
        }

        private static WorkoutItemDataObject MapWorkoutItemModelToDataObject(WorkoutItemModel model)
        {
            WorkoutItemDataObject dataObject = new WorkoutItemDataObject();

            dataObject.Id = model.WorkoutId;
            dataObject.WorkoutId = model.Id;
            dataObject.UserId = model.UserId;
            dataObject.Duration = model.Duration;
            dataObject.Distance = model.Distance;
            dataObject.Calories = model.Calories;
            dataObject.Date = model.Date;
            dataObject.Cardio = model.Cardio;
            dataObject.Description = model.Description;

            return dataObject;
        }

    }
}
