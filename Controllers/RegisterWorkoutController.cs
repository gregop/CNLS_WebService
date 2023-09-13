using CNSL_WepService.APIResponses;
using CNSL_WepService.Interfaces;
using CNSL_WepService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Controllers
{
    
    [ApiController]
    public class RegisterWorkoutController : ControllerBase
    {

        [HttpPost]
        [Route("api/[action]")]
        [Produces("application/json")]
        public ActionResult<IApiResponse> RegisterCardioWorkout([FromForm] WorkoutItemModel WorkoutItem)
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

                IApiResponse apiResponse = new RegisterWorkoutAPIResponse();

                if (!ModelState.IsValid)
                {

                    // Check in a Property Validation Message exists in ValidationResults list
                    if (validationErrors[0] != null)
                    {
                        apiResponse.StatusNOK();
                        apiResponse.SetMessage(validationErrors[0]);

                        return BadRequest(apiResponse);
                    }
                    else
                    {
                        apiResponse.StatusNOK();
                        apiResponse.SetMessage("Model Invalid. Something went wrong. Please contact us.");

                        return BadRequest(apiResponse);

                    }


                } else
                {
                    apiResponse.StatusOK();
                    // add workout to list
                    return Ok(apiResponse);

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
