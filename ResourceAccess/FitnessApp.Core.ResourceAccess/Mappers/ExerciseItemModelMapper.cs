using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.ResourceAccess.Mappers
{
    public class ExerciseItemModelMapper
    {
        public ExerciseItemModelMapper() { }

        public static OperationalResult<ExerciseItemModel> MapExerciseItemDataObjectToModel(ExerciseItemDataObject dataObject) 
        {
            try
            {
                ExerciseItemModel model = new ExerciseItemModel
                {
                    ExerciseName = dataObject.ExerciseName,
                    ExerciseUrl = dataObject.ExerciseUrl,
                    DateCreated = dataObject.DateCreated,

                };

                return OperationalResult<ExerciseItemModel>.SuccessResult(model);

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ExerciseItemModel>.FailureResult(ex);
            }
        
        
        }

        public static OperationalResult<ExerciseItemDataObject> MapExerciseItemModelToDataObject(ExerciseItemModel model)
        {
            try
            {
                ExerciseItemDataObject dataObject = new ExerciseItemDataObject
                {
                    Id = model.Id,
                    ExerciseName = model.ExerciseName,
                    ExerciseUrl = model.ExerciseUrl,
                    DateCreated = model.DateCreated,

                };

                return OperationalResult<ExerciseItemDataObject>.SuccessResult(dataObject);


            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ExerciseItemDataObject>.FailureResult(ex);
            }
            

        }
    }
}
