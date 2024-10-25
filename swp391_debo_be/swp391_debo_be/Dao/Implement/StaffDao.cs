using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;

namespace swp391_debo_be.Dao.Implement
{
    public class StaffDao : IStaffDao
    {
        public Task<int> addStaffAsync(StaffDto staff)
        {
            throw new NotImplementedException();
        }

        public Task deleteStaffAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StaffDto>> getAllStaffAsync(int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<StaffDto> getStaffAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task updateStaffAsync(int id, StaffDto staff)
        {
            throw new NotImplementedException();
        }
    }
}
