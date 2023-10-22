using FitnessApp.Core.Validators;
using FitnessApp.Core.DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Core.Validators.Interfaces;
using CNSL_WepService.APIResponses;

namespace FitnessApp.Core.Orchestrators
{
    public class WorkoutMessagesOrchestrator
    {
        public WorkoutMessagesOrchestrator()
        {
            
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


                response.StatusOK(1);

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
    }
}
