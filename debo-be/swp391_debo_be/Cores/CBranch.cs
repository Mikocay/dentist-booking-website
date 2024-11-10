using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Implement;
using Microsoft.EntityFrameworkCore;
using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dto.Implement;

namespace swp391_debo_be.Cores
{
    public class CBranch
    {
        protected static readonly BranchRepository _branchRepo;
        static CBranch()
        {
            var context = new DeboDev02Context(new DbContextOptions<DeboDev02Context>());
            _branchRepo = new BranchRepository(new BranchDao(context));
        }

        public static Task<int> addBranchAsync(BranchDto branch)
        {
            return _branchRepo.addBranchAsync(branch);
        }

        public static Task deleteBranchAsync(int id)
        {
            return _branchRepo.deleteBranchAsync(id);
        }

        public static Task activeBranchAsync(int id)
        {
            return _branchRepo.activeBranchAsync(id);
        }

        public static Task<List<BranchDto>> getAllBranchAsync(int page, int limit)
        {
            return _branchRepo.getAllBranchAsync(page, limit);
        }

        public static Task<BranchDto> getBranchAsync(int id)
        {
            return _branchRepo.getBranchAsync(id);
        }

        public static Task updateBranchAsync(int id, BranchDto branch)
        {
            return _branchRepo.updateBranchAsync(id, branch);
        }
    }
}
