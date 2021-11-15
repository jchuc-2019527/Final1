using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Models
{
    [Table("AnulacionVentas")]
    public class AnulacionModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoAnulacion { get; set; }

        [Required(ErrorMessage = "Se requiere el Codigo de la Venta")]
        public int CodigoVenta { get; set; }

        [Required(ErrorMessage = "Se requiere la Fecha de Devolucion")]
        [Column(TypeName = "Date")]
        public DateTime FechaDevo { get; set; }
    }
}