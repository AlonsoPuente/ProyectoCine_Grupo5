using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DAPersona
    {
        /// Listado de Persona
        //////////////////////////////////////////////////////
        static public List<Persona> ListadoPersona()
        {
            List<Persona> listadoPersona = new List<Persona>();
            using (var data = new CineDATABASEEntities())
            {

                listadoPersona = data.Persona.ToList();

            }

            return listadoPersona;
        }

        /// Crear Persona
        //////////////////////////////////////////////////////
        static public bool RegistrarPersona(Persona persona)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.Persona.Add(persona);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Persona
        //////////////////////////////////////////////////////
        static public bool ActualizarPersona(Persona persona) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    // realizar la consulta y actualizar
                    Persona actual = data.Persona.Where(x => x.CodPersona == persona.CodPersona).FirstOrDefault();// alias
                    actual.Paterno = persona.Paterno;
                    actual.Materno = persona.Materno;
                    actual.Nombres = persona.Nombres;
                    actual.Direccion = persona.Direccion;
                    actual.Email = persona.Email;
                    actual.FechaNacimiento = persona.FechaNacimiento;
                    actual.NroDocumento = persona.NroDocumento;
                    actual.foto = persona.foto;
                    actual.doc = persona.doc;
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;

        }

        /// Eliminar Persona
        //////////////////////////////////////////////////////
        static public bool EliminarPersona(int Codpersona) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    Persona persona = data.Persona.Where(x => x.CodPersona == Codpersona).FirstOrDefault();// alias

                    data.Persona.Remove(persona);
                    data.SaveChanges();

                }
            }
            catch (Exception)
            {

                exito = false;
            }

            return exito;
        }
    }
}
