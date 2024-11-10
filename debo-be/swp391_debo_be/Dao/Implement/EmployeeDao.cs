using Microsoft.EntityFrameworkCore;
using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using System.Linq;

namespace swp391_debo_be.Dao.Implement
{
    public class EmployeeDao : IEmployeeDao
    {
        private readonly DeboDev02Context _context = new DeboDev02Context(new DbContextOptions<DeboDev02Context>());
        public List<User> GetDentistBasedOnTreamentId(int treatmentId)
        {
            var employees = _context.Employees
                .Where(e => e.Treats.Any(t => t.Id == treatmentId))
                .ToList();

            var resultEmployees = _context.Users
                                  .Where(u => employees.Select(e => e.Id).Contains(u.Id))
                                  .ToList();

            return resultEmployees;
        }

        public async Task<List<CreateEmployeeDto>> GetEmployee(int page, int limit)
        {
            var result = await(from u in _context.Users
                               join e in _context.Employees on u.Id equals e.Id
                               where e.Type != 2
                               select new CreateEmployeeDto
                               {
                                   Id = e.Id,
                                   Name = u.FirstName + " " + u.LastName,
                                   BrId = e.BrId,
                                   Type = e.Type,
                                   Salary = e.Salary
                               }).Skip(page * limit).Take(limit).ToListAsync();
            return result;
        }

        public async Task<CreateEmployeeDto> GetEmployeeById(Guid id)
        {
            var result = await(from u in _context.Users
                               join e in _context.Employees on u.Id equals e.Id
                               where u.Id == id
                               select new CreateEmployeeDto
                               {
                                   Id = e.Id,
                                   Name = u.FirstName + " " + u.LastName,
                                   BrId = e.BrId,
                                   Type = e.Type,
                                   Salary = e.Salary
                               }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<List<CreateEmployeeDto>> GetEmployeeWithBranch(int page, int limit)
        {
            var result = await (from u in _context.Users
                                join e in _context.Employees on u.Id equals e.Id
                                select new CreateEmployeeDto
                                {
                                    Id = e.Id,
                                    Name = u.FirstName + " " + u.LastName,
                                    BrId = e.BrId,
                                    Type = e.Type,
                                    Salary = e.Salary
                                }).Skip(page * limit).Take(limit).ToListAsync();

            return result;
        }

        public async Task<List<CreateEmployeeDto>> GetEmployeeWithBranchId(int id , int page, int limit)
        {
            var result = await(from u in _context.Users
                               join e in _context.Employees on u.Id equals e.Id
                               where e.BrId == id
                               select new CreateEmployeeDto
                               {
                                   Id = e.Id,
                                   Name = u.FirstName + " " + u.LastName,
                                   BrId = e.BrId,
                                   Type = e.Type,
                                   Salary = e.Salary
                               }).Skip(page * limit).Take(limit).ToListAsync();

            return result;
        }

        public async Task UpdateBranchForEmployee(Guid id, CreateEmployeeDto employee)
        {
            var existingEmp = await _context.Employees.FindAsync(id);
            if (existingEmp == null)
            {
                throw new InvalidOperationException("Employee not found or ID mismatch.");
            }
            else
            {
                existingEmp.BrId = employee.BrId;
                existingEmp.Salary = employee.Salary;

                _context.Employees.Update(existingEmp);
                await _context.SaveChangesAsync();
            }
        }


    }
}
