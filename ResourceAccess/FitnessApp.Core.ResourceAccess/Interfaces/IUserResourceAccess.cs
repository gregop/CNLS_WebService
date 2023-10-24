using FitnessApp.Core.DataObjects.Users;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.ResourceAccess.Interfaces
{
    public interface IUserResourceAccess
    {
        Task<OperationalResult<UserDataObject>> AddUserAsync(UserDataObject dataObject);
        Task<OperationalResult<List<UserDataObject>>> GetAllUsersAsync();
        Task<OperationalResult<UserDataObject>> GetUserAsync(UserDataObject dataObject);
        Task<OperationalResult<UserDataObject>> UpdateUserAsync(UserDataObject dataObject);
    }
}