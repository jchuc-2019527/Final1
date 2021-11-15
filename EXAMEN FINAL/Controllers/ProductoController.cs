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

namespace ProyectoAPI.Controllers
{
    public class ProductoController : ApiController
    {
        private SQLDbContext db = new SQLDbContext();
        
        //Consultar por ID
        [HttpGet]
        [ResponseType(typeof(ProductoModel))]
        public IHttpActionResult GetProductoModel(int id)
        {
            var getData = db.ProductoModels.Where(w => w.CodigoProducto == id).Select(s => new
            {
                s.CodigoProducto,
                s.Descripcion,
                s.FechaVencimiento,
            }).ToList();

            if (getData == null)
                return Json("Datos no existen");
            else
                return Ok(getData);
        }


        // GET: api/Producto/5  Consultar todos (INDEX)
        [HttpGet]
        [ResponseType(typeof(ProductoModel))]
        public IHttpActionResult GetProductoModel()
        {
            var getData = db.ProductoModels.Select(s => new
            {
                s.CodigoProducto,
                s.Descripcion,
                s.CodigoProveedor,
                s.FechaVencimiento,
                s.UbicacionFisica,
                s.ExistenciaMinima
            }).ToList();

            if (getData == null)
                return Json("Datos no existen");
            else
                return Ok(getData);
        }

        // PUT: api/Producto/5   MODIFY
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductoModel(int id, ProductoModel productoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productoModel.CodigoProducto)
            {
                return BadRequest();
            }

            db.Entry(productoModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(productoModel);
        }

        // POST: api/Producto CREATE
        [HttpPost]
        [ResponseType(typeof(ProductoModel))]
        public IHttpActionResult PostProductoModel(ProductoModel productoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductoModels.Add(productoModel);
            db.SaveChanges();

            return Ok(productoModel);
        }

        // DELETE: api/Producto/5
        [HttpDelete]
        [ResponseType(typeof(ProductoModel))]
        public IHttpActionResult DeleteProductoModel(int id)
        {
            ProductoModel productoModel = db.ProductoModels.Find(id);
            if (productoModel == null)
            {
                return NotFound();
            }

            db.ProductoModels.Remove(productoModel);
            db.SaveChanges();

            return Ok(productoModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoModelExists(int id)
        {
            return db.ProductoModels.Count(e => e.CodigoProducto == id) > 0;
        }
    }
}