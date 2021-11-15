using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Models
{
    [Table("Ventas")]
    public class VentaModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoVenta { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        [MinLength(5)]
        public string Descripcion { get; set; }

        [Required]
        [ForeignKey("FK_Cliente_Venta")]
        public int CodigoCliente { get; set; }
        public ClienteModel FK_Cliente_Venta { get; set; }

        [Required]
        [ForeignKey("FK_Producto_Venta")]
        public int CodigoProducto { get; set; }
        public ProductoModel FK_Producto_Venta { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        [MinLength(5)]
        public string TipoVenta { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime FechaVenta { get; set; }

    }
}