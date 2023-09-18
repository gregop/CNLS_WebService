using CNSL_WepService.APIResponses;
using CNSL_WepService.Interfaces;
using FitnessApp.Core.DataObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CNSL_WepService.Controllers
{

    [ApiController]
    public class RegisterWorkoutController : ControllerBase
    {
        private IRegisterWorkoutApiRes _registerWorkoutApiRes;
        public RegisterWorkoutController(IRegisterWorkoutApiRes registerWorkoutApiRes) 
        {
            _registerWorkoutApiRes = registerWorkoutApiRes;

        }

        [HttpPost]
        [Route("api/[action]")]
        [Produces("application/json")]
        public ActionResult<IGetWorkoutApiRes> RegisterCardioWorkout([FromForm] WorkoutItemModel WorkoutItem)
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

                    // Check in a Property Validation Message exists in ValidationResults list
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
                    _registerWorkoutApiRes.StatusOK();
                    // add workout to list
                    return Ok(_registerWorkoutApiRes);

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
