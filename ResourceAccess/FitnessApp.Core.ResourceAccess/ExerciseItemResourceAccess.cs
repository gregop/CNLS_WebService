using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Mappers;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;
using Microsoft.EntityFrameworkCore;


namespace FitnessApp.Core.ResourceAccess
{
    public class ExerciseItemResourceAccess
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
                ExerciseItemModel model = null;

                IQueryable<ExerciseItemModel> queryResult = (from s in _dbContext.ExerciseItems select s)
                    .Where(a => a.Id == dataObject.Id);

                model = await queryResult.FirstOrDefaultAsync();

                if (model != null) 
                {
                    model = await queryResult.FirstAsync();

                    model.ExerciseUrl = dataObject.ExerciseUrl;
                    model.ExerciseName = dataObject.ExerciseName;
                    model.DateCreated = dataObject.DateCreated;

                    _dbContext.Entry(model).State = EntityState.Modified;

                } 
                else
                {
                    model = ExerciseItemModelMapper.MapExerciseItemDataObjectToModel(dataObject).Data;

                    if (model != null)
                    {
                        _dbContext.Add(model);
                    }
                    
                }

                _dbContext.SaveChanges();

                return OperationalResult<ExerciseItemDataObject>.SuccessResult(ExerciseItemModelMapper.MapExerciseItemModelToDataObject(model).Data);


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
                        ExerciseItemDataObject obj = ExerciseItemModelMapper.MapExerciseItemModelToDataObject(m).Data;
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
    }
}
