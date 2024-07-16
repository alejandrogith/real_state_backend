using real_state_backend.src.Users.Infraestructure.Persistence;
using Real_state_Backend.src.Users.Domain;

namespace Real_state_Backend.src.Users.Infraestructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}