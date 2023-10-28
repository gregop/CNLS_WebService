using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnessApp.Core.Validators
{
    public static class PayloadParser<T>
    {
        private static string? _payload;

        private static T? _parsedPayload;

        public static OperationalResult<T?> TryParse(string payload)
        {
            try
            {
                if (payload == null) { throw new NullReferenceException(); }

                _payload = payload.Trim();
                _parsedPayload = JsonSerializer.Deserialize<T>(_payload);

                return OperationalResult<T?>.SuccessResult(_parsedPayload);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception at {nameof(PayloadParser<T>)} : {ex.Message}");
                return OperationalResult<T?>.FailureResult(ex);
            }
            
        }

    }
}
