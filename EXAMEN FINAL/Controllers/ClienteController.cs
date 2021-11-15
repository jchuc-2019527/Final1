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
    public class ClienteController : ApiController
    {
        private SQLDbContext db = new SQLDbContext();

        // GET: api/Cliente/
        [HttpGet]
        [ResponseType(typeof(ClienteModel))]
        public IHttpActionResult GetClienteModel(int id)
        {
            var getData = db.ClienteModel.Where(w => w.CodigoCliente == id).Select(s => new
            {
                s.CodigoCliente,
                s.NombresCliente,
                s.ApellidosCliente,
                s.NIT,
                s.EstadoCliente
            }).ToList();

            if (getData == null)
                return Json("Datos no existen");
            else
                return Ok(getData);
        }

        // GET: api/Cliente/5
        [HttpGet]
        [ResponseType(typeof(ClienteModel))]
        public IHttpActionResult GetClienteModel()
        {
            var getData = db.ClienteModel.Select(s => new
            {
                s.CodigoCliente,
                s.NombresCliente,
                s.ApellidosCliente,
                s.NIT,
                s.EstadoCliente
            }).ToList();

            if (getData == null)
                return Json("Datos no existen");
            else
                return Ok(getData);
        }

        // PUT: api/Cliente/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClienteModel(int id, ClienteModel clienteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clienteModel.CodigoCliente)
            {
                return BadRequest();
            }

            db.Entry(clienteModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(clienteModel);
        }

        // POST: api/Cliente
        [HttpPost]
        [ResponseType(typeof(ClienteModel))]
        public IHttpActionResult PostClienteModel(ClienteModel clienteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClienteModel.Add(clienteModel);
            db.SaveChanges();

            return Ok(clienteModel);
        }

        // DELETE: api/Cliente/5
        [HttpDelete]
        [ResponseType(typeof(ClienteModel))]
        public IHttpActionResult DeleteClienteModel(int id)
        {
            ClienteModel clienteModel = db.ClienteModel.Find(id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            db.ClienteModel.Remove(clienteModel);
            db.SaveChanges();

            return Ok(clienteModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteModelExists(int id)
        {
            return db.ClienteModel.Count(e => e.CodigoCliente == id) > 0;
        }
    }
}