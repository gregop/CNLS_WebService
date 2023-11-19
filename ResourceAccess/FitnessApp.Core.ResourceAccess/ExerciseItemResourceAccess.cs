using FitnessApp.Core.DataObjects;
using FitnessApp.Core.DataObjects.Requests;
using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Interfaces;
using FitnessApp.Core.ResourceAccess.Mappers;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;
using Microsoft.EntityFrameworkCore;


namespace FitnessApp.Core.ResourceAccess
{
    public class ExerciseItemResourceAccess : IExerciseItemResourceAccess
    {
        private readonly ExerciseItemDbContext _dbContext;

        public ExerciseItemResourceAccess(ExerciseItemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationalResult<ExerciseItemDataObject>> LogExerciseItemAsync(ExerciseItemDataObject dataObject)
        {
            try
            {
                ExerciseItemModel? model = null;

                IQueryable<ExerciseItemModel> queryResult = (from s in _dbContext.ExerciseItems select s)
                    .Where(a => a.ExerciseName == dataObject.ExerciseName);

                model = await queryResult.FirstOrDefaultAsync();

                if (model != null)
                {
                    model = await queryResult.FirstAsync();

                    return OperationalResult<ExerciseItemDataObject>.FailureResult($"Exercise {model.ExerciseName} already exists with Id:{model.Id}");

                }
                else
                {
                    model = ExerciseItemModelMapper.MapExerciseItemDataObjectToModel(dataObject);

                    if (model != null)
                    {
                        
                        _dbContext.Add(model);
                    }

                }

                _dbContext.SaveChanges();

                return OperationalResult<ExerciseItemDataObject>.SuccessResult(ExerciseItemModelMapper.MapExerciseItemModelToDataObject(model));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ExerciseItemDataObject>.FailureResult(ex);

            }

        }


        public async Task<OperationalResult<List<ExerciseItemDataObject>>> GetAllExerciseItemsAsync()
        {
            try
            {
                List<ExerciseItemModel> models = null;

                IQueryable<ExerciseItemModel> queryResult = (from s in _dbContext.ExerciseItems select s);

                models = await queryResult.ToListAsync();

                if (models.Count == 0)
                {
                    return OperationalResult<List<ExerciseItemDataObject>>.FailureResult("ExerciseItemsNotFound");
                }
                else
                {
                    List<ExerciseItemDataObject> objects = new List<ExerciseItemDataObject>();

                    foreach (ExerciseItemModel m in models)
                    {
                        ExerciseItemDataObject obj = ExerciseItemModelMapper.MapExerciseItemModelToDataObject(m);
                        objects.Add(obj);
                    }

                    return OperationalResult<List<ExerciseItemDataObject>>.SuccessResult(objects);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<List<ExerciseItemDataObject>>.FailureResult(ex);


            }
        }

        public async Task<OperationalResult<List<ExerciseItemDataObject>>> GetAllExerciseItemsAsync(GetExercisesRequestDataObject getExercisesRequestData)
        {
            try
            {
                List<ExerciseItemModel> models = null;

                IQueryable<ExerciseItemModel> queryResult = (from s in _dbContext.ExerciseItems select s)
                    .Where(a => a.ExerciseType == getExercisesRequestData.ExerciseTypeId);

                models = await queryResult.ToListAsync();

                if (models.Count == 0)
                {
                    return OperationalResult<List<ExerciseItemDataObject>>.FailureResult("ExerciseItemsNotFound");
                }
                else
                {
                    List<ExerciseItemDataObject> objects = new List<ExerciseItemDataObject>();

                    foreach (ExerciseItemModel m in models)
                    {
                        ExerciseItemDataObject obj = ExerciseItemModelMapper.MapExerciseItemModelToDataObject(m);
                        objects.Add(obj);
                    }

                    return OperationalResult<List<ExerciseItemDataObject>>.SuccessResult(objects);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<List<ExerciseItemDataObject>>.FailureResult(ex);


            }
        }


        public async Task<OperationalResult<ExerciseItemDataObject>> UpdateExerciseItemAsync(ExerciseItemDataObject dataObject)
        {
            throw new NotImplementedException();

            //model.ExerciseUrl = dataObject.ExerciseUrl;
            //model.ExerciseName = dataObject.ExerciseName;
            //model.DateCreated = dataObject.DateCreated;

            //_dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
