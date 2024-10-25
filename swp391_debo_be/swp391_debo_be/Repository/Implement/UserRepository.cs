using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDao _userDao;

        public UserRepository()
        {
            this._userDao = new UserDao();
        }

        public UserRepository(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public User CreateUser(User user)
        {
            return _userDao.CreateUser(user);
        }

        public User DeleteUser(User user)
        {
            return _userDao.DeleteUser(user);
        }

        public string[] getRolesName(User user)
        {
            return _userDao.GetRolesName(user);
        }

        public User GetUserByEmail(string email)
        {
            return _userDao.GetUserByEmail(email);
        }

        public User GetUserById(Guid id)
        {
            return _userDao.GetUserById(id);
        }

        public User GetUserByPhone(string phone)
        {
            return _userDao.GetUserByPhone(phone);
        }

        public List<User> GetUsers()
        {
            return _userDao.GetUsers();
        }

        public bool IsRefreshTokenExist(User user)
        {
            return _userDao.IsRefreshTokenExist(user);

        }

        public bool SaveRefreshToken(Guid userId, string refreshToken)
        {
            return _userDao.SaveRefreshToken(userId, refreshToken);
        }

        public User UpdateUser(User user)
        {
            return _userDao.UpdateUser(user);
        }

        public bool DeleteRefreshToken(Guid userId)
        {
            return _userDao.DeleteRefreshToken(userId);
        }

        public bool IsPasswordExist(string password, User user)
        {
            return _userDao.IsPasswordExist(password, user);
        }

        public Task<Guid> CreateNewStaff(EmployeeDto employee)
        {
            return _userDao.CreateNewStaff(employee);
        }

        public Task<Guid> CreateNewDent(EmployeeDto employee)
        {
            return _userDao.CreateNewDentist(employee);
        }

        public Task<Guid> CreateNewManager(EmployeeDto employee)
        {
            return _userDao.CreateNewManager(employee);
        }

        public Task<List<EmployeeDto>> ViewStaffList(int page, int limit)
        {
            return _userDao.ViewStaffList(page, limit);
        }
        public Task<List<EmployeeDto>> ViewDentList(int page, int limit)
        {
            return _userDao.ViewDentList(page, limit);
        }
        public Task<List<EmployeeDto>> ViewManagerList(int page, int limit)
        {
            return _userDao.ViewManagerList(page, limit);
        }
        public Task<List<EmployeeDto>> ViewCustomerList(int page, int limit)
        {
            return _userDao.ViewCustomerList(page, limit);
        }
        public Task<EmployeeDto> GetUserById2(Guid id)
        {
            return _userDao.GetUserById2(id);
        }

        public Task UpdateUser(Guid id, EmployeeDto emp)
        {
            return _userDao.UpdateUser(id, emp);
        }

<<<<<<< HEAD
        public Task<List<EmployeeDto>> AvailableManager(int page, int limit)
        {
            return _userDao.AvailableManager(page, limit);
=======
        public Task UploadAvatarUser(Guid id, EmployeeDto emp)
        {
            return _userDao.UploadAvatarUser(id, emp);
        }

        public Task UploadMedRecPatient(Guid id, EmployeeDto emp)
        {
            return _userDao.UploadMedRecPatient(id, emp);
        }

        public User GetUserByAvt(string avt)
        {
            return _userDao.GetUserByAvt(avt);
        }

        public Task UpdatePassword(Guid id, EmployeeDto emp)
        {
            return _userDao.UpdatePassword(id, emp);
        }
        public object firstTimeBooking(Guid userId)
        {
            return _userDao.firstTimeBooking(userId);
>>>>>>> a0f4eeed9afedfd1eae96adbe41bfe37ae48af3d
        }
    }
}
