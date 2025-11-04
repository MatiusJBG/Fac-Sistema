namespace Core.Domain
{
    public class EntradaProducto
    {
        public int Id_Ent_Pro { get; set; }
        public int Id_Pro_Per { get; set; }
        public DateTime Fec_Ent_Pro { get; set; }
        public int Can_Ent_Pro { get; set; }
        public int Can_Dis { get; set; }

        public Producto Producto { get; set; } = null!;
    }
}
