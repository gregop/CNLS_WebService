using Microsoft.AspNetCore.Mvc;
using CNSL_WepService.Models;
using CNSL_WepService.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CNSL_WepService.APIResponses;

namespace CNSL_WepService.Controllers
{
    
    [ApiController]
    public class GetWorkoutController : ControllerBase
    {
        

        private readonly List<WorkoutItemModel> _todoItems = new List<WorkoutItemModel>
        {
            new WorkoutItemModel { Id = 1, Duration = 30, Distance = 3.58, Calories = 260, Date = new DateTime(2023, 5, 2, 18, 54, 00), Cardio = true, Description = "Tredmill Run"},
            new WorkoutItemModel { Id = 2, Duration = 30, Distance = 3.84, Calories = 270, Date = new DateTime(2023, 5, 3, 18, 16, 00), Cardio = true, Description = "Outside Run"},
            new WorkoutItemModel { Id = 3, Duration = 40, Distance = 8 }
        };
        

        [HttpPost]
        [Route("api/[action]")]
        [Produces("application/json")]
        public ActionResult<IApiResponse> GetWorkout([FromForm] GetWorkoutById ItemFormData)
        {
            try
            {
                //string connectionString = System.Configuration.ConfigurationManager
                //    .ConnectionStrings["EntityFrameworkConnectionString"].ConnectionString;
                //Console.WriteLine(connectionString);

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

                IApiResponse apiResponse = new GetWorkoutAPIResponse();

                // Bad Request if data pass is null
                if (!ModelState.IsValid)
                {
                    apiResponse.StatusNOK();
                    apiResponse.SetMessage(validationErrors[0]);

                    return BadRequest(apiResponse);
                }

                // Get workout by Id
                WorkoutItemModel? item_form = _todoItems.FirstOrDefault(i => i.Id == ItemFormData.Id);

                // handle case where Item Id does not exist
                if (item_form == null)
                {
                    apiResponse.StatusNOK();
                    apiResponse.SetMessage($"Item with Id = {ItemFormData.Id} does not exist");

                    return NotFound(apiResponse);
                }
                else
                {
                    apiResponse.StatusOK();
                    apiResponse.SetWorkoutItem(item_form);
                    return Ok(apiResponse);
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
