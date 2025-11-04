namespace Core.Domain
{
    public class Cliente
    {
        public string Ced_Cli { get; set; } = null!;
        public string Nom_Cli { get; set; } = null!;
        public string Ape_Cli { get; set; } = null!;
        public string Ruc_Cli { get; set; } = string.Empty;
        public string Dir_Cli { get; set; } = null!;
        public string Cor_Cli { get; set; } = null!;
        public string Tel_Cli { get; set; } = null!;

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
