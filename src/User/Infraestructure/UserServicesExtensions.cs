
using Real_state_Backend.src.User.Application;

namespace Real_state_Backend.src.User.Infraestructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}