using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Repository.Implement
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeDao employeeDao = new EmployeeDao();


        public List<User> GetDentistBasedOnTreamentId(int treatmentId)
        {
            return employeeDao.GetDentistBasedOnTreamentId(treatmentId);
        }

        public Task<List<CreateEmployeeDto>> GetEmployee(int page, int limit)
        {
            return employeeDao.GetEmployee(page, limit);
        }

        public Task<CreateEmployeeDto> GetEmployeeById(Guid id)
        {
            return employeeDao.GetEmployeeById(id);
        }

        public Task<List<CreateEmployeeDto>> GetEmployeeWithBranch(int page, int limit)
        {
            return employeeDao.GetEmployeeWithBranch(page, limit);
        }

        public Task<List<CreateEmployeeDto>> GetEmployeeWithBranchId(int id, int page, int limit)
        {
            return employeeDao.GetEmployeeWithBranchId(id, page, limit);
        }

        public Task UpdateBranchForEmployee(Guid id, CreateEmployeeDto employee)
        {
            return employeeDao.UpdateBranchForEmployee(id, employee);
        }
    }
}
