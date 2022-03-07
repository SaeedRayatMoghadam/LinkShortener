using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkShortener.Domain.Models.Account;
using LinkShortener.Domain.ViewModels.Account;

namespace LinkShortener.Domain.Interfaces
{
    public interface IUserRepository:IAsyncDisposable
    {
        Task<User> Get(string mobile);
        Task<User> Get(long id);
        Task<List<UsersViewModel>> GetAll();

        Task Create(User user);
        void Update(User user);

        Task<bool> IsMobileExist(string mobile);

        Task Save();
    }
}