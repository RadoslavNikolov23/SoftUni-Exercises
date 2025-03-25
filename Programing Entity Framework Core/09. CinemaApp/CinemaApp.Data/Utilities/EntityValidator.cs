namespace CinemaApp.Data.Utilities
{
    using CinemaApp.Data.Utilities.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EntityValidator : IEntityValidator
    {
        private IList<string> errorMessage;
        public EntityValidator()
        {
            this.errorMessage = new List<string>();
        }
        public IReadOnlyCollection<string> ErrorMessage
            => this.errorMessage.AsReadOnly();

        public Task<bool> IsValid(object dto)
        {
            this.errorMessage = new List<string>();

            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResult, true);

            foreach (var error in validationResult)
            {
                if (!string.IsNullOrWhiteSpace(error.ErrorMessage))
                {
                    this.errorMessage.Add(error.ErrorMessage);
                }
            }

            return Task.FromResult(isValid);
        }

    }
}
