using ProyectoFinal.DB;
using ProyectoFinal.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.Models
{
    public class EmpleadoModel
    {
        //Retorna la lista de usuarios con Rol 1 (Empleado / Admin)
        public List<UsuarioObj> SelectEmpleados()
        {
            List<UsuarioObj> lista = new List<UsuarioObj>();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Usuario
                             where x.Rol == 1
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

        //Inserta un usuario con Rol 1 (Empleado / Admin)
        public void InsertEmpleado(UsuarioObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {

                var Registro = new Usuario()
                {
                    NombUsuario = obj.NombUsuario,
                    Identificacion = obj.Identificacion,
                    Nombre = obj.Nombre,
                    Apellido = obj.Apellido,
                    Correo = obj.Correo,
                    Telefono = obj.Telefono,
                    Contra = obj.Contra,
                    Rol = 1
                };

                contexto.Usuario.Add(Registro);
                contexto.SaveChanges();
            }
        }
    }
}