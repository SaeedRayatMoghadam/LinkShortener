using System;
using System.Threading.Tasks;
using LinkShortener.Domain.Models.Account;

namespace LinkShortener.Domain.Interfaces
{
    public interface IUserRepository:IAsyncDisposable
    {
        Task<User> Get(string mobile);
        Task Create(User user);
        Task<bool> IsMobileExist(string mobile);

        Task Save();
    }
}