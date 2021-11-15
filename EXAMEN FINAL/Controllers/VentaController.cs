using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoAPI.Context;
using ProyectoAPI.Models;
using ProyectoAPI.Services;

namespace ProyectoAPI.Controllers
{
    public class VentaController : ApiController
    {
        private SQLDbContext db = new SQLDbContext();

        // GET: api/Venta
        [HttpGet]
        [ResponseType(typeof(VentaModel))]
        public IHttpActionResult GetVentaModel(int id)
        {
            var getData = db.Venta.Where(w => w.CodigoVenta == id).Select(s => new
            {
                s.CodigoVenta,
                s.Descripcion,
                s.CodigoCliente,
                s.CodigoProducto,
                s.Cantidad,
                s.TipoVenta,
                s.FechaVenta
            }).ToList();

            if (getData == null)
                return Json("Datos no existen");
            else
                return Ok(getData);
        }

        // GET: api/Venta/5
        [HttpGet]
        [ResponseType(typeof(VentaModel))]
        public IHttpActionResult GetVentaModel()
        {
            var getData = db.Venta.Select(s => new
            {
                s.CodigoVenta,
                s.Descripcion,
                s.CodigoCliente,
                s.CodigoProducto,
                s.Cantidad,
                s.TipoVenta,
                s.FechaVenta
            }).ToList();

            if (getData == null)
                return Json("Datos no existen");
            else
                return Ok(getData);
        }


        // POST: api/Venta
        [HttpPost]
        [ResponseType(typeof(VentaModel))]
        public IHttpActionResult PostVentaModel(VentaModel ventaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool val = VerifySale.ValidateExists(ventaModel);
            if (val.Equals(true))
            {
                VerifySale.saveVenta(ventaModel);
                db.Venta.Add(ventaModel);
                db.SaveChanges();
            }
            else 
            {
                return Json("No se puede ingresar la venta");
            }          

            return Ok(ventaModel);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}