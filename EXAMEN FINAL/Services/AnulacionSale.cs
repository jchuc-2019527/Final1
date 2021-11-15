using ProyectoAPI.Context;
using ProyectoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Services
{
    public  class AnulacionSale
    {
        public bool ValidateAnulacion(int idAnu)
        {
            using (SQLDbContext Db = new SQLDbContext())
            {
                try
                {
                    bool existSale = Db.Venta.Count(c => c.CodigoVenta == idAnu) > 0;
                    if (existSale.Equals(true))
                    {
                        return true;
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
    }
}