using ProyectoFinal.DB;
using ProyectoFinal.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.Models
{
    public class ClienteModel
    {
        //Retorna la lista de usuarios con Rol 2 (Clientes)
        public List<UsuarioObj> SelectClientes()
        {
            List<UsuarioObj> lista = new List<UsuarioObj>();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Usuario
                             where x.Rol == 2
                             select x).ToList();

                foreach (var item in datos)
                {
                    lista.Add(new UsuarioObj
                    {
                        IdUsuario = item.IdUsuario,
                        NombUsuario = item.NombUsuario,
                        Identificacion = item.Identificacion,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Correo = item.Correo,
                        Telefono = item.Telefono,
                    });
                }
            }
            return lista;
        }
    }
}