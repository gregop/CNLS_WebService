using FitnessApp.Core.ResourceAccess.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Core.DataObjects.Interfaces;
using CNSL_WepService.APIResponses;
using Microsoft.AspNetCore.Http;
using FitnessApp.Core.Orchestrators;
using System.Text.Json;
using FitnessApp.Core.Validators;
using FitnessApp.Core.Orchestrators.Interfaces;

namespace CNSL_WepService.Controllers
{
    
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutMessagesOrchestrator _workoutMessagesOrchestrator;

        public WorkoutController(IWorkoutMessagesOrchestrator workoutMessagesOrchestrator) 
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
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                string requestDataSerialized = JsonSerializer.Serialize(requestData);

                OperationalResult<ResponseContext<IRegisterWorkoutApiRes>> response = await _workoutMessagesOrchestrator.HandleWorkoutCreationMessagesAsync(requestDataSerialized);

                if (response.IsSuccessfulOperation && response.Data?.Response != null) 
                {
                    return StatusCode(StatusCodes.Status200OK, response.Data.Response);
                } 
                else 
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
                    
            }


        }

        [HttpPost]
        [Route("api/[action]")]
        [Produces("application/json")]
        public async Task<ActionResult<IGetWorkoutApiRes>> GetWorkout(object requestData)
        {
            try
            {
                if (requestData == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                string requestDataSerialized = JsonSerializer.Serialize(requestData);

                OperationalResult<ResponseContext<IGetWorkoutApiRes>> response = await _workoutMessagesOrchestrator.HandleWorkoutRequestMessagesAsync(requestDataSerialized);



                if (response.IsSuccessfulOperation && response.Data?.Response != null)
                {
                    return StatusCode(StatusCodes.Status200OK, response.Data?.Response);
                }
                else if (response.IsSuccessfulOperation && response.Data?.Response == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, response.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}