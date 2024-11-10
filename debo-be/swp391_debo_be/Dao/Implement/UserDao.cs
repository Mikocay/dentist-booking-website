using Microsoft.EntityFrameworkCore;
using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Helpers;
using swp391_debo_be.Services.Implements;

namespace swp391_debo_be.Dao.Implement
{
    public class UserDao : IUserDao
    {
        private readonly DeboDev02Context _context = new DeboDev02Context(new Microsoft.EntityFrameworkCore.DbContextOptions<DeboDev02Context>());

        public UserDao()
        {
        }

        public UserDao(DeboDev02Context context)
        {
            this._context = context;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }

        public string[] GetRolesName(User user)
        {
            int? roleId = user.Role;

            Role? role = _context.Roles.Find(roleId);

            if (role == null)
            {
                return new string[0];
            }

            return new string[] { role.Role1 };
        }

        public User GetUserByEmail(string email)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Email == email);

            return user;
        }

        public User GetUserById(Guid id)
        {
            User? user = _context.Users.Find(id);
            return user;
        }

        public User GetUserByPhone(string phone)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Phone == phone);

            return user;
        }

        public User GetUserByAvt(string avt)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Avt == avt);

            return user;
        }

        public bool IsRefreshTokenExist(User user)
        {
            User foundUser = GetUserById(user.Id);

            if (foundUser.RefreshToken == null)
            {
                return false;
            }

            return true;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList<User>();
        }


        public bool SaveRefreshToken(Guid userId, string refreshToken)
        {
            User? user = GetUserById(userId);

            if (user == null)
            {
                return false;
            }

            user.RefreshToken = refreshToken;
            UpdateUser(user);
            return true;
        }

        public bool DeleteRefreshToken(Guid userId)
        {
            User? user = GetUserById(userId);

            if (user == null)
            {
                return false;
            }

            user.RefreshToken = null;

            UpdateUser(user);

            return true;
        }

        public bool IsPasswordExist(string password, User user)
        {
            User? foundUser = GetUserById(user.Id);

            if (foundUser.Password == password)
            {
                return true;
            }

            return false;
        }

        public async Task<Guid> CreateNewStaff(EmployeeDto employee)
        {

            var newStaff = new User
            {
                Id = new Guid(Guid.NewGuid().ToString()),
                Role = 3,
                Username = employee.Username,
                Email = employee.Email,
                Password = HashPasswordHelper.HashPassword(employee.Password),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender ?? true,
                Phone = employee.Phone,
                Address = employee.Address,
                DateOfBirthday = employee.DateOfBirthday,
                IsFirstTime = false,
            };
            _context.Users.Add(newStaff);
            await _context.SaveChangesAsync();
            return newStaff.Id;
        }

        public async Task<Guid> CreateNewDentist(EmployeeDto employee)
        {
            var newDent = new User
            {
                Id = new Guid(Guid.NewGuid().ToString()),
                Role = 4,
                Username = employee.Username,
                Email = employee.Email,
                Password = HashPasswordHelper.HashPassword(employee.Password),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender ?? true,
                Phone = employee.Phone,
                Address = employee.Address,
                DateOfBirthday = employee.DateOfBirthday,
                IsFirstTime = false,
            };
            _context.Users.Add(newDent);
            await _context.SaveChangesAsync();
            return newDent.Id;
        }

        public async Task<Guid> CreateNewManager(EmployeeDto employee)
        {
            var newManager = new User
            {
                Id = new Guid(Guid.NewGuid().ToString()),
                Role = 2,
                Username = employee.Username,
                Email = employee.Email,
                Password = HashPasswordHelper.HashPassword(employee.Password),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender ?? true,
                Phone = employee.Phone,
                Address = employee.Address,
                DateOfBirthday = employee.DateOfBirthday,
                IsFirstTime = false,
            };
            _context.Users.Add(newManager);
            await _context.SaveChangesAsync();
            return newManager.Id;
        }

        public async Task<List<EmployeeDto>> ViewStaffList(int page, int limit)
        {
            IQueryable<User> query = _context.Users.Where(t => t.Role == 3);
            if (limit > 0)
            {
                query = query.Skip(page * limit)
                             .Take(limit);
            }
            var staffList = await query.ToListAsync();

            var staff = staffList.Select(t => new EmployeeDto
            {
                Id = t.Id,
                Role = t.Role,
                Username = t.Username,
                Email = t.Email,
                Password = t.Password,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Gender = t.Gender,
                Phone = t.Phone,
                Address = t.Address,
                DateOfBirthday = t.DateOfBirthday,
                Avt = t.Avt,
            }).ToList();

            return staff;
        }

        public async Task<List<EmployeeDto>> ViewDentList(int page, int limit)
        {
            IQueryable<User> query = _context.Users.Where(t => t.Role == 4);
            if (limit > 0)
            {
                query = query.Skip(page * limit)
                             .Take(limit);
            }
            var dentList = await query.ToListAsync();

            var dentist = dentList.Select(t => new EmployeeDto
            {
                Id = t.Id,
                Role = t.Role,
                Username = t.Username,
                Email = t.Email,
                Password = t.Password,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Gender = t.Gender,
                Phone = t.Phone,
                Address = t.Address,
                DateOfBirthday = t.DateOfBirthday,
                Avt = t.Avt,
            }).ToList();

            return dentist;
        }

        public async Task<List<EmployeeDto>> ViewManagerList(int page, int limit)
        {
            IQueryable<User> query = _context.Users.Where(t => t.Role == 2);
            if (limit > 0)
            {
                query = query.Skip(page * limit)
                             .Take(limit);
            }
            var mngList = await query.ToListAsync();

            var manager = mngList.Select(t => new EmployeeDto
            {
                Id = t.Id,
                Role = t.Role,
                Username = t.Username,
                Email = t.Email,
                Password = t.Password,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Gender = t.Gender,
                Phone = t.Phone,
                Address = t.Address,
                DateOfBirthday = t.DateOfBirthday,
                Avt = t.Avt,
            }).ToList();

            return manager;
        }

        public async Task<List<EmployeeDto>> ViewCustomerList(int page, int limit)
        {
            IQueryable<User> query = _context.Users.Where(t => t.Role == 5);
            if (limit > 0)
            {
                query = query.Skip(page * limit)
                             .Take(limit);
            }
            var cusList = await query.ToListAsync();
            var customer = cusList.Select(t => new EmployeeDto
            {
                Id = t.Id,
                Role = t.Role,
                Username = t.Username,
                Email = t.Email,
                Password = t.Password,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Gender = t.Gender,
                Phone = t.Phone,
                Address = t.Address,
                DateOfBirthday = t.DateOfBirthday,
                MedRec = t.MedRec,
                Avt = t.Avt,
            }).ToList();
            return customer;
        }

        public async Task<List<EmployeeDto>> AvailableManager(int page, int limit)
        {
            var query = from user in _context.Users
                        where user.Role == 2
                        join clinicBranch in _context.ClinicBranches
                        on user.Id equals clinicBranch.MngId into gj
                        from subClinicBranch in gj.DefaultIfEmpty()
                        where subClinicBranch == null
                        select new EmployeeDto
                        {
                            Id = user.Id,
                            Role = user.Role,
                            Username = user.Username,
                            Email = user.Email,
                            Password = user.Password,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Gender = user.Gender,
                            Phone = user.Phone,
                            Address = user.Address,
                            DateOfBirthday = user.DateOfBirthday,
                            MedRec = user.MedRec,
                            Avt = user.Avt
                        };

            if (limit > 0)
            {
                query = query.Skip(page * limit).Take(limit);
            }

            return await query.ToListAsync();
        }

        public async Task<EmployeeDto> GetUserById2(Guid id)
        {
            var user = await (from u in _context.Users
                              join r in _context.Roles on u.Role equals r.RoleId
                              where u.Id == id
                              select new EmployeeDto
                              {
                                  Id = u.Id,
                                  Role = u.Role,
                                  RoleName = r.Role1,
                                  Username = u.Username,
                                  Email = u.Email,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  Gender = u.Gender,
                                  Phone = u.Phone,
                                  Address = u.Address,
                                  DateOfBirthday = u.DateOfBirthday,
                                  MedRec = u.MedRec,
                                  Avt = u.Avt,
                              }).FirstOrDefaultAsync();
            return user;
        }

        public async Task UpdateUser(Guid id, EmployeeDto emp)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null || id != emp.Id)
            {
                throw new InvalidOperationException("User not found, or ID mismatch.");
            }
            else
            {
                existingUser.Username = emp.Username;
                existingUser.Email = emp.Email;
                existingUser.FirstName = emp.FirstName;
                existingUser.LastName = emp.LastName;
                existingUser.Gender = emp.Gender;
                existingUser.Phone = emp.Phone;
                existingUser.Address = emp.Address;
                existingUser.DateOfBirthday = emp.DateOfBirthday;
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }


        }

        public async Task UploadAvatarUser(Guid id, EmployeeDto emp)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null || id != emp.Id)
            {
                throw new InvalidOperationException("User not found, or ID mismatch.");
            }
            else
            {
                existingUser.Avt = emp.Avt;
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UploadMedRecPatient(Guid id, EmployeeDto emp)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null || id != emp.Id)
            {
                throw new InvalidOperationException("User not found, or ID mismatch.");
            }
            else
            {
                existingUser.MedRec = emp.MedRec;
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePassword(Guid id, EmployeeDto emp)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null || id != emp.Id)
            {
                throw new InvalidOperationException("User not found, or ID mismatch.");
            }

            if (existingUser.Password != HashPasswordHelper.HashPassword(emp.Password))
            {
                throw new InvalidOperationException("Old password is not valid");
            }
            else
            {
                existingUser.Password = HashPasswordHelper.HashPassword(emp.NewPassword);
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
        }

        public object firstTimeBooking(Guid userId)
        {
            var user = GetUserById(userId);

            if (user == null)
            {
                return new
                {
                    IsFirstTime = false,
                    Treatment = new List<string>()
                };
            }

            if (!(bool)user.IsFirstTime) 
            {
                return new
                {
                    IsFirstTime = false,
                    Treatment = new List<string>()
                };
            } else
            {
                ClinicTreatment? clinicTreatment = _context.ClinicTreatments.Where(t => t.Id == 8).FirstOrDefault();
                return new
                {
                    IsFirstTime = true,
                    Treatment = clinicTreatment
                };
            }
        }
    }
}
