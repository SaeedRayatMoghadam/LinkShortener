using System.Collections.Generic;
using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Account;
using LinkShortener.Domain.Models.Account;
using LinkShortener.Domain.ViewModels.Account;

namespace LinkShortener.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegisterResult> Register(RegisterDto registerDto);
        Task<LoginResult> Login(LoginDto loginDto);
        Task<User> Get(string mobile);
        Task<List<UsersViewModel>> GetAll();
    }
}