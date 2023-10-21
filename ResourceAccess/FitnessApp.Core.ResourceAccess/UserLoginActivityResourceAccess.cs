using FitnessApp.Core.DataObjects.Users;
using FitnessApp.Core.ResourceAccess.DbContexts;
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
    public class UserLoginActivityResourceAccess
    {
        private readonly UserDbContext _dbContext;
        public UserLoginActivityResourceAccess(UserDbContext userDbContext) 
        {
            _dbContext = userDbContext;

        }

        public async Task<OperationalResult<UserLoginActivityDataObject>> LogUserLoginActivityAsync(UserLoginActivityDataObject dataObject)
        {

            try
            {
                UserLoginActivityModel activityModel = new UserLoginActivityModel();

                activityModel.UserId = dataObject.UserId;
                activityModel.LoginDateTime = DateTime.Now.ToUniversalTime();

                _dbContext.Add(activityModel);
                await _dbContext.SaveChangesAsync();

                return OperationalResult<UserLoginActivityDataObject>.SuccessResult(UserLoginActivityModelMapper.MapUserLoginActivityModelToDataObject(activityModel));

            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<UserLoginActivityDataObject>.FailureResult(ex);
            }
        }

        public async Task<OperationalResult<List<UserLoginActivityDataObject>>> GetUserActivityAsync(int userId)
        {
            try
            {
                List<UserLoginActivityDataObject> results = new List<UserLoginActivityDataObject>();

                IQueryable<UserLoginActivityModel> query = (from s in _dbContext.UsersLoginActivity select s)
                    .Where(a => a.UserId == userId);

                List<UserLoginActivityModel> userActivityModels = await query.ToListAsync();

                if (!userActivityModels.Any())
                {
                    return OperationalResult<List<UserLoginActivityDataObject>>.FailureResult($"No activity for user with id = {userId}");
                }
                else
                {
                    foreach(UserLoginActivityModel model in userActivityModels)
                    {
                        results.Add(UserLoginActivityModelMapper.MapUserLoginActivityModelToDataObject(model));
                    }
                }

                return OperationalResult<List<UserLoginActivityDataObject>>.SuccessResult(results);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<List<UserLoginActivityDataObject>>.FailureResult(ex);
            }
        }

    }
}
