﻿using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;
using FitnessApp.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess
{
    public class FitnessAppCoreResourceAccess
    {
        private readonly WorkoutItemDbContext _dbContext;

        public FitnessAppCoreResourceAccess(WorkoutItemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationalResult> LogWorkoutItemAsync(WorkoutItemDataObject dataObject)
        {
            try
            {
                WorkoutItemModel model = MapWorkoutItemDataObjectToModel(dataObject);
                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();

                return new OperationalResult();

            } catch (Exception ex)
            {
                return new OperationalResult(ex);
            }
            
        } 

        private WorkoutItemModel MapWorkoutItemDataObjectToModel(WorkoutItemDataObject dataObject)
        {
            WorkoutItemModel model = new WorkoutItemModel();

            model.Id = dataObject.Id;
            model.Duration = dataObject.Duration;
            model.Distance = dataObject.Distance;
            model.Calories = dataObject.Calories;
            model.Date = dataObject.Date;
            model.Cardio = dataObject.Cardio;
            model.Description = dataObject.Description;

            return model;
        }

        private WorkoutItemDataObject MapWorkoutItemModelToDataObject(WorkoutItemModel model)
        {
            WorkoutItemDataObject dataObject = new WorkoutItemDataObject();

            dataObject.Id = model.Id;
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
