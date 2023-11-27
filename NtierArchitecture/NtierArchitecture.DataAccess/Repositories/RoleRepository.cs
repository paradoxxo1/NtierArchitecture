using NtierArchitecture.DataAccess.Context;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;

namespace NtierArchitecture.DataAccess.Repositories
{
    internal sealed class RoleRepository : Repository<AppRole>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
