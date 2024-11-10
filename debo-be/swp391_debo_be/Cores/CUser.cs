using Microsoft.EntityFrameworkCore;
using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Helpers;
using swp391_debo_be.Repository.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Cores
{
    public class CUser
    {
        protected static IUserRepository _userRepository = new UserRepository();

        static CUser()
        {
            var context = new DeboDev02Context(new DbContextOptions<DeboDev02Context>());
            _userRepository = new UserRepository(new UserDao(context));
        }

        public static User GetUserByPhoneNumber(string phoneNumber)
        {
            return _userRepository.GetUserByPhone(phoneNumber);
        }

        public static User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public static User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public static User GetUserByAvt(string avt)
        {
            return _userRepository.GetUserByAvt(avt);
        }

        public static string[] GetRoleName(User user)
        {
           return _userRepository.getRolesName(user);
        }

        public static List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public static bool IsRefreshTokenExist(User user)
        {
            return _userRepository.IsRefreshTokenExist(user);
        }

        public static bool SaveRefreshToken(Guid userId, string refreshToken)
        {
            return _userRepository.SaveRefreshToken(userId, refreshToken);
        }

        public static bool DeleteRefreshToken(Guid userId)
        {
            return _userRepository.DeleteRefreshToken(userId);
        }

        public static bool IsPasswordExist(string password, User user)
        {
            string hashedPassword = HashPasswordHelper.HashPassword(password);
            return _userRepository.IsPasswordExist(hashedPassword, user);
        }

        public static Task<Guid> CreateNewStaff(EmployeeDto employee)
        {
            return _userRepository.CreateNewStaff(employee);
        }

        public static Task<Guid> CreateNewDent(EmployeeDto employee)
        {
            return _userRepository.CreateNewDent(employee);
        }

        public static Task<Guid> CreateNewManager(EmployeeDto employee)
        {
            return _userRepository.CreateNewManager(employee);
        }

        public static Task<List<EmployeeDto>> ViewStaffList(int page, int limit)
        {
            return _userRepository.ViewStaffList(page, limit);
        }
        public static Task<List<EmployeeDto>> ViewDentList(int page, int limit)
        {
            return _userRepository.ViewDentList(page, limit);
        }
        public static Task<List<EmployeeDto>> ViewManagerList(int page, int limit)
        {
            return _userRepository.ViewManagerList(page, limit);
        }
        public static Task<List<EmployeeDto>> ViewCustomerList(int page, int limit)
        {
            return _userRepository.ViewCustomerList(page, limit);
        }
        public static Task<EmployeeDto> GetUserById2(Guid id)
        {
            return _userRepository.GetUserById2(id);
        }

        public static object firstTimeBooking(Guid userId)
        {
            return _userRepository.firstTimeBooking(userId);
        }

        public static Task UpdateUser(Guid id, EmployeeDto emp)
        {
            return _userRepository.UpdateUser(id, emp);
        }

<<<<<<< HEAD
        public static Task<List<EmployeeDto>> AvailableManager(int page, int limit)
        {
            return _userRepository.AvailableManager(page, limit);
=======
        public static Task UploadAvatarUser(Guid id, EmployeeDto emp)
        {
            return _userRepository.UploadAvatarUser(id, emp);
        }
        public static Task UploadMedRecPatient(Guid id, EmployeeDto emp)
        {
            return _userRepository.UploadMedRecPatient(id, emp);
        }

        public static Task UpdatePassword(Guid id, EmployeeDto emp)
        {
            return _userRepository.UpdatePassword(id, emp);
>>>>>>> a0f4eeed9afedfd1eae96adbe41bfe37ae48af3d
        }
    }
}
