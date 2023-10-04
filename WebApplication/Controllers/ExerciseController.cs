using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CNSL_WepService.Models;

namespace CNSL_WepService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        [HttpPost]
        [Produces("application/json")]
        public ActionResult<ExerciseModel> CreateExercise([FromForm] ExerciseModel exerciseModel)
        {
            return exerciseModel;
        }
    }
}
