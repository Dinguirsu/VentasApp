using WSVenta.Models.Response;
using WSVenta.Models.ViewModels;

namespace WSVenta.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
