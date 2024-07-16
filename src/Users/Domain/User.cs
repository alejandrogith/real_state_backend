

using real_state_backend.src.Users.Domain;

namespace Real_state_Backend.src.Users.Domain
{
    public class User
    {
        public UserId Id { get; }
        public UserName Name { get; }
        public UserEmail Email { get; }

        public User(UserId id, UserName Name, UserEmail email)
        {
            this.Id = id;
            this.Email = email;
            this.Name = Name;

        }

        public User()
        {
        }

        public static User Create(UserId id, UserEmail email, UserName name)
        {
            var course = new User(id, name, email);
            return course;
        }

    }

}