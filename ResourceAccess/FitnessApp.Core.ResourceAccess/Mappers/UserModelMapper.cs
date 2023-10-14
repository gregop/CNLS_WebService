using FitnessApp.Core.DataObjects.Users;
using FitnessApp.Core.ResourceAccess.Models;


namespace FitnessApp.Core.ResourceAccess.Mappers
{
    internal static class UserModelMapper
    {
        internal static UserModel? MapUserDataObjectToModel(UserDataObject dataObject)
        {
            try
            {
                if (dataObject == null) 
                {
                    return null;
                }

                return new UserModel
                {
                    Name = dataObject.Name,
                    Surname = dataObject.Surname,
                    Email = dataObject.Email,
                    Password = dataObject.Password,
                    Age = dataObject.Age,
                    IsActive = dataObject.IsActive,
                    IsLockedOut = dataObject.IsLockedOut,
                    DateCreated = dataObject.DateCreated.ToUniversalTime(),
                };

            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        internal static UserDataObject? MapUserModelToDataObject(UserModel model)
        {
            try
            {
                if (model == null)
                {
                    return null;
                }

                return new UserDataObject
                {
                    Id = model.Id,
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Password = model.Password,
                    Age = model.Age,
                    IsActive = model.IsActive,
                    IsLockedOut = model.IsLockedOut,
                    DateCreated = model.DateCreated.ToUniversalTime(),
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
