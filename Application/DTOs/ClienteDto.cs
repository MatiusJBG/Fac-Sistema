using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class ClienteDto
    {
        [JsonPropertyName("ced_Cli")]
        public string Ced_Cli { get; set; } = null!;

        [JsonPropertyName("nom_Cli")]
        public string Nom_Cli { get; set; } = null!;

        [JsonPropertyName("ape_Cli")]
        public string Ape_Cli { get; set; } = null!;

        [JsonPropertyName("ruc_Cli")]
        public string Ruc_Cli { get; set; } = string.Empty;

        [JsonPropertyName("dir_Cli")]
        public string Dir_Cli { get; set; } = null!;

        [JsonPropertyName("cor_Cli")]
        public string Cor_Cli { get; set; } = null!;

        [JsonPropertyName("tel_Cli")]
        public string Tel_Cli { get; set; } = null!;
    }

    public class CreateClienteDto
    {
        public string Ced_Cli { get; set; } = null!;
        public string Nom_Cli { get; set; } = null!;
        public string Ape_Cli { get; set; } = null!;
        public string Ruc_Cli { get; set; } = string.Empty;
        public string Dir_Cli { get; set; } = null!;
        public string Cor_Cli { get; set; } = null!;
        public string Tel_Cli { get; set; } = null!;
    }

    public class UpdateClienteDto
    {
        public string Nom_Cli { get; set; } = null!;
        public string Ape_Cli { get; set; } = null!;
        public string Ruc_Cli { get; set; } = string.Empty;
        public string Dir_Cli { get; set; } = null!;
        public string Cor_Cli { get; set; } = null!;
        public string Tel_Cli { get; set; } = null!;
    }
}