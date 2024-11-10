using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Cores
{
    public class CRole
    {
        protected static RoleRepository roleRepository = new RoleRepository();

        public static Role GetRoleById(int roleId)
        {
            try
            {
                return roleRepository.GetRoleById(roleId);
            } catch
            {
                throw;
            }
        }
    }
}
