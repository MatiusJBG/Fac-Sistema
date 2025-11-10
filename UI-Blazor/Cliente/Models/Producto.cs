namespace UI.Blazor.Cliente.Models
{
    public class Producto
    {
        public int Id_Pro { get; set; } // Clave primaria
        public string Tip_Pro { get; set; } = string.Empty;
        public string Nom_Pro { get; set; } = string.Empty;
        public DateTime Fec_Exp_Pro { get; set; }
        public int Can_Pro { get; set; }
        public decimal Pre_Uni { get; set; }
    }
}
