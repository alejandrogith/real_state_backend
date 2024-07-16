

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using real_state_backend.src.Users.Domain;
using Real_state_Backend.src.Users.Domain;

namespace real_state_backend.src.Users.Infraestructure.Persistence
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(id => id.Value, value => new UserId(value));

            //    builder.OwnsOne(x => x.Name);
            //   builder.OwnsOne(x => x.Email);

        }
    }



}