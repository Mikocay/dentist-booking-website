using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Entity.Implement;

namespace swp391_debo_be.Dao.Implement
{
    public class RoleDao : IRoleDao
    {
        private readonly DeboDev02Context _context = new DeboDev02Context(new Microsoft.EntityFrameworkCore.DbContextOptions<DeboDev02Context>());

        public RoleDao()
        {
        }

        public Role GetRoleById(int roleId)
        {
            Role role = _context.Roles.Find(roleId);

            if (role == null)
            {
                return new Role();
            }

            return role;
        }
    }
}
