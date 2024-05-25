using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ventas_ds502.Models
{
    [Table("tb_producto")]
    public class Producto
    {
        [Key]
        [Required(ErrorMessage = "Ingrese el código del producto")]
        [StringLength(5)]
        [Display(Name = "Código del Producto")]
        public string codigo_producto { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del producto")]
        [StringLength(40)]
        [Display(Name = "Producto")]
        public string producto { get; set; }

        [Display(Name = "Stock Disponible")]
        public int stock_disponible { get; set; }

        [Required(ErrorMessage = "Ingrese el costo del producto")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Costo")]
        public decimal costo { get; set; }

        [Required(ErrorMessage = "Ingrese la ganancia del producto")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Ganancia")]
        public decimal ganancia { get; set; }

        [Required(ErrorMessage = "Ingrese el código de marca del producto")]
        [StringLength(5)]
        [Display(Name = "Código de Marca")]
        public string producto_codigo_marca { get; set; }

        [Required(ErrorMessage = "Ingrese el código de categoría del producto")]
        [StringLength(5)]
        [Display(Name = "Código de Categoría")]
        public string producto_codigo_categoria { get; set; }
    }
}
