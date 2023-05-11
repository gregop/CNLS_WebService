using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CNSL_WepService.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CNSL_WepService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        

        private readonly List<WorkoutModel> _todoItems = new List<WorkoutModel>
        {
            new WorkoutModel { Id = 1, Duration = 30, Distance = 3.58, Calories = 260, Date = new DateTime(2023, 5, 2, 18, 54, 00)},
            new WorkoutModel { Id = 2, Duration = 30, Distance = 3.84, Calories = 270, Date = new DateTime(2023, 5, 3, 18, 16, 00)},
            new WorkoutModel { Id = 3, Duration = 40, Distance = 8 }
        };


        [HttpPost]
        [Produces("application/json")]
        public ActionResult<IApiResponses> GetWorkout([FromForm] GetItem ItemFormData)
        {
            try
            {
                var modelStateErrors = this.ModelState.Keys
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
                    WorkoutNOk response = new WorkoutNOk();
                    response.Message = validationErrors[0];
                    return response;
                }

                // Get workout by Id
                WorkoutModel? item_form = _todoItems.FirstOrDefault(i => i.Id == ItemFormData.Id);

                // handle case where Item Id does not exist
                if (item_form == null)
                {
                    WorkoutNOk response = new WorkoutNOk();
                    response.Message = $"Item with Id = {ItemFormData.Id} does not exist";
                    //string result = JsonSerializer.Serialize(status404);
                    return response;
                }
                else
                {
                    return item_form;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR\t" + ex.Message);
                return BadRequest();

            }

        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<IApiResponses> RegisterWorkout([FromForm] WorkoutModel Workout)
        {
            try
            {
                //List<ValidationResult> ValidationResults = new List<ValidationResult>();
                //ValidationContext ValidationContect = new ValidationContext(Workout, null, null);
                //// Validate all object's properties
                //bool isValid = Validator.TryValidateObject(Workout, ValidationContect, ValidationResults, true);

                var modelStateErrors = this.ModelState.Keys
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
                        WorkoutNOk result = new WorkoutNOk();
                        // Set the Property Validation Message to the returned error model
                        //Console.WriteLine($"Message {ValidationResults[0].ErrorMessage.ToString()}");
                        //result.Message = ValidationResults[0].ErrorMessage.ToString();
                        result.Message = validationErrors[0];
                        return result;
                    }
                    else
                    {
                        return new WorkoutNOk();
                    }
                    
                    
                }
                Console.WriteLine(Workout.Id);
                // Bad Request if data pass is null
                if (Workout.Id == null)
                {
                    WorkoutNOk response = new WorkoutNOk();
                    Console.WriteLine(response.Status);
                    Console.WriteLine(response.Message);
                    
                    return response;
                }
                else
                {
                    WorkoutOk response = new WorkoutOk();
                    
                    Console.WriteLine(response.Status);
                    Console.WriteLine(response.Message);
                    Console.WriteLine(Workout.Distance);
                    Console.WriteLine(Workout.Calories);
                    // add workout to list
                    return response;
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR\t" + ex.Message);
                return BadRequest();
            }

        }


    }
}
