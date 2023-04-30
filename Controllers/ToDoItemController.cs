using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CNSL_WepService.Models;
using System.Net.Http.Json;

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
        public JsonResult Get1(int Id)
        {
            try
            {
                Console.WriteLine("\n Get1 \n");
                ToDoItem? item = _todoItems.FirstOrDefault(i => i.Id == Id);
                if (item == null)
                {
                    return new JsonResult(NotFound());
                   
                }
                else
                {
                    string result = JsonSerializer.Serialize(item);
                    return new JsonResult(Ok(result)); 
                }

            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return new JsonResult(BadRequest());
                
            }
            
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<ToDoItem> Get2([FromBody] GetItem Item)
        {
            try
            {
                Console.WriteLine(Item.Id);
                int Id = Item.Id;
                Console.WriteLine("\n Get2 \n");
                if (Id == null)
                {
                    return BadRequest("Id cannot be null");
                }

                ToDoItem? item = _todoItems.FirstOrDefault(i => i.Id == Id);
                if (item == null)
                {
                    string result = JsonSerializer.Serialize(status404);
                    
                    return NotFound("The Item Id does not exist");

                }
                else
                {
                    string result = JsonSerializer.Serialize(item);
                    return item;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Gamoooto");
                Console.WriteLine(ex.Message);
                return BadRequest();

            }

        }

    }
}
