using WSVenta.Models;
using WSVenta.Models.Response;
using WSVenta.Models.ViewModels;
using WSVenta.Tools;

namespace WSVenta.Services
{
    public class UserService : IUserService
    {
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse Uresponse = new UserResponse();

            using (var db = new VentaRealContext())
            {
                string spassword = Encrypt.GetSHA256(model.Password);

                var usuario = db.Usuarios.Where(d => d.Email == model.Email && d.Password == spassword).FirstOrDefault();

                if (usuario == null)
                {
                    return null;
                }

                Uresponse.Email = usuario.Email;
              
            }

            return Uresponse;
        }
    }
}
