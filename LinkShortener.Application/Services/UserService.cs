using System;
using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Account;
using LinkShortener.Application.Interfaces;
using LinkShortener.Application.Utilities;
using LinkShortener.Domain.Interfaces;
using LinkShortener.Domain.Models.Account;

namespace LinkShortener.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<RegisterResult> Register(RegisterDto registerDto)
        {
            if (!await _userRepository.IsMobileExist(registerDto.Mobile))
            {
                var user = new User()
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Password = registerDto.Password.EncodeToMd5(),
                    Mobile = registerDto.Mobile,
                    CreateDate = DateTime.Now,
                    MobileActiveCode = Guid.NewGuid().ToString()
                };

                await _userRepository.Create(user);
                await _userRepository.Save();

                return RegisterResult.Success;
            }

            return RegisterResult.MobileExists;
        }

        public async Task<LoginResult> Login(LoginDto loginDto)
        {
            var user = await _userRepository.Get(loginDto.Mobile);

            if (user == null) return LoginResult.NotFound;
            if (!user.IsMobileActive) return LoginResult.NotActivated;

            if (user.Password != loginDto.Password.EncodeToMd5()) return LoginResult.NotFound;

            return LoginResult.Success;
        }
    }
}