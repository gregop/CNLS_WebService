namespace FitnessApp.Core.Validators.Interfaces
{
    public interface IOperationalResult<T>
    {
        T? Data { get; }
        Exception? Exception { get; }
        string? FailureMessage { get; }
        bool IsSuccessfulOperation { get; }

    }
}