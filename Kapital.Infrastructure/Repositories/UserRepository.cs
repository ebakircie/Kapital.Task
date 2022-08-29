using Kapital.Domain.Entities;
using Kapital.Domain.Repositories;
using Kapital.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(KapitalContext kapitalContext) : base(kapitalContext)
        {
        }
    }
}
