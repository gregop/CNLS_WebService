using FitnessApp.Core.DataObjects.Interfaces;
using FitnessApp.Core.Orchestrators.Interfaces;
using FitnessApp.Core.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebService.Core.Web.Controllers
{
    [ApiController]
    public class ExerciseItemController : ControllerBase
    {
        private readonly IExerciseMessagesOrchestrator _exerciseMessagesOrchestrator;

        public ExerciseItemController(IExerciseMessagesOrchestrator exerciseMessagesOrchestrator)
        {
            _exerciseMessagesOrchestrator = exerciseMessagesOrchestrator;
        }

        [HttpPost]
        [Route("api/[action]")]
        [Produces("application/json")]
        public async Task<ActionResult<ICreateExerciceItemApiRes>> CreateExercise(object requestData)
        {

            try 
            {
                if(object.ReferenceEquals(requestData, null))
                {
                    return StatusCode(StatusCodes.Status400BadRequest);

                }
                
                string requestDataSerialized = JsonSerializer.Serialize(requestData);

                OperationalResult<ResponseContext<ICreateExerciceItemApiRes>> response = await _exerciseMessagesOrchestrator.HandleExerciseCreationMessagesAsync(requestDataSerialized);


                if (response.IsSuccessfulOperation && response.Data?.Response != null)
                {
                    return StatusCode(StatusCodes.Status200OK, response.Data.Response);
                }
                else if (response.IsSuccessfulOperation && response.Data?.Response == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, response.Data);
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
        public async Task<ActionResult<IGetExercisesApiRes>> GetExercises(object requestData)
        {
            try
            {
                if (object.ReferenceEquals(requestData, null))
                {
                    return StatusCode(StatusCodes.Status400BadRequest);

                }

                string requestDataSerialized = JsonSerializer.Serialize(requestData);

                OperationalResult<ResponseContext<IGetExercisesApiRes>> response = await _exerciseMessagesOrchestrator.HandleExerciseRequestMessagesAsync(requestDataSerialized);


                if (response.IsSuccessfulOperation && response.Data?.Response != null)
                {
                    return StatusCode(StatusCodes.Status200OK, response.Data.Response);
                }
                else if (response.IsSuccessfulOperation && response.Data?.Response == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, response.Data);
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
