using LinkShortener.Application.Interfaces;
using LinkShortener.Application.Services;
using LinkShortener.Data.Repositories;
using LinkShortener.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LinkShortener.IOC
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Tools



            #endregion
        }
    }
}