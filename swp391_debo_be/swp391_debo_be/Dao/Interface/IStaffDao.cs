using swp391_debo_be.Dto.Implement;

namespace swp391_debo_be.Dao.Interface
{
    public interface IStaffDao
    {
        public Task<List<StaffDto>> getAllStaffAsync(int page, int limit);
        public Task<StaffDto> getStaffAsync(int id);
        public Task<int> addStaffAsync(StaffDto staff);
        public Task updateStaffAsync(int id, StaffDto staff);
        public Task deleteStaffAsync(int id);
    }
}
