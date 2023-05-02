using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CNSL_WepService.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;

namespace CNSL_WepService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        

        private readonly List<WorkoutModel> _todoItems = new List<WorkoutModel>
        {
            new WorkoutModel { Id = 1, Duration = 30, Distance = 3.58, Calories = 260, Date = new DateTime(2023, 5, 2, 18, 54, 00) },
            new WorkoutModel { Id = 2, Duration = 30, Distance = 8, Calories = 500 },
            new WorkoutModel { Id = 3, Duration = 40, Distance = 8 }
        };

        private Dictionary<string, string> status404 = new Dictionary<string, string>
        {
            { "stadusCode", "404" },
            { "Message", "The Item Id does not exist" },
        };


        [HttpPost]
        [Produces("application/json")]
        public ActionResult<WorkoutModel> Get2([FromForm] GetItem ItemFormData)
        {
            try
            {
                // Bad Request if data pass is null
                if (ItemFormData == null)
                {
                    return BadRequest("Id cannot be null");
                }

                //ToDoItem? item_raw = _todoItems.FirstOrDefault(i => i.Id == ItemRaw.Id);
                WorkoutModel? item_form = _todoItems.FirstOrDefault(i => i.Id == ItemFormData.Id);

                // handle case where Item Id does not exist
                if (//item_raw == null &&
                    item_form == null)
                {
                    //string result = JsonSerializer.Serialize(status404);
                    return NotFound("The Item Id does not exist");
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

        
    }
}
