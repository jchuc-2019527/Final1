using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Models
{
    [Table("Devoluciones")]
    public class DevolucionProductoModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoDevolucion { get; set; }

        [Required]
        [ForeignKey("FK_Devoluciones_Venta")]
        public int CodigoVenta { get; set; }
        public VentaModel FK_Devoluciones_Venta { get; set; }

        [Required]
        public int CantidadDevolver { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime FechaDevolucion { get; set; }
    }
}