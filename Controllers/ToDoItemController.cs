using Microsoft.AspNetCore.Mvc;
using CNSL_WepService.Models;
using CNSL_WepService.Interfaces;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CNSL_WepService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        

        private readonly List<CardioWorkoutModel> _todoItems = new List<CardioWorkoutModel>
        {
            new CardioWorkoutModel { Id = 1, Duration = 30, Distance = 3.58, Calories = 260, Date = new DateTime(2023, 5, 2, 18, 54, 00)},
            new CardioWorkoutModel { Id = 2, Duration = 30, Distance = 3.84, Calories = 270, Date = new DateTime(2023, 5, 3, 18, 16, 00)},
            new CardioWorkoutModel { Id = 3, Duration = 40, Distance = 8 }
        };
        

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<IApiResponse> GetCardioWorkout([FromForm] GetWorkoutById ItemFormData)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                Console.WriteLine(connectionString);

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
                    CardioWorkoutNOk response = new CardioWorkoutNOk();
                    response.Message = validationErrors[0];

                    return BadRequest(response);
                }

                // Get workout by Id
                CardioWorkoutModel? item_form = _todoItems.FirstOrDefault(i => i.Id == ItemFormData.Id);

                // handle case where Item Id does not exist
                if (item_form == null)
                {
                    CardioWorkoutNOk response = new CardioWorkoutNOk();
                    response.Message = $"Item with Id = {ItemFormData.Id} does not exist";
                    //string result = JsonSerializer.Serialize(status404);
                    return NotFound(response);
                }
                else
                {
                    return Ok(item_form);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR\t" + ex.Message);
                return BadRequest(ex.Message);

            }

        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<IApiResponse> RegisterCardioWorkout([FromForm] CardioWorkoutModel Workout)
        {
            try
            {
                //List<ValidationResult> ValidationResults = new List<ValidationResult>();
                //ValidationContext ValidationContect = new ValidationContext(Workout, null, null);
                //// Validate all object's properties
                //bool isValid = Validator.TryValidateObject(Workout, ValidationContect, ValidationResults, true);

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
                        CardioWorkoutNOk result = new CardioWorkoutNOk();
                        // Set the Property Validation Message to the returned error model
                        //Console.WriteLine($"Message {ValidationResults[0].ErrorMessage.ToString()}");
                        //result.Message = ValidationResults[0].ErrorMessage.ToString();
                        result.Message = validationErrors[0];
                       
                        return BadRequest(result);
                    }
                    else
                    {
                        CardioWorkoutNOk result = new CardioWorkoutNOk();
                        result.Message = "Model Invalid. Something went wrong. Please contact us.";
                        return BadRequest(result);
                        
                    }
                    
                    
                }
                Console.WriteLine(Workout.Id);

                // Bad Request if data pass is null
                if (Workout.Id == null)
                {
                    CardioWorkoutNOk response = new CardioWorkoutNOk();
                    Console.WriteLine(response.Status);
                    Console.WriteLine(response.Message);
                    
                    return response;
                }
                else
                {
                    CardioWorkoutOk response = new CardioWorkoutOk();
                    
                    Console.WriteLine(response.Status);
                    Console.WriteLine(response.Message);
                    Console.WriteLine(Workout.Distance);
                    Console.WriteLine(Workout.Calories);
                    // add workout to list
                    return Ok(response);
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
