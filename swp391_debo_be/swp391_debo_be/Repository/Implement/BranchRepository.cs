using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Repository.Implement
{
    public class BranchRepository : IBranchRepository
    {
        private readonly IBranchDao _branchDao;

        public BranchRepository(IBranchDao branchDao)
        {
            _branchDao = branchDao;
        }

        public Task<int> addBranchAsync(BranchDto branch)
        {
            return _branchDao.addBranchAsync(branch);
        }

        public Task deleteBranchAsync(int id)
        {
            return _branchDao.deleteBranchAsync(id);
        }

        public Task activeBranchAsync(int id)
        {
            return _branchDao.activeBranchAsync(id);
        }

        public Task<List<BranchDto>> getAllBranchAsync(int page, int limit)
        {
            return _branchDao.getAllBranchAsync(page, limit);
        }

        public Task<BranchDto> getBranchAsync(int id)
        {
            return _branchDao.getBranchAsync(id);
        }

        public Task updateBranchAsync(int id, BranchDto branch)
        {
            return _branchDao.updateBranchAsync(id, branch);
        }
    }
}
