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
using ProyectoAPI.Migrations;
using ProyectoAPI.Models;
using ProyectoAPI.Services;

namespace ProyectoAPI.Controllers
{
    public class AnulacionController : ApiController
    {
        private SQLDbContext db = new SQLDbContext();

        // GET: api/Anulacion
        public IQueryable<AnulacionModel> GetAnulacion()
        {
            return db.Anulacion;
        }

        //GET: api/Anulacion/5
        [HttpGet]
        [ResponseType(typeof(AnulacionModel))]
        public IHttpActionResult GetAnulacionModel(int id)
        {
            AnulacionModel anulacionModel = db.Anulacion.Find(id);
            if (anulacionModel == null)
            {
                return NotFound();
            }

            return Ok(anulacionModel);
        }

       // POST: api/Anulacion
       [HttpPost]
       [ResponseType(typeof(AnulacionModel))]
       public IHttpActionResult PostAnulacionModel(AnulacionModel anulacionModel)
       {
           if (!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }

           AnulacionSale anu = new AnulacionSale();
           bool anula = anu.ValidateAnulacion(anulacionModel.CodigoVenta);
            if (anula == true)
            {
                var getProductID = db.Venta.Find(anulacionModel.CodigoVenta);
                var updateProduct = db.ProductoModels.Find(getProductID.CodigoProducto);

                updateProduct.ExistenciaMinima = updateProduct.ExistenciaMinima + getProductID.Cantidad;
                db.Entry(updateProduct).State = EntityState.Modified;
                db.SaveChanges();

                var deteteSale = db.Venta.Find(anulacionModel.CodigoVenta);
                db.Entry(deteteSale).State = EntityState.Deleted;
                db.SaveChanges();

                db.Anulacion.Add(anulacionModel);
                db.SaveChanges();
            }
            else 
            {
                return Json("No existe la venta");
            }
            return Ok(anulacionModel);
       }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnulacionModelExists(int id)
        {
            return db.Anulacion.Count(e => e.CodigoAnulacion == id) > 0;
        }
    }
}