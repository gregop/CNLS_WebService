using FitnessApp.Core.DataObjects;
using FitnessApp.Core.DataObjects.APIResponses;
using FitnessApp.Core.DataObjects.Interfaces;
using FitnessApp.Core.DataObjects.Requests;
using FitnessApp.Core.Engines.Interfaces;
using FitnessApp.Core.Orchestrators.Interfaces;
using FitnessApp.Core.ResourceAccess.Interfaces;
using FitnessApp.Core.Validators;
using FitnessApp.Core.Validators.Interfaces;
using FitnessApp.Core.Validators.ValidationHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Orchestrators
{
    public class ExerciseMessagesOrchestrator : IExerciseMessagesOrchestrator
    {
        private readonly IExerciseItemEngine _exerciseItemEngine;

        public ExerciseMessagesOrchestrator(IExerciseItemEngine exerciseItemEngine)
        {
            _exerciseItemEngine = exerciseItemEngine;
        }

        public async Task<OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>> HandleExerciseCreationMessagesAsync(string payload)
        {
            try
            {
                ICreateExerciceItemApiRes response = new CreateExerciceItemApiRes();

                if(payload == null) 
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>.FailureResult(response.Message ?? string.Empty);

                }

                // Parse payload to DataObject
                OperationalResult<ExerciseItemDataObject?> parsedPayload = PayloadParser<ExerciseItemDataObject>.TryParse(payload);

                // If parsing was not successful return error
                if (!parsedPayload.IsSuccessfulOperation)
                {

                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>.FailureResult(response.Message ?? string.Empty);

                }

                // Validate parsed payload data
                ExerciseItemDataObject? exerciseItem = parsedPayload.Data;
                OperationalResult<Tuple<bool, List<ValidationResult>>> isValidExerciseItem = DataValidator<ExerciseItemDataObject>.TryValidate(exerciseItem);

                // If validation failed with exception return error
                if (!isValidExerciseItem.IsSuccessfulOperation)
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>.FailureResult(response.Message ?? string.Empty);
                }
                else
                {
                    if (!isValidExerciseItem.Data.Item1 && isValidExerciseItem.Data.Item2.Any())
                    {
                        response.StatusNOK();
                        response.SetMessage(isValidExerciseItem.Data.Item2.First().ToString());

                        return OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>.SuccessResult(new ResponseContext<ICreateExerciceItemApiRes>
                        {
                            StatusCode = 200,
                            StatusMessage = response.Message,
                            Response = null,
                        });

                    }
                }


                // Send request object to Workout Engine
                if (exerciseItem != null)
                {
                    OperationalResult<ExerciseItemDataObject> loggedExerciseItem = await _exerciseItemEngine.HandleExerciseCreationAsync(exerciseItem);

                    if (!loggedExerciseItem.IsSuccessfulOperation && !String.IsNullOrWhiteSpace(loggedExerciseItem.FailureMessage))
                    {
                        response.StatusNOK();
                        response.SetMessage(loggedExerciseItem.FailureMessage ?? "error");

                        return OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>.SuccessResult(new ResponseContext<ICreateExerciceItemApiRes>
                        {
                            StatusCode = 200,
                            StatusMessage = response.Message,
                            Response = null,
                        });
                    }

                    if (loggedExerciseItem.Data != null)
                    {

                        exerciseItem = loggedExerciseItem.Data;

                        response.StatusOK(exerciseItem);

                        return OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>.SuccessResult(new ResponseContext<ICreateExerciceItemApiRes> 
                        {  
                            StatusCode = 200,
                            StatusMessage = response.Message,
                            Response = response,
                        });
                    }
                    else
                    {
                        response.StatusNOK();
                        response.SetMessage("error");

                        return OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>.FailureResult(response.Message ?? string.Empty);
                    }


                }
                else
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>.FailureResult(response.Message ?? string.Empty);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>.FailureResult(ex.Message);
            }

        }

        public async Task<OperationalResult<ResponseContext<IGetExercisesApiRes>>> HandleExerciseRequestMessagesAsync(string payload)
        {
            try
            {
                IGetExercisesApiRes response = new GetExercisesApiRes();

                if (String.IsNullOrWhiteSpace(payload))
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IGetExercisesApiRes>>.FailureResult(response.Message ?? String.Empty);
                }

                // Parse payload to DataObject
                OperationalResult<GetExercisesRequestDataObject?> parsedPayload = PayloadParser<GetExercisesRequestDataObject>.TryParse(payload);

                // If parsing was not successful return error
                if (!parsedPayload.IsSuccessfulOperation)
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IGetExercisesApiRes>>.FailureResult(response.Message ?? String.Empty);
                }

                // Validate parsed payload data
                GetExercisesRequestDataObject? requestDataObject = parsedPayload.Data;
                OperationalResult<Tuple<bool, List<ValidationResult>>> isValidRequestDataObject = DataValidator<GetExercisesRequestDataObject>.TryValidate(requestDataObject);

                // If validation failed with exception return error
                if (!isValidRequestDataObject.IsSuccessfulOperation)
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IGetExercisesApiRes>>.FailureResult(response.Message ?? String.Empty);
                }
                else
                {
                    if (isValidRequestDataObject.Data.Item1 && isValidRequestDataObject.Data.Item2.Any())
                    {
                        response.StatusNOK();
                        response.SetMessage(isValidRequestDataObject.Data?.Item2?.FirstOrDefault()?.ToString() ?? String.Empty);

                        return OperationalResult<ResponseContext<IGetExercisesApiRes>>.SuccessResult(new ResponseContext<IGetExercisesApiRes>
                        {
                            StatusCode = 200,
                            StatusMessage = response.Message,
                            Response = null,

                        });
                    }
                }


                // Send request object to Workout Engine
                if (requestDataObject != null)
                {
                    OperationalResult<List<ExerciseItemDataObject>> exerciseItems = await _exerciseItemEngine.HandleExercisesRequestAsync(requestDataObject);

                    if (!exerciseItems.IsSuccessfulOperation && !String.IsNullOrWhiteSpace(exerciseItems.FailureMessage))
                    {
                        response.StatusNOK();
                        response.SetMessage(exerciseItems.FailureMessage ?? "error");

                        return OperationalResult<ResponseContext<IGetExercisesApiRes>>.SuccessResult(new ResponseContext<IGetExercisesApiRes>
                        {
                            StatusCode = 200,
                            StatusMessage = response.Message,
                            Response = null,
                        });
                    }

                    if (exerciseItems.Data != null)
                    {

                        response.StatusOK();
                        response.SetWorkoutItems(exerciseItems.Data);

                        return OperationalResult<ResponseContext<IGetExercisesApiRes>>.SuccessResult(new ResponseContext<IGetExercisesApiRes>
                        {
                            StatusCode = 200,
                            StatusMessage = response.Message,
                            Response = response,
                        });
                    }
                    else
                    {
                        response.StatusNOK();
                        response.SetMessage("error");

                        return OperationalResult<ResponseContext<IGetExercisesApiRes>>.FailureResult(response.Message ?? string.Empty);
                    }

                }
                else
                {
                    response.StatusNOK();
                    response.SetMessage("error");

                    return OperationalResult<ResponseContext<IGetExercisesApiRes>>.FailureResult(response.Message ?? string.Empty);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ResponseContext<IGetExercisesApiRes>>.FailureResult(ex.Message);
            }
        }

        public async Task<OperationalResult<ResponseContext<ExerciseItemDataObject>>> HandleExerciseUpdateMessagesAsync(string payload)
        {
            return null;
        }

    }
}
