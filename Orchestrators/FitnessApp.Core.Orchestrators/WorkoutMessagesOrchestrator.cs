using FitnessApp.Core.Validators;
using FitnessApp.Core.DataObjects.Interfaces;
using CNSL_WepService.APIResponses;
using FitnessApp.Core.DataObjects;
using System.Text.Json;
using FitnessApp.Core.Orchestrators.Interfaces;
using FitnessApp.Core.DataObjects.Requests;
using FitnessApp.Core.Engines.Interfaces;
using System.ComponentModel.DataAnnotations;
using FitnessApp.Core.Validators.Interfaces;
using System;

namespace FitnessApp.Core.Orchestrators
{
    public class WorkoutMessagesOrchestrator : IWorkoutMessagesOrchestrator
    {
        private readonly IWorkoutItemEngine _workoutItemEngine;

        public WorkoutMessagesOrchestrator(IWorkoutItemEngine workoutItemEngine)
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

                // Parse payload to DataObject
                OperationalResult<WorkoutItemDataObject?> parsedPayload = PayloadParser<WorkoutItemDataObject>.TryParse(payload);

                // If parsing was not successful return error
                if (!parsedPayload.IsSuccessfulOperation)
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.FailureResult(response.Message);
                }

                WorkoutItemDataObject? workoutItem = parsedPayload.Data;

                // Validate parsed payload data
                OperationalResult <Tuple<bool, List<ValidationResult>>> isValidWorkoutItemPayload = DataValidator<WorkoutItemDataObject>.TryValidate(parsedPayload.Data);

                // If validation failed with exception return error
                if (!isValidWorkoutItemPayload.IsSuccessfulOperation)
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.FailureResult(response.Message ?? string.Empty);
                }
                else
                {
                    //If data validation failed return validation error
                    if (!isValidWorkoutItemPayload.Data.Item1 && isValidWorkoutItemPayload.Data.Item2.Any())
                    {
                        response.StatusNOK();
                        response.SetMessage(isValidWorkoutItemPayload.Data.Item2.First().ToString());

                        return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.SuccessResult(new ResponseContext<IRegisterWorkoutApiRes>()
                        {
                            StatusCode = 200,
                            StatusMessage = response.Message,
                            Response = null
                        });
                    }
                }

                
                // Send request object to Workout Engine
                if (workoutItem != null)
                {

                    OperationalResult<WorkoutItemDataObject> loggedWorkoutItem = await _workoutItemEngine.HandleWorkoutCreationAsync(workoutItem);

                    if (!loggedWorkoutItem.IsSuccessfulOperation)
                    {
                        response.StatusNOK();
                        response.SetMessage(loggedWorkoutItem.FailureMessage.ToString());

                        return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.FailureResult(response.Message);

                    } 
                    else
                    {
                        if (loggedWorkoutItem.Data != null)
                        {
                            workoutItem = loggedWorkoutItem.Data;

                            response.StatusOK(workoutItem.WorkoutId, workoutItem);

                            return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.SuccessResult(new ResponseContext<IRegisterWorkoutApiRes>()
                            {
                                StatusCode = 200,
                                StatusMessage = response.Message,
                                Response = response
                            });
                        }
                        else
                        {
                            response.StatusNOK();
                            response.SetMessage("error");

                            return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.FailureResult(response.Message);
                        }

                    }

                }
                else
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.FailureResult(response.Message);
                }


            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
                return OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>.FailureResult(ex);
            }


        }

        public async Task<OperationalResult<ResponseContext<IGetWorkoutApiRes>>> HandleWorkoutRequestMessagesAsync(string payload)
        {
            try
            {
                IGetWorkoutApiRes response = new GetWorkoutApiRes();

                if (payload == null)
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IGetWorkoutApiRes>>.FailureResult(response.Message);
                }

                // Parse payload to DataObject
                OperationalResult<GetWorkoutRequestDataObject?> parsedPayload = PayloadParser<GetWorkoutRequestDataObject?>.TryParse(payload);

                // If parsing was not successful return error
                if (!parsedPayload.IsSuccessfulOperation) 
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IGetWorkoutApiRes>>.FailureResult(response.Message);
                }

                
                GetWorkoutRequestDataObject? workoutId = parsedPayload.Data;
                // Validate parsed payload data
                OperationalResult<Tuple<bool, List<ValidationResult>>>? isValidRequestData = DataValidator<GetWorkoutRequestDataObject>.TryValidate(workoutId);

                // If validation failed with exception return error
                if(!isValidRequestData.IsSuccessfulOperation)
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IGetWorkoutApiRes>>.FailureResult(response.Message);
                } 
                else
                {
                    //If data validation failed return validation error
                    if (!isValidRequestData.Data.Item1 && isValidRequestData.Data.Item2.Any())
                    {
                        response.StatusNOK();
                        response.SetMessage(isValidRequestData.Data.Item2.First().ToString());

                        return OperationalResult<ResponseContext<IGetWorkoutApiRes>>.SuccessResult(new ResponseContext<IGetWorkoutApiRes>()
                        {
                            StatusCode = 200,
                            StatusMessage = response.Message,
                            Response = null
                        });
                    }
                }

                if (workoutId != null)
                {
                    OperationalResult<WorkoutItemDataObject> workout = await _workoutItemEngine.HandleWorkoutRequestAsync(new WorkoutItemDataObject
                    {
                        WorkoutId = workoutId.Id
                    });

                    if (workout.Data != null)
                    {
                        response.StatusOK();
                        response.SetWorkoutItem(workout.Data);

                        return OperationalResult<ResponseContext<IGetWorkoutApiRes>>.SuccessResult(new ResponseContext<IGetWorkoutApiRes>()
                        {
                            StatusCode = 200,
                            StatusMessage = response.Message,
                            Response = response
                        });
                    }

                    response.StatusNOK();
                    response.SetMessage(workout.FailureMessage);

                    return OperationalResult<ResponseContext<IGetWorkoutApiRes>>.SuccessResult(new ResponseContext<IGetWorkoutApiRes>()
                    {
                        StatusCode = 200,
                        StatusMessage = workout.FailureMessage,
                        Response = null
                    });

                } 
                else
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IGetWorkoutApiRes>>.FailureResult(response.Message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ResponseContext<IGetWorkoutApiRes>>.FailureResult(ex);
            }
        }
    }
}
