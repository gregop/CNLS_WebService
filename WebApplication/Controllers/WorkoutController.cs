using FitnessApp.Core.ResourceAccess.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Core.DataObjects.Interfaces;
using CNSL_WepService.APIResponses;
using Microsoft.AspNetCore.Http;
using FitnessApp.Core.Orchestrators;
using System.Text.Json;

namespace CNSL_WepService.Controllers
{
    
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly WorkoutMessagesOrchestrator _workoutMessagesOrchestrator;

        public WorkoutController(WorkoutMessagesOrchestrator workoutMessagesOrchestrator) 
        {
            _workoutMessagesOrchestrator = workoutMessagesOrchestrator;
        }

        [HttpPost]
        [Route("api/[action]")]
        [Produces("application/json")]
        public async Task<ActionResult<IRegisterWorkoutApiRes>> CreateWorkout(object requestData)
        {
            try
            {
                if (requestData == null)
                {
                    return BadRequest();
                }

                string requestDataSerialized = JsonSerializer.Serialize(requestData);

                var response = await _workoutMessagesOrchestrator.HandleWorkoutCreationMessagesAsync(requestDataSerialized);


                return Ok();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return StatusCode((int)StatusCodes.Status500InternalServerError);
                    
            }


        }

    }
}