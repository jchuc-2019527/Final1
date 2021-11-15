using ProyectoAPI.Context;
using ProyectoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Services
{
    public static class VerifySale
    {
        public static bool ValidateExists(VentaModel model)
        {
            using (SQLDbContext Db = new SQLDbContext()) 
            {
                try
                {
                    bool existClient = Db.ClienteModel.Count(c => c.CodigoCliente == model.CodigoCliente) > 0;
                    if (existClient.Equals(true))
                    {
                        bool existProduct = Db.ProductoModels.Count(c => c.CodigoProducto == model.CodigoProducto) > 0;
                        if (existProduct.Equals(true))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else 
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
                finally 
                {
                    Db.Dispose();
                }
            }           
        }

        public static void saveVenta(VentaModel model)
        {
            using (SQLDbContext db = new SQLDbContext())
            {
                try
                {
                    var updateP = db.ProductoModels.Find(model.CodigoProducto);
                    updateP.ExistenciaMinima = updateP.ExistenciaMinima - model.Cantidad;
                    db.Entry(updateP).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}