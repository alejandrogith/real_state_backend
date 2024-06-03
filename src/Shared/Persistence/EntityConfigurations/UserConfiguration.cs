using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Real_state_Backend.src.User.Domain;

namespace Real_state_Backend.src.Shared.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDomain>
    {
        public void Configure(EntityTypeBuilder<UserDomain> builder)
        {

            builder.HasKey(x => x.Id);

        }
    }
}