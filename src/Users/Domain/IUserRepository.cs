namespace Real_state_Backend.src.Users.Domain
{
    public interface IUserRepository
    {
        public Task Save(User user);

        public Task<List<User>> FindAll();
    }
}