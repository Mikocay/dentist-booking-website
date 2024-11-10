using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;

namespace swp391_debo_be.Dao.Interface
{
    public interface IEmployeeDao
    {
        public List<User> GetDentistBasedOnTreamentId(int treatmentId);
        public Task<List<CreateEmployeeDto>> GetEmployeeWithBranch(int page, int limit);
        public Task<List<CreateEmployeeDto>> GetEmployeeWithBranchId(int id, int page, int limit);
        // Role Dentist and Staff
        public Task<List<CreateEmployeeDto>> GetEmployee(int page, int limit);
        public Task<CreateEmployeeDto> GetEmployeeById(Guid id);
        public Task UpdateBranchForEmployee(Guid id, CreateEmployeeDto employee);
    }
}
