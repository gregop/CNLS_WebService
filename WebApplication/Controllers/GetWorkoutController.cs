using Microsoft.AspNetCore.Mvc;
using FitnessApp.Core.DataObjects;
using CNSL_WepService.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FitnessApp.Core.ResourceAccess;
using FitnessApp.Core.Validators;

#pragma warning disable IDE0090 // Use 'new(...)'

namespace CNSL_WepService.Controllers
{
    
    [ApiController]
    public class GetWorkoutController : ControllerBase
    {
        private readonly IGetWorkoutApiRes _getWorkoutApiRes;
        private readonly WorkoutItemResourceAccess _workoutItemContext;

        public GetWorkoutController(IGetWorkoutApiRes getWorkoutApiRes, WorkoutItemResourceAccess workoutItemContext)
        {
            _getWorkoutApiRes = getWorkoutApiRes;
            _workoutItemContext = workoutItemContext;
        }
        

        [HttpPost]
        [Route("api/[action]")]
        [Produces("application/json")]
        public ActionResult<IGetWorkoutApiRes> GetWorkout([FromForm] GetWorkoutByIdDataObject ItemFormData)
        {
            try
            {
                IEnumerable<ModelError> modelStateErrors = this.ModelState.Keys
                    .SelectMany(key => this.ModelState[key].Errors);

                List<string> validationErrors = new List<string>();
                // get the ModelStateErrors in an ListofString
                foreach (string key in this.ModelState.Keys)
                {
                    Console.WriteLine(key);
                    if (this.ModelState[key].Errors.Count > 0)
                    {
                        validationErrors.Add(this.ModelState[key].Errors[0].ErrorMessage.ToString());
                        Console.WriteLine(this.ModelState[key].Errors[0].ErrorMessage.ToString());
                    }

                }

                

                // Bad Request if data pass is null
                if (!ModelState.IsValid)
                {
                    _getWorkoutApiRes.StatusNOK();
                    _getWorkoutApiRes.SetMessage(validationErrors[0]);

                    return BadRequest(_getWorkoutApiRes);
                } 
                else
                {
                    
                    // Query Db and get the workout item 
                    Task<OperationalResult<WorkoutItemDataObject>> result = _workoutItemContext.GetWorkoutItemAsync(new WorkoutItemDataObject { Id = ItemFormData.Id });

                    if (result.Result.IsSuccessfulOperation && result.Result.Data != null)
                    {
                        WorkoutItemDataObject res = result.Result.Data;

                        _getWorkoutApiRes.StatusOK();
                        _getWorkoutApiRes.SetWorkoutItem(res);
                        return Ok(_getWorkoutApiRes);

                    }
                    else
                    {
                        if (result.Result.FailureMessage != null && result.Result.Data == null)
                        {
                            _getWorkoutApiRes.StatusNOK();
                            _getWorkoutApiRes.SetMessage(result.Result.FailureMessage.ToString());

                            return NotFound(_getWorkoutApiRes);
                        }

                    }
                    _getWorkoutApiRes.StatusNOK();
                    _getWorkoutApiRes.SetMessage(result.Result.Exception.ToString());
                    return BadRequest(_getWorkoutApiRes);
                        
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR\t" + ex.Message);
                return BadRequest(ex.Message);

            }

        }

    }
}
