using System.ComponentModel.DataAnnotations;

namespace UI.Blazor.Cliente.Models
{
    public class Producto
    {
        public int Id_Pro { get; set; }

        [Required(ErrorMessage = "El tipo es requerido")]
        public string Tip_Pro { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nom_Pro { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de expiración es requerida")]
        public DateTime Fec_Exp_Pro { get; set; } = DateTime.Now.AddMonths(6);

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor o igual a 0")]
        public int Can_Pro { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Pre_Uni { get; set; }
    }
}