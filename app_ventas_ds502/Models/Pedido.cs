using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ventas_ds502.Models
{
    [Table("ar_pedido")]
    public class Pedido
    {
        [Key]
        [Required(ErrorMessage = "El código del pedido es obligatorio")]
        [StringLength(5, ErrorMessage = "El código del pedido no puede exceder los 5 caracteres")]
        [Display(Name = "Código de Pedido")]
        public string codigo_pedido { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }

        [Display(Name = "Código de Cliente")]
        [StringLength(5, ErrorMessage = "El código del cliente no puede exceder los 5 caracteres")]
        [ForeignKey("Cliente")]
        public string codigo_cliente { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
