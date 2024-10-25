using swp391_debo_be.Constants;
using swp391_debo_be.Cores;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Helpers;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using Amazon.S3.Model;
using Amazon.S3;

namespace swp391_debo_be.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IAmazonS3 _s3Client;

        public UserService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }
        public ApiRespone CreateUser(CreateUserDto createUserDto)
        {

            if (CUser.GetUserByEmail(createUserDto.Email) != null)
            {
                return new ApiRespone { Success = false, Message = "Email is already exist", StatusCode = System.Net.HttpStatusCode.BadRequest };
            }

            User user = new User()
            {
                Id = System.Guid.NewGuid(),
                Email = createUserDto.Email,
                // Create phone number for user
                Phone = createUserDto.PhoneNumber,
                // Role = 5 la Customer -> dua tren database moi
                Role = 5,
                Gender = true,
                Password = HashPasswordHelper.HashPassword(createUserDto.password)
            };

            User createdUser = CUser.CreateUser(user);

            return new ApiRespone { Success = true, Data = createdUser, StatusCode = System.Net.HttpStatusCode.Created };
        }

        public object? GetProfile(string? userId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            return CUser.GetUsers();
        }

        public bool IsRefreshToken(User user)
        {
            return CUser.IsRefreshTokenExist(user);
        }

        public async Task<ApiRespone> CreateNewStaff(EmployeeDto employee)
        {
            var response = new ApiRespone();
            try
            {
                if (CUser.GetUserByEmail(employee.Email) != null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "Email is already exist";
                    return response;
                }
                if (CUser.GetUserByPhoneNumber(employee.Phone) != null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "Phone Number is already exist";
                    return response;
                }
                var newStaff = await CUser.CreateNewStaff(employee);
                var staff = await CUser.GetUserById2(newStaff);
                response.StatusCode = HttpStatusCode.OK;
                response.Success = true;
                response.Data = staff;
                response.Message = "Create New Staff Successfully";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> CreateNewDent(EmployeeDto employee)
        {
            var response = new ApiRespone();
            try
            {
                if (CUser.GetUserByEmail(employee.Email) != null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "Email is already exist";
                    return response;
                }
                if (CUser.GetUserByPhoneNumber(employee.Phone) != null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "Phone Number is already exist";
                    return response;
                }
                var newStaff = await CUser.CreateNewDent(employee);
                response.StatusCode = HttpStatusCode.OK;
                response.Success = true;
                response.Data = newStaff;
                response.Message = "Create New Dentist Successfully";

            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> CreateNewManager(EmployeeDto employee)
        {
            var response = new ApiRespone();
            try
            {
                if (CUser.GetUserByEmail(employee.Email) != null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "Email is already exist";
                    return response;
                }
                if (CUser.GetUserByPhoneNumber(employee.Phone) != null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "Phone Number is already exist";
                    return response;
                }
                var newStaff = await CUser.CreateNewManager(employee);
                response.StatusCode = HttpStatusCode.OK;
                response.Success = true;
                response.Data = newStaff;
                response.Message = "Create New Manager Successfully";

            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> ViewStaffList(int page, int limit)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CUser.ViewStaffList(page, limit);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Staff list data retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ApiRespone> ViewDentList(int page, int limit)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CUser.ViewDentList(page, limit);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Dentist list data retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ApiRespone> ViewManagerList(int page, int limit)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CUser.ViewManagerList(page, limit);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Manager list data retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> ViewCustomerList(int page, int limit)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CUser.ViewCustomerList(page, limit);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Customer list data retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> GetUserById2(Guid id)
        {
            var response = new ApiRespone();
            try
            {
                var existingUser = await CUser.GetUserById2(id);

                if (!string.IsNullOrEmpty(existingUser.MedRec))
                {
                    // Extract the file key from the MedRec URL
                    var fileKey = new Uri(existingUser.MedRec).AbsolutePath.TrimStart('/');

                    // Fetch metadata from S3
                    var metadata = await _s3Client.GetObjectMetadataAsync(new GetObjectMetadataRequest
                    {
                        BucketName = "swp391-bucket",
                        Key = fileKey
                    });
                    // Them Name cua file
                    existingUser.MedRecMetaData = new MedRecMetaDataDto
                    {
                        NameFile = fileKey,
                        FileSize = metadata.ContentLength,
                        LastModified = metadata.LastModified,
                        ContentType = metadata.Headers.ContentType
                    };
                }

                var role = existingUser.RoleName;
                response.StatusCode = HttpStatusCode.OK;
                response.Data = existingUser;
                response.Success = true;
                response.Message = role +" data retrieved successfully.";
            }
            catch(Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> UpdateUser(Guid id, EmployeeDto emp)
        {
            var response = new ApiRespone();
            try
            {
                if (id != emp.Id)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "User ID mismatch";
                    return response;
                }
                //if (CUser.GetUserByEmail(emp.Email) != null)
                //{
                //    response.StatusCode = HttpStatusCode.BadRequest;
                //    response.Success = false;
                //    response.Message = "Email is already exist";
                //    return response;
                //}
                //if (CUser.GetUserByPhoneNumber(emp.Phone) != null)
                //{
                //    response.StatusCode = HttpStatusCode.BadRequest;
                //    response.Success = false;
                //    response.Message = "Phone Number is already exist";
                //    return response;
                //}
                var data = await CUser.GetUserById2(id);
                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "User not found.";
                    return response;
                }
                await CUser.UpdateUser(id, emp);
                var updUser = await CUser.GetUserById2(id);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = updUser;
                response.Success = true;
                response.Message = "User data updated successfully.";

            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> AvailableManager(int page, int limit)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CUser.AvailableManager(page, limit);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Manager list data retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> UploadMedRecPatient(Guid id, EmployeeDto emp)
        {
            var response = new ApiRespone();
            try
            {
                if (id != emp.Id)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "User ID mismatch";
                    return response;
                }
                var data = await CUser.GetUserById2(id);
                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "User not found.";
                    return response;
                }
                await CUser.UploadMedRecPatient(id, emp);
                var updUser = await CUser.GetUserById2(id);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = updUser;
                response.Success = true;
                response.Message = "Medical Record file uploaded successfully.";

            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> UpdatePassword(Guid id, EmployeeDto emp)
        {
            var response = new ApiRespone();
            try
            {
                if (id != emp.Id)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "User ID mismatch";
                    return response;
                }
                var data = await CUser.GetUserById2(id);
                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "User not found.";
                    return response;
                }
                await CUser.UpdatePassword(id, emp);
                var updUser = await CUser.GetUserById2(id);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = updUser;
                response.Success = true;
                response.Message = "User data updated successfully.";

            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
            
        public ApiRespone firstTimeBooking(string userId)
        {
            try
            {
                if (Guid.TryParse(userId, out Guid id))
                {
                    var respone = CUser.firstTimeBooking(id);

                    return new ApiRespone { StatusCode = HttpStatusCode.OK,Data = respone, Message = "Fetched first time booking successfully.", Success = true };
                } else
                {
                       return new ApiRespone { StatusCode = HttpStatusCode.BadRequest, Data = null, Message = "Invalid user id", Success = false };
                }
            } catch (Exception ex)
            {
                return new ApiRespone { StatusCode = HttpStatusCode.BadRequest, Data = null, Message = ex.Message, Success = false };
            }
        }
>>>>>>> a0f4eeed9afedfd1eae96adbe41bfe37ae48af3d
    }
}
