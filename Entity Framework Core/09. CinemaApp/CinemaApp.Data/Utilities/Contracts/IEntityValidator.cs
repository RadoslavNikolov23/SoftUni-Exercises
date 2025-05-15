namespace CinemaApp.Data.Utilities.Contracts
{
    public interface IEntityValidator
    {
        IReadOnlyCollection<string> ErrorMessage { get; }

        Task<bool> IsValid(object entity);
    }
}
