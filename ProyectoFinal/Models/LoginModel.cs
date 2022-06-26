using ProyectoFinal.Entities;
using System.Linq;
using ProyectoFinal.DB;

namespace ProyectoFinal.Models
{
    public class LoginModel
    {
        //Trae los datos del login y los verifica en la BD
        public int Login(LoginObj Obj)
        {
            using (var contexto = new Proyecto_PrograAvanzadaEntities())
            {

                var datos = (from u in contexto.Usuario
                             where u.NombUsuario == Obj.Username
                             select u).FirstOrDefault();

                if (datos != null)
                {
                    if (datos.Contra == Obj.Password)
                    {
                        if (datos.Rol == 1)
                        {
                            return 1; //Login Correcto Admin;
                        }
                        else if (datos.Rol == 2)
                        {
                            return 2; //Login Correcto Usuario;

                        }
                    }
                    return 0; //Contraseña Incorrecta;
                }
                return -1; //El usuario no existe;
            }
        }

        //Registra un usuario con rol = 2 (Cliente)
        public void Register(UsuarioObj obj)
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
                    Rol = 2
                };

                contexto.Usuario.Add(Registro);
                contexto.SaveChanges();
            }
        }
    }
}