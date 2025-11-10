using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class ProductoDto
    {
        [JsonPropertyName("id_Pro")]
        public int Id_Pro { get; set; }

        [JsonPropertyName("tip_Pro")]
        public string Tip_Pro { get; set; } = null!;

        [JsonPropertyName("nom_Pro")]
        public string Nom_Pro { get; set; } = null!;

        [JsonPropertyName("fec_Exp_Pro")]
        public DateTime Fec_Exp_Pro { get; set; }

        [JsonPropertyName("can_Pro")]
        public int Can_Pro { get; set; }

        [JsonPropertyName("pre_Uni")]
        public decimal Pre_Uni { get; set; }
    }

    public class CreateProductoDto
    {
        public string Tip_Pro { get; set; } = null!;
        public string Nom_Pro { get; set; } = null!;
        public DateTime Fec_Exp_Pro { get; set; }
        public int Can_Pro { get; set; }
        public decimal Pre_Uni { get; set; }
    }

    public class UpdateProductoDto
    {
        public string Tip_Pro { get; set; } = null!;
        public string Nom_Pro { get; set; } = null!;
        public DateTime Fec_Exp_Pro { get; set; }
        public int Can_Pro { get; set; }
        public decimal Pre_Uni { get; set; }
    }
}