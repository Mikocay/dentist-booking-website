using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Constants;
using swp391_debo_be.Dto.Implement;

namespace swp391_debo_be.Services.Interfaces
{
    public interface IEmployeeService
    {
        public ActionResult<ApiRespone> GetDentistBasedOnTreamentId(int treatmentId);
        public Task<ApiRespone> GetEmployeeWithBranch(int page, int limit);
        public Task<ApiRespone> GetEmployeeById(Guid id);
        public Task<ApiRespone> UpdateBranchForEmployee(Guid id, CreateEmployeeDto employee);
        public Task<ApiRespone> GetEmployee(int page, int limit);
        public Task<ApiRespone> GetEmployeeWithBranchId(int id, int page, int limit);
    }
}
