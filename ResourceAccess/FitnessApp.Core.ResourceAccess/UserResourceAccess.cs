using FitnessApp.Core.DataObjects.Users;
using FitnessApp.Core.ResourceAccess.DbContexts;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.ResourceAccess.Mappers;
using FitnessApp.Core.Validators;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FitnessApp.Core.ResourceAccess
{
    public class UserResourceAccess
    {
        private readonly UserDbContext _dbContext;

        public UserResourceAccess(UserDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<OperationalResult<List<UserDataObject>>> GetAllUsersAsync()
        {
            try
            {
                List<UserDataObject>? users = null;

                IQueryable<UserModel> queryResult = (from s in _dbContext.Users select s);
                List<UserModel> userModels = await queryResult.ToListAsync();

                if (!userModels.Any()) 
                {
                    return OperationalResult<List<UserDataObject>>.FailureResult($"No {nameof(_dbContext.Users)} found");
                } 
                else
                {
                    foreach(UserModel user in userModels)
                    {
                        users.Add(UserModelMapper.MapUserModelToDataObject(user));
                    }

                    return OperationalResult<List<UserDataObject>>.SuccessResult(users);
                }

            } 
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<List<UserDataObject>>.FailureResult(ex);
            }

        }

        public async Task<OperationalResult<UserDataObject>> GetUserAsync(UserDataObject dataObject)
        {
            try
            {
                UserDataObject? user = null;

                IQueryable<UserModel> queryResult = (from s in _dbContext.Users select s)
                    .Where(a => a.Email == dataObject.Email);
                UserModel? model = await queryResult.FirstOrDefaultAsync();

                if (model == null)
                {
                    return OperationalResult<UserDataObject>.FailureResult($"User does not exist");
                }
                else
                {
                    model = await queryResult.FirstAsync();

                    return OperationalResult<UserDataObject>.SuccessResult(UserModelMapper.MapUserModelToDataObject(model));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<UserDataObject>.FailureResult(ex);
            }

        }

    }
}
