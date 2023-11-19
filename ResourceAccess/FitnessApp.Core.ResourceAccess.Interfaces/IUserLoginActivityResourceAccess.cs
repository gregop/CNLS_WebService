using FitnessApp.Core.DataObjects.Users;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.ResourceAccess.Interfaces
{
    public interface IUserLoginActivityResourceAccess
    {
        Task<OperationalResult<List<UserLoginActivityDataObject>>> GetUserActivityAsync(int userId);
        Task<OperationalResult<UserLoginActivityDataObject>> LogUserLoginActivityAsync(UserLoginActivityDataObject dataObject);
    }
}