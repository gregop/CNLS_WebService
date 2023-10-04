namespace FitnessApp.Core.Validators
{
    public class OperationalResult
    {
        public bool IsSuccessfulOperation { get; protected set; }
        public string? FailureMessage { get; protected set; }
        public Exception? exception { get; protected set; }
        public object? Data { get; protected set; }

        public OperationalResult() 
        {
            IsSuccessfulOperation = true;
            FailureMessage = null;
            exception = null;
            Data = null;
        }
        public OperationalResult(object data)
        {
            IsSuccessfulOperation = true;
            FailureMessage = null;
            exception = null;
            Data = data;
        }

        public OperationalResult(string messsage)
        {
            IsSuccessfulOperation = false;
            FailureMessage = messsage;
            exception = null;
            Data = null;
        }

        public OperationalResult(Exception ex)
        {
            IsSuccessfulOperation = false;
            FailureMessage = ex.Message;
            exception = ex;
            Data = null;
        }


        public static OperationalResult SuccessResult(object data)
        {
            return new OperationalResult(data);
        }

        public static OperationalResult FailureResult(string message)
        {
            return new OperationalResult(message);
        }

        public static OperationalResult FailureResult(Exception ex)
        {
            return new OperationalResult(ex);
        }
    }
}
