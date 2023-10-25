using FitnessApp.Core.Validators;
using FitnessApp.Core.DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Core.Validators.Interfaces;
using CNSL_WepService.APIResponses;
using FitnessApp.Core.Engines;
using FitnessApp.Core.DataObjects;
using System.Text.Json;
using FitnessApp.Core.Orchestrators.Interfaces;

namespace FitnessApp.Core.Orchestrators
{
    public class WorkoutMessagesOrchestrator : IWorkoutMessagesOrchestrator
    {
        private readonly WorkoutItemEngine _workoutItemEngine;

        public WorkoutMessagesOrchestrator(WorkoutItemEngine workoutItemEngine)
        {
            _workoutItemEngine = workoutItemEngine;
        }

        public async Task<OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>> HandleWorkoutCreationMessagesAsync(string payload)
        {

            try
            {

                IRegisterWorkoutApiRes response = new RegisterWorkoutApiRes();

                if (payload == null)
                {

                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.FailureResult(response.Message);
                }

                // Send request object to Workout Engine

                response.StatusOK(1);

                WorkoutItemDataObject workoutItem = JsonSerializer.Deserialize<WorkoutItemDataObject>(payload);


                return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.SuccessResult(new ResponseContext<IRegisterWorkoutApiRes>
                {
                    StatusCode = 200,
                    StatusMessage = response.Message,
                    Response = response
                });


            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
                return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.FailureResult(ex);
            }


        }

        public async Task<OperationalResult<ResponseContext<IGetWorkoutApiRes>>> HandleWorkoutRequestMessagesAsync(string payload)
        {
            throw new NotImplementedException();
        }
    }
}
