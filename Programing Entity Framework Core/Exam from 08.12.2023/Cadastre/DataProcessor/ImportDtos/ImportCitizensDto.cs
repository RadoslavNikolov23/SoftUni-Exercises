namespace Cadastre.DataProcessor.ImportDtos
{
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using static Cadastre.Common.CadastreValidations.CitizenValidations;

    [JsonObject(nameof(Citizen))]
    public class ImportCitizensDto
    {

        [Required]
        [MinLength(citizenFirstNameMinLength)]
        [MaxLength(citizenFirstNameMaxLength)]
        [JsonPropertyName(nameof(FirstName))]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(citizenLastNameMinLength)]
        [MaxLength(citizenLastNameMaxLength)]
        [JsonPropertyName(nameof(LastName))]
        public string LastName { get; set; } = null!;

        [Required]
        [JsonPropertyName(nameof(BirthDate))]
        public string BirthDate { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(MaritalStatus))]
        [JsonPropertyName(nameof(MaritalStatus))]
        public string MaritalStatus { get; set; } = null!;

        [Required]
        [JsonPropertyName(nameof(Properties))]
        public int[] Properties { get; set; } = null!;
    }
}
