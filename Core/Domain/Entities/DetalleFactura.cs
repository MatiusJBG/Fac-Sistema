namespace Core.Domain
{
    public class DetalleFactura
    {
        public int Id_Det_Fac { get; set; }
        public int Id_Fac_Per { get; set; }
        public int Id_Pro_Per { get; set; }
        public int Can_Com { get; set; }
        public int? Id_Act_Pro_Per { get; set; }

        public Factura Factura { get; set; } = null!;
        public Producto Producto { get; set; } = null!;
        public ActualizarProducto? Actualizacion { get; set; }
    }
}
