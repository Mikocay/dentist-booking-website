using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Cores
{
    public class CEmployee
    {
        protected static IEmployeeRepository _employeeRepo = new EmployeeRepository();

        public static List<User> GetDentistBasedOnTreamentId(int treatmentId)
        {
            return _employeeRepo.GetDentistBasedOnTreamentId(treatmentId);
        }
        public static Task<List<CreateEmployeeDto>> GetEmployeeWithBranch(int page, int limit)
        {
            return _employeeRepo.GetEmployeeWithBranch(page, limit);
        }
        public static Task<CreateEmployeeDto> GetEmployeeById(Guid id)
        {
            return _employeeRepo.GetEmployeeById(id);
        }

        public static Task UpdateBranchForEmployee(Guid id, CreateEmployeeDto employee)
        {
            return _employeeRepo.UpdateBranchForEmployee(id, employee);
        }

        public static Task<List<CreateEmployeeDto>> GetEmployee(int page, int limit)
        {
            return _employeeRepo.GetEmployee(page, limit);
        }

        public static Task<List<CreateEmployeeDto>> GetEmployeeWithBranchId(int id, int page, int limit)
        {
            return _employeeRepo.GetEmployeeWithBranchId(id, page, limit);
        }
    }
}
