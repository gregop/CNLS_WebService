namespace FitnessApp.Core.Validators
{
    public interface IOperationalResult<T>
    {
        T? Data { get; }
        Exception? Exception { get; }
        string? FailureMessage { get; }
        bool IsSuccessfulOperation { get; }

    }
}