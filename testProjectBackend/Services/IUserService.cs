using System.Threading.Tasks;
using testProjectBackend.DTO;

namespace testProjectBackend.Services
{
    public interface IUserService
    {
        Task<object> AuthenticateAsync(LoginDto model);
    }
}