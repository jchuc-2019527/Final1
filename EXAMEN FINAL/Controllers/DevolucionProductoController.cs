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
    public class DevolucionProductoController : ApiController
    {
        private SQLDbContext db = new SQLDbContext();

        // GET: api/DevolucionProducto
        public IQueryable<DevolucionProductoModel> GetDevolucion()
        {
            return db.Devolucion;
        }

        // GET: api/DevolucionProducto/5
        [ResponseType(typeof(DevolucionProductoModel))]
        public IHttpActionResult GetDevolucionProductoModel(int id)
        {
            DevolucionProductoModel devolucionProductoModel = db.Devolucion.Find(id);
            if (devolucionProductoModel == null)
            {
                return NotFound();
            }

            return Ok(devolucionProductoModel);
        }

        // POST: api/DevolucionProducto
        [HttpPost]
        [ResponseType(typeof(DevolucionProductoModel))]
        public IHttpActionResult PostDevolucionProductoModel(DevolucionProductoModel devolucionProductoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Devoluciones dv = new Devoluciones();
            bool devo = dv.DevolucionesExists(devolucionProductoModel.CodigoVenta);
            if (devo == true)
            {
                var getProductID = db.Venta.Find(devolucionProductoModel.CodigoVenta).CodigoProducto;                    

                var updatePro = db.ProductoModels.Find(getProductID);
                updatePro.ExistenciaMinima = updatePro.ExistenciaMinima + devolucionProductoModel.CantidadDevolver;
                db.Entry(updatePro).State = EntityState.Modified;
                db.SaveChanges();

                db.Devolucion.Add(devolucionProductoModel);
                db.SaveChanges();
            }
            else
            {
                return Json("No existe");
            }

            return Ok(devolucionProductoModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DevolucionProductoModelExists(int id)
        {
            return db.Devolucion.Count(e => e.CodigoDevolucion == id) > 0;
        }
    }
}