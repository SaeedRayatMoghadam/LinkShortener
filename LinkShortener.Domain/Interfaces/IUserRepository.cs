using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkShortener.Domain.Models.Account;
using LinkShortener.Domain.ViewModels.Account;

namespace LinkShortener.Domain.Interfaces
{
    public interface IUserRepository:IAsyncDisposable
    {
        Task<List<UsersViewModel>> GetAll();
        Task<User> Get(string mobile);
        Task Create(User user);
        Task<bool> IsMobileExist(string mobile);

        Task Save();
    }
}