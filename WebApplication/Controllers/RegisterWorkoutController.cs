using CNSL_WepService.APIResponses;
using CNSL_WepService.Interfaces;
using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess;
using FitnessApp.Core.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CNSL_WepService.Controllers
{

    [ApiController]
    public class RegisterWorkoutController : ControllerBase
    {
        private IRegisterWorkoutApiRes _registerWorkoutApiRes;
        private readonly FitnessAppCoreResourceAccess _fitnessAppCoreResourceAccess;

        public RegisterWorkoutController(IRegisterWorkoutApiRes registerWorkoutApiRes, 
            FitnessAppCoreResourceAccess fitnessAppCoreResourceAccess) 
        {
            _registerWorkoutApiRes = registerWorkoutApiRes;
            _fitnessAppCoreResourceAccess = fitnessAppCoreResourceAccess;

        }

        [HttpPost]
        [Route("api/[action]")]
        [Produces("application/json")]
        public ActionResult<IGetWorkoutApiRes> RegisterCardioWorkout([FromForm] WorkoutItemDataObject WorkoutItem)
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

                if (!ModelState.IsValid)
                {

                    // Check if a Property Validation Message exists in ValidationResults list
                    if (validationErrors[0] != null)
                    {
                        _registerWorkoutApiRes.StatusNOK();
                        _registerWorkoutApiRes.SetMessage(validationErrors[0]);

                        return BadRequest(_registerWorkoutApiRes);
                    }
                    else
                    {
                        _registerWorkoutApiRes.StatusNOK();
                        _registerWorkoutApiRes.SetMessage("Model Invalid. Something went wrong. Please contact us.");

                        return BadRequest(_registerWorkoutApiRes);

                    }


                } else
                {
                    
                    // add workout to Db
                    Task<OperationalResult<WorkoutItemDataObject>> result = _fitnessAppCoreResourceAccess.LogWorkoutItemAsync(WorkoutItem);

                    if (result.Result.Data != null && result.Result.IsSuccessfulOperation)
                    {
                        _registerWorkoutApiRes.StatusOK(result.Result.Data.WorkoutId);
                        return Ok(_registerWorkoutApiRes);
                    } 
                    else
                    {
                        _registerWorkoutApiRes.StatusNOK();
                        _registerWorkoutApiRes.SetMessage("Model Invalid. Something went wrong. Please contact us.");

                        return BadRequest(_registerWorkoutApiRes);
                    }

                    

                }
                
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR\t" + ex.Message);
                return BadRequest(ex.Message);
            }


        }

    }
}
