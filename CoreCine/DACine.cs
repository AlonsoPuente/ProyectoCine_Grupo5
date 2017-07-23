using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DACine
    {
       
        static public List<Cine> ListadoCine()
        {
            List<Cine> listadoCine = new List<Cine>();
            using (var data = new CineDATABASEEntities())
            {

                listadoCine = data.Cine.ToList();

            }

            return listadoCine;
        }
        /// Listado de Cine
        //////////////////////////////////////////////////////



    }
}
