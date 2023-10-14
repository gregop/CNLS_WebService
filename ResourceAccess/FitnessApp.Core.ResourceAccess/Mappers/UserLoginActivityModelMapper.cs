using FitnessApp.Core.DataObjects.Users;
using FitnessApp.Core.ResourceAccess.Models;

namespace FitnessApp.Core.ResourceAccess.Mappers
{
    internal static class UserLoginActivityModelMapper
    {
        internal static UserLoginActivityModel? MapUserLoginActivityDataObjectToModel(UserLoginActivityDataObject dataObject)
        {
            try
            {
                if (dataObject == null)
                {
                    return null;
                }

                return new UserLoginActivityModel
                {
                    UserId = dataObject.UserId,
                    LoginDateTime = dataObject.LoginDateTime.ToUniversalTime(),
                };

            }
            catch (Exception ex) 
            {   
                Console.WriteLine(ex.Message.ToString());
                return null;
            }

        }

        internal static UserLoginActivityDataObject? MapUserLoginActivityModelToDataObject(UserLoginActivityModel model)
        {
            try
            {
                if (model == null) 
                {
                    return null;
                }

                return new UserLoginActivityDataObject
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    LoginDateTime = model.LoginDateTime.ToUniversalTime(),
                };

            } 
            catch  (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
                return null;            
            }
            
        
        }    
    }
}
