using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Models
{
    [Table("Clientes")]
    public class ClienteModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoCliente { get; set; }

        [Required(ErrorMessage = "Se Requiere el Nombre")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_NOMBRE_CLIENTE", IsUnique = true, Order = 1)]
        public string NombresCliente { get; set; }

        [Required(ErrorMessage = "Se Requiere el Apellido")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_APELLIDO_CLIENTE", IsUnique = true, Order = 2)]
        public string ApellidosCliente { get; set; }

        [Required(ErrorMessage = "Se Requiere el NIT")]
        [Column(TypeName = "Varchar")]
        [StringLength(9)]
        [MinLength(8)]
        [Index("INDEX_NIT_CLIENTE", IsUnique = true, Order = 3)]
        [Index("INDEX_NIT", IsUnique = true)]
        public string NIT { get; set; }

        [Required(ErrorMessage = "Se Requiere Dirección")]
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        [MinLength(25)]
        public string DireccionCliente { get; set; }

        [Required(ErrorMessage = "Se Requiere Categoria")]
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        [MinLength(3)]
        public string CategoriaCliente { get; set; }

        [Required(ErrorMessage = "Se Requiere Estado")]
        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        [MinLength(1)]
        public string EstadoCliente { get; set; }
    }
}