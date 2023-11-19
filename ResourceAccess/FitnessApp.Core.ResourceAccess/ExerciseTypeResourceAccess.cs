using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Interfaces;
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
    public class ExerciseTypeResourceAccess : IExerciseTypeResourceAccess
    {

        private readonly ExerciseItemDbContext _dbContext;

        public ExerciseTypeResourceAccess(ExerciseItemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationalResult<List<ExerciseTypeDataObject>>> GetAllExerciseTypesAsync()
        {
            try
            {
                List<ExerciseTypeDataObject> results = new List<ExerciseTypeDataObject>(); 

                IQueryable<ExerciseTypeModel> queryResult = (from s in _dbContext.ExerciseTypes select s);

                List<ExerciseTypeModel> models = await queryResult.ToListAsync();

                if(!models.Any())
                {
                    return OperationalResult<List<ExerciseTypeDataObject>>.FailureResult("There are no exercise types");
                }
                else
                {
                    foreach (ExerciseTypeModel model in models) 
                    {
                        ExerciseTypeDataObject obj = ExerciseTypeModelMapper.MapExerciseTypeModelToDataObject(model);
                        results.Add(obj);
                    }

                }

                return OperationalResult<List<ExerciseTypeDataObject>>.SuccessResult(results);

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<List<ExerciseTypeDataObject>>.FailureResult(ex.Message);
            
            }
        }

        public async Task<OperationalResult<ExerciseTypeDataObject>> LogExerciseTypeAsync(ExerciseTypeDataObject dataObject)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationalResult<ExerciseTypeDataObject>> UpdateExerciseTypeAsync(ExerciseTypeDataObject dataObject)
        {
            throw new NotImplementedException();
        }
    }
}
