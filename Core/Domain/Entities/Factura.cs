namespace Core.Domain
{
    public class Factura
    {
        public int Id_Fac { get; set; }
        public DateTime Fec_Fac { get; set; }
        public string Ced_Cli_Per { get; set; } = null!;
        public decimal Tot_Fac { get; set; }

        public Cliente Cliente { get; set; } = null!;
        public ICollection<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
    }
}
