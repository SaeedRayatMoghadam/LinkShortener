using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Account;

namespace LinkShortener.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegisterResult> Register(RegisterDto registerDto);
        Task<LoginResult> Login(LoginDto loginDto);
    }
}