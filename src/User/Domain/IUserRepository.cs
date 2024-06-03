namespace Real_state_Backend.src.User.Domain
{
    public interface IUserRepository
    {
        public Task Save(UserDomain user);

        public UserDomain Search(string userId);
    }
}