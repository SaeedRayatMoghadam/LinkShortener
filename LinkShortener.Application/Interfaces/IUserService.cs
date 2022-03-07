using System.Collections.Generic;
using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Account;
using LinkShortener.Domain.Models.Account;
using LinkShortener.Domain.ViewModels.Account;

namespace LinkShortener.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(string mobile);
        Task<UpdateUserDto> Get(long id);
        Task<List<UsersViewModel>> GetAll();
        Task<CreateUserResult> Create(CreateUserDto user);
            
        Task<RegisterResult> Register(RegisterDto registerDto);
        Task<LoginResult> Login(LoginDto loginDto);

        Task<UpdateUserResult> Update(UpdateUserDto updateUser);

    } 
}