namespace Core.Domain
{
    public class ActualizarProducto
    {
        public int Id_Act_Pro { get; set; }
        public int Id_Pro_Per { get; set; }
        public decimal Pre_Act_Pro { get; set; }
        public DateTime Fec_Act_Pro { get; set; }

        public Producto Producto { get; set; } = null!;
    }
}
