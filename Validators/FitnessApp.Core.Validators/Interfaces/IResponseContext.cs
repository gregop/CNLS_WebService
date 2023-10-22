namespace FitnessApp.Core.Validators.Interfaces
{
    public interface IResponseContext<T>
    {
        T? Response { get; set; }
        int StatusCode { get; set; }
        string? StatusMessage { get; set; }
    }
}