using ProyectoFinal.DB;
using ProyectoFinal.Entities;
using System.Linq;


namespace ProyectoFinal.Models
{
    public class UsuarioModel
    {
        //Actualiza el empleado o cliente (Usuario)
        public void UpdateUsuario(UsuarioObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Usuario
                             where x.IdUsuario == obj.IdUsuario
                             select x).FirstOrDefault();

                datos.NombUsuario = obj.NombUsuario;
                datos.Identificacion = obj.Identificacion;
                datos.Nombre = obj.Nombre;
                datos.Apellido = obj.Apellido;
                datos.Correo = obj.Correo;
                datos.Telefono = obj.Telefono;

                contexto.SaveChanges();
            }
        }

        //Elimina el empleado o cliente (Usuario)
        public void DeleteUsuario(UsuarioObj obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Usuario
                             where x.IdUsuario == obj.IdUsuario
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    contexto.Usuario.Remove(datos);
                    contexto.SaveChanges();
                }
            }
        }


        //Encuentra la información del usuario
        public UsuarioObj UserInfo(string username)
        {
            UsuarioObj user = new UsuarioObj();

            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {
                var datos = (from x in contexto.Usuario
                             where x.NombUsuario == username
                             select x).FirstOrDefault();

                user.IdUsuario = datos.IdUsuario;
                user.NombUsuario = datos.NombUsuario;
                user.Identificacion = datos.Identificacion;
                user.Nombre = datos.Nombre;
                user.Apellido = datos.Apellido;
                user.Correo = datos.Correo;
                user.Telefono = datos.Telefono;

            }
            return user;
        }
    }
}