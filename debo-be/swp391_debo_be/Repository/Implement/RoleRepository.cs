using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Repository.Implement
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IRoleDao roleDao = new RoleDao();


        public Role GetRoleById(int roleId)
        {
            return roleDao.GetRoleById(roleId);
        }
    }
}
