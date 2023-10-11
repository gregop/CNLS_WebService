using System.ComponentModel;

namespace FitnessApp.Core.Validators
{
    public class OperationalResult<T>
    {
        public bool IsSuccessfulOperation { get; protected set; }
        public T? Data { get; protected set; }
        public string? FailureMessage { get; protected set; }
        public Exception? Exception { get; protected set; }

        public OperationalResult(bool isSuccessfulOperation = true, T? data = default)
        {
            IsSuccessfulOperation = isSuccessfulOperation;
            FailureMessage = null;
            Exception = null;
            Data = data;
        }

        public OperationalResult(string messsage)
        {
            IsSuccessfulOperation = false;
            FailureMessage = messsage;
            Exception = null;
        }

        public OperationalResult(Exception ex)
        {
            IsSuccessfulOperation = false;
            FailureMessage = ex.Message.ToString();
            Exception = ex;
        }


        public static OperationalResult<T> SuccessResult(T data)
        {
            return new OperationalResult<T>(true, data);
        }

        public static OperationalResult<T> FailureResult(string message)
        {
            return new OperationalResult<T>(message);
        }

        public static OperationalResult<T> FailureResult(Exception ex)
        {
            return new OperationalResult<T>(ex);
        }
    }
}
