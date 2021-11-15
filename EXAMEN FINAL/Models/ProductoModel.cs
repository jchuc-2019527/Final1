using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ProyectoAPI.Models
{
    [Table("Productos")]
    public class ProductoModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoProducto { get; set; }

        [Required(ErrorMessage = "Se requiere una Descripcion")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [MinLength(25)]
        [Index("INDEX_DESCRIPCION", IsUnique = true)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Se requiere Codigo Proveedor")]
        public int CodigoProveedor { get; set; }

        [Required(ErrorMessage = "Se requiere Fecha de Vencimiento")]
        [Column(TypeName = "Date")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "Se requiere UbicacionFisica")]
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        [MinLength(15)]
        public string UbicacionFisica { get; set; }

        [Required(ErrorMessage = "Se requiere una cantidad minima")]
        public int ExistenciaMinima { get; set; }

    }
}   