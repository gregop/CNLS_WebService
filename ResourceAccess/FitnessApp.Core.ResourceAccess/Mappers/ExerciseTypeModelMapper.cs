using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess.Mappers
{
    internal static class ExerciseTypeModelMapper
    {
        internal static ExerciseTypeModel? MapExerciseTypeDataObjectToModel(ExerciseTypeDataObject dataObject)
        {
            try
            {
                if (dataObject == null)
                {
                    return null;
                }

                return new ExerciseTypeModel
                {
                    TypeName = dataObject.TypeName,
                    Description = dataObject.Description,
                    DateCreated = dataObject.DateCreated,

                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }


        }

        internal static ExerciseTypeDataObject? MapExerciseItemModelToDataObject(ExerciseTypeModel model)
        {
            try
            {
                if (model == null)
                {
                    return null;
                }

                return new ExerciseTypeDataObject
                {
                    Id = model.Id,
                    TypeName = model.TypeName,
                    Description = model.Description,
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
