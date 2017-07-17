using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DAGeneral
    {

        static public List<Interprete> ListadoInterprete()
        {
            List<Interprete> listado = new List<Interprete>();
            using (var data = new CineDBEntities())
            {

                listado = data.Interprete.ToList();
                
            }

            return listado;
        }

        static public List<Protagonista> ListadoProtagonista()
        {
            using (var data = new CineDBEntities())
            {
                return data.Protagonista.ToList();
            }

        }

        




    }
}
