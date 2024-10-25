using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;

namespace swp391_debo_be.Dao.Interface
{
    public interface IBranchDao
    {
        public Task<List<BranchDto>> getAllBranchAsync(int page, int limit);
        public Task<BranchDto> getBranchAsync(int id);
        public Task<int> addBranchAsync(BranchDto branch);
        public Task updateBranchAsync(int id, BranchDto branch);
        public Task deleteBranchAsync(int id);
        public Task activeBranchAsync(int id);
    }
}
