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
                    .Where(a => a.WorkoutId == dataObject.WorkoutId);
                model = await queryResult.FirstOrDefaultAsync();

                if (model != null)
                {
                    model = await queryResult.FirstAsync();

                    return OperationalResult<WorkoutItemDataObject>.FailureResult($"WorkoutId {model.WorkoutId} already exists");

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


        public async Task<OperationalResult<WorkoutItemDataObject>> UpdateWorkoutItemAsync(WorkoutItemDataObject dataObject)
        {
            throw new NotImplementedException();

            //try
            //{
            //    workoutitemmodel? model = null;

            //    // retrieve from db:workouitem all instances with the id = dataobject.id
            //    iqueryable<workoutitemmodel> queryresult = (from s in _dbcontext.workoutitem select s)
            //        .where(a => a.workoutid == dataobject.workoutid);
            //    model = await queryresult.firstordefaultasync();

            //    if (model != null)
            //    {
            //        model = await queryresult.firstasync();

            //        model.duration = dataobject.duration;
            //        model.distance = dataobject.distance;
            //        model.calories = dataobject.calories;
            //        model.date = dataobject.date;
            //        model.cardio = dataobject.cardio;
            //        model.description = dataobject.description;
            //        model.userid = dataobject.userid;

            //        _dbcontext.entry(model).state = entitystate.modified;


            //    }
            //    else
            //    {

            //        model = workoutitemmodelmapper.mapworkoutitemdataobjecttomodel(dataobject);
            //        if (model != null)
            //        {
            //            _dbcontext.add(model);
            //        }

            //    }

            //    await _dbcontext.savechangesasync();

            //    return operationalresult<workoutitemdataobject>.successresult(workoutitemmodelmapper.mapworkoutitemmodeltodataobject(model));

            //}
            //catch (exception ex)
            //{
            //    return operationalresult<workoutitemdataobject>.failureresult(ex);
            //}

        }

    }
}
