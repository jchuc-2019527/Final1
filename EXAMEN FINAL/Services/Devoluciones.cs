using ProyectoAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPI.Services
{
    public class Devoluciones
    {
        public bool DevolucionesExists(int idV) 
        {
            using (SQLDbContext Db = new SQLDbContext())
            {
                try
                {
                    bool existVenta = Db.Venta.Count(c => c.CodigoVenta == idV) > 0;
                    if (existVenta.Equals(true))
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