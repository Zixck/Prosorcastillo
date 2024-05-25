using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_ventas_ds502.Models
{
    [Table("tb_personal")]
    public class Personal
    {
        [Key]
        [Required]
        [MinLength(8, ErrorMessage = "Escriba número de DNI")]
        [Display(Name = "Número DNI")]

        public String dni { get; set; }

        [Required(ErrorMessage = "Escriba el apellido Paterno")]
        [StringLength(25)]
        [Display(Name = "Apellido Paterno")]

        public String ap_paterno { get; set; }

        [Required(ErrorMessage = "Escrbia su apellido  materno")]
        [StringLength(25)]
        [Display(Name = "APELLIDO MATERNO")]
        public String ap_materno { get; set; }

        [Required(ErrorMessage = "Escriba nombre")]
        [StringLength(25)]
        [Display(Name = "Nombre")]

        public String nombre { get; set; }

        [Display(Name = "Género")]
        public String genero { get; set; }

        [Required(ErrorMessage = "Elija fecha de nacimineto")]
        [Display(Name = "Fecha de Nacimineto")]
        [DataType(DataType.Date)]

        public DateTime fecha_nacimiento { get; set; }

        [Required(ErrorMessage = "Ingrese sueldo")]
        [Display(Name = "Sueldo")]

        public double sueldo { get; set; }
    }
}

