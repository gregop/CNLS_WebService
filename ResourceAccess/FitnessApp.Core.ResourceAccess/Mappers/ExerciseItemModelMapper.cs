using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FitnessApp.Core.ResourceAccess.Mappers
{
    internal static class ExerciseItemModelMapper
    {
        internal static ExerciseItemModel? MapExerciseItemDataObjectToModel(ExerciseItemDataObject dataObject) 
        {
            try
            {
                if (dataObject == null)
                {
                    return null;
                }

                return new ExerciseItemModel
                {
                    ExerciseName = dataObject.ExerciseName,
                    ExerciseUrl = dataObject.ExerciseUrl,
                    DateCreated = dataObject.DateCreated,

                };

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        
        
        }

        internal static ExerciseItemDataObject? MapExerciseItemModelToDataObject(ExerciseItemModel model)
        {
            try
            {
                if (model == null)
                {
                    return null;
                }

                return new ExerciseItemDataObject
                {
                    Id = model.Id,
                    ExerciseName = model.ExerciseName,
                    ExerciseUrl = model.ExerciseUrl,
                    ExerciseType = model.ExerciseType,
                    DateCreated = model.DateCreated,

                };

                
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
            

        }
    }
}
