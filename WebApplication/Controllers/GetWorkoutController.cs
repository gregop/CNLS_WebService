using Microsoft.AspNetCore.Mvc;
using FitnessApp.Core.DataObjects;
using CNSL_WepService.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CNSL_WepService.Controllers
{
    
    [ApiController]
    public class GetWorkoutController : ControllerBase
    {
        private IGetWorkoutApiRes _getWorkoutApiRes;

        private readonly List<RegisterWorkoutDataObject> _todoItems = new List<RegisterWorkoutDataObject>
        {
            new RegisterWorkoutDataObject { Id = 1, Duration = 30, Distance = 3.58, Calories = 260, Date = new DateTime(2023, 5, 2, 18, 54, 00), Cardio = true, Description = "Tredmill Run"},
            new RegisterWorkoutDataObject { Id = 2, Duration = 30, Distance = 3.84, Calories = 270, Date = new DateTime(2023, 5, 3, 18, 16, 00), Cardio = true, Description = "Outside Run"},
            new RegisterWorkoutDataObject { Id = 3, Duration = 40, Distance = 8 }
        };

        public GetWorkoutController(IGetWorkoutApiRes getWorkoutApiRes)
        {
            _getWorkoutApiRes = getWorkoutApiRes;
        }
        

        [HttpPost]
        [Route("api/[action]")]
        [Produces("application/json")]
        public ActionResult<IGetWorkoutApiRes> GetWorkout([FromForm] GetWorkoutById ItemFormData)
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

                // Get workout by Id
                RegisterWorkoutDataObject? item_form = _todoItems.FirstOrDefault(i => i.Id == ItemFormData.Id);

                // handle case where Item Id does not exist
                if (item_form == null)
                {
                    _getWorkoutApiRes.StatusNOK();
                    _getWorkoutApiRes.SetMessage($"Item with Id = {ItemFormData.Id} does not exist");

                    return NotFound(_getWorkoutApiRes);
                }
                else
                {
                    _getWorkoutApiRes.StatusOK();
                    _getWorkoutApiRes.SetWorkoutItem(item_form);
                    return Ok(_getWorkoutApiRes);
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
