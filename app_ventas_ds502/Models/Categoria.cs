using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ventas_ds502.Models
{
    [Table("ar_categoria")]
    public class Categoria
    {
        [Key]
        [Required(ErrorMessage = "El código de la categoría es obligatorio")]
        [StringLength(5, ErrorMessage = "El código de la categoría no puede exceder los 5 caracteres")]
        [Display(Name = "Código de Categoría")]
        public string codigo_categoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(30, ErrorMessage = "El nombre de la categoría no puede exceder los 30 caracteres")]
        [Display(Name = "Categoría")]
        public string categoria { get; set; }
    }
}
