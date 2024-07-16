
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using real_state_backend.src.Shared.Infraestructure.Persistence;
using Real_state_Backend.src.Users.Domain;

namespace real_state_backend.src.Users.Infraestructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> FindAll()
        {
            Console.WriteLine("SDAFFSDA");
            var users = await _context.UserEntity.ToListAsync();


            return users;
        }

        public async Task Save(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}