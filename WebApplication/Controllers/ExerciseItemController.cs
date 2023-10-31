using FitnessApp.Core.DataObjects.Interfaces;
using FitnessApp.Core.Orchestrators.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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

            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
