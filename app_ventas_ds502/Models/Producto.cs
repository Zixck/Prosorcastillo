using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ventas_ds502.Models
{
    [Table("ar_producto")]
    public class Producto
    {
        [Key]
        [Required(ErrorMessage = "El código del producto es obligatorio")]
        [StringLength(5, ErrorMessage = "El código del producto no puede exceder los 5 caracteres")]
        [Display(Name = "Código de Producto")]
        public string codigo_producto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(40, ErrorMessage = "El nombre del producto no puede exceder los 40 caracteres")]
        [Display(Name = "Producto")]
        public string producto { get; set; }

        [StringLength(3, ErrorMessage = "La talla del producto no puede exceder los 3 caracteres")]
        [Display(Name = "Talla")]
        public string talla { get; set; }

        [Display(Name = "Stock Disponible")]
        public int stock_disponible { get; set; }

        [Display(Name = "Costo")]
        public float costo { get; set; }

        [Display(Name = "Ganancia")]
        public float ganancia { get; set; }

        [Display(Name = "Código de Categoría")]
        [ForeignKey("Categoria")]
        public string codigo_categoria { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
