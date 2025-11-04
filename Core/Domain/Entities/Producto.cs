namespace Core.Domain
{
	public class Producto
	{
		public int Id_Pro {  get; set; }
		public string Tip_Pro { get; set; } = null!;
        public string Nom_Pro { get; set; } = null!;
        public DateTime Fec_Exp_Pro { get; set; }
        public int Can_Pro { get; set; }
        public decimal Pre_Uni { get; set; }
        public ICollection<ActualizarProducto> Actualizaciones { get; set; } = new List<ActualizarProducto>();
        public ICollection<EntradaProducto> Entradas { get; set; } = new List<EntradaProducto>();
        public ICollection<DetalleFactura> DetallesFactura { get; set; } = new List<DetalleFactura>();

    }
}
