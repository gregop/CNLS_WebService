namespace FitnessApp.Core.Validators
{
    public class OperationalResult
    {
        public bool IsSuccessfulOperation { get; protected set; }
        public string? FailureMessage { get; protected set; }
        public Exception? Exception { get; protected set; }
        public object? Data { get; protected set; }

        public OperationalResult() 
        {
            IsSuccessfulOperation = true;
            FailureMessage = null;
            Exception = null;
            Data = null;
        }
        public OperationalResult(object data)
        {
            IsSuccessfulOperation = true;
            FailureMessage = null;
            Exception = null;
            Data = data;
        }

        public OperationalResult(string messsage)
        {
            IsSuccessfulOperation = false;
            FailureMessage = messsage;
            Exception = null;
            Data = null;
        }

        public OperationalResult(Exception ex)
        {
            IsSuccessfulOperation = false;
            FailureMessage = ex.Message;
            Exception = ex;
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
