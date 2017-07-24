using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DAPedido
    {
        static public List<Pedido> ListadoPedido()
        {
            List<Pedido> listadoPedido = new List<Pedido>();
            using (var data = new CineDATABASEEntities())
            {

                listadoPedido = data.Pedido.ToList();

            }
            return listadoPedido;
        }

        static public List<Ticket> ListadoTicket()
        {
            List<Ticket> listadoTicket = new List<Ticket>();
            using (var data = new CineDATABASEEntities())
            {

                listadoTicket = data.Ticket.ToList();

            }
            return listadoTicket;
        }

        /// Registrar Pedido
        //////////////////////////////////////////////////////

        static public bool RegistrarPedido(Pedido Pedido)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.Pedido.Add(Pedido);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Pedido
        //////////////////////////////////////////////////////
        static public bool ActualizarPedido(Pedido Pedido) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    // realizar la consulta y actualizar
                    Pedido actual = data.Pedido.Where(x => x.CodPedido == Pedido.CodPedido).FirstOrDefault();// alias
                    actual.Descripcion = Pedido.Descripcion;
                    actual.CodTicket = Pedido.CodTicket;
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;

        }

        /// Eliminar Pedido
        //////////////////////////////////////////////////////
        static public bool EliminarPedido(int CodPedido) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    Pedido Pedido = data.Pedido.Where(x => x.CodPedido == CodPedido).FirstOrDefault();// alias

                    data.Pedido.Remove(Pedido);
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
