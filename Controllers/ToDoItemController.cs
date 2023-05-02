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
        

        private readonly List<ToDoItem> _todoItems = new List<ToDoItem>
        {
            new ToDoItem { Id = 1, Description = "Item 1", IsComplete = false },
            new ToDoItem { Id = 2, Description = "Item 2", IsComplete = false },
            new ToDoItem { Id = 3, Description = "Item 3", IsComplete = true }
        };

        private Dictionary<string, string> status404 = new Dictionary<string, string>
        {
            { "stadusCode", "404" },
            { "Message", "The Item Id does not exist" },
        };


        [HttpPost]
        [Produces("application/json")]
        public ActionResult<ToDoItem> Get2([FromForm] GetItem ItemFormData)
        {
            try
            {
                // Bad Request if data pass is null
                if (ItemFormData == null)
                {
                    return BadRequest("Id cannot be null");
                }

                //ToDoItem? item_raw = _todoItems.FirstOrDefault(i => i.Id == ItemRaw.Id);
                ToDoItem? item_form = _todoItems.FirstOrDefault(i => i.Id == ItemFormData.Id);

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
