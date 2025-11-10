namespace Application.DTOs
{
    public class FacturaDto
    {
        public int Id_Fac { get; set; }
        public DateTime Fec_Fac { get; set; }
        public string Ced_Cli_Per { get; set; } = null!;
        public decimal Tot_Fac { get; set; }
        public ClienteDto? Cliente { get; set; }
        public List<DetalleFacturaDto> Detalles { get; set; } = new();
    }

    public class CreateFacturaDto
    {
        public string Ced_Cli_Per { get; set; } = null!;
        public List<CreateDetalleFacturaDto> Detalles { get; set; } = new();
    }

    public class DetalleFacturaDto
    {
        public int Id_Det_Fac { get; set; }
        public int Id_Pro_Per { get; set; }
        public int Can_Com { get; set; }
        public ProductoDto? Producto { get; set; }
    }

    public class CreateDetalleFacturaDto
    {
        public int Id_Pro_Per { get; set; }
        public int Can_Com { get; set; }
    }
}