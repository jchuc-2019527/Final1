using ProyectoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Context
{
    public class SQLDbContext : DbContext
    {
        public SQLDbContext() : base("ProyectoFinalDesarrollo") 
        { 

        }
        public DbSet<ClienteModel> ClienteModel { get; set; }
        public DbSet<ProductoModel> ProductoModels { get; set; }
        public DbSet<VentaModel> Venta { get; set; }
        public DbSet<DevolucionProductoModel> Devolucion { get; set; }
        public DbSet<AnulacionModel> Anulacion { get; set; }
    }
}