using swp391_debo_be.Constants;
using swp391_debo_be.Dto.Implement;

namespace swp391_debo_be.Services.Interfaces
{
    public interface IBranchService
    {
        public Task<ApiRespone> getAllBranchAsync(int page, int limit);
        public Task<ApiRespone> getBranchAsync(int id);
        public Task<ApiRespone> addBranchAsync(BranchDto branch);
        public Task<ApiRespone> updateBranchAsync(int id, BranchDto branch);
        public Task<ApiRespone> deleteBranchAsync(int id);
        public Task<ApiRespone> activeBranchAsync(int id);

    }
}
